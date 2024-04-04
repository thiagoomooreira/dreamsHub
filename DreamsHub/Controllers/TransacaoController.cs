using DreamsHub.Models;
using DreamsHub.Models.Dtos;
using DreamsHub.Models.Infra;
using DreamsHub.Models.Infra.ControllerComponent;
using DreamsHub.Models.Tipos;
using DreamsHub.Services.Interface;
using DreamsHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DreamsHub.Controllers;

public class TransacaoController : Controller
{
    private readonly IViewRenderService _viewRenderService;
    private readonly ITransacaoService _transacaoService;
    private readonly ICategoriaService _categoriaService;
    private readonly ITotalizarTransacoesService _totalizarTransacoesService;

    public TransacaoController(IViewRenderService viewRenderService, 
        ITransacaoService transacaoService, ICategoriaService categoriaService, ITotalizarTransacoesService totalizarTransacoesService)
    {
        _viewRenderService = viewRenderService;
        _transacaoService = transacaoService;
        _categoriaService = categoriaService;
        _totalizarTransacoesService = totalizarTransacoesService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View(new TransacaoViewModel()
        {
            Data = DateTime.Now,
            TotalizadorMensal = _totalizarTransacoesService.TotalizarTransacoesDoMes(DateTime.Now.Month, DateTime.Now.Year)
        });
    }

    [HttpPost]
    public JsonResult Filtro(FiltroTransacaoDto filtro)
    {
        string tabelaTransacoes = this.TabelaTransacoes(new FiltroTransacao(filtro));

        return Json(new ViewResponse(tabelaTransacoes)
        {
            Content = new {
                Mes = filtro.Data.ToString("MMMM").ToUpper(),
                Data = filtro.Data.ToString("dd/MM/yyyy")
            }
        });
    }

    [HttpPost]
    public JsonResult ModalAdicionarTransacao(ETipoTransacao tipo, int codigo = 0)
    {
        try
        {
            AdicionarTransacaoViewModel viewModel = new(tipo)
            {
                Categorias = _categoriaService.BuscarTodos(tipo).ToList(),
            };

            if (codigo != 0)
                viewModel.Transacao = new TransacaoDto(_transacaoService.BuscarPeloCodigo(codigo));

            ViewResponse viewResponse = new ViewResponse(
                this._viewRenderService.RenderToString(this, "_modalAdicionarTransacao", 
                    viewModel)
            );

            return Json(viewResponse);
        }
        catch (Exception e)
        {
            return Json(new ViewResponse(false, e.Message));
        }
        
    }

    [HttpPost]
    public IActionResult Salvar(TransacaoDto transacao)
    {
        try
        {
            _transacaoService.AdicionarOuAtualizar(transacao);

            return Json(new ViewResponse(TabelaTransacoes(new FiltroTransacao()))
            {
                Mensagem = "Salvo com sucesso"
            });
        }
        catch (Exception e)
        {
            return Json(new ViewResponse(false, e.Message));
        }
    }
    
    [HttpPost]
    public IActionResult Excluir(int codigo)
    {
        try
        {
            _transacaoService.Excluir(codigo);

            return Json(new ViewResponse(TabelaTransacoes(new FiltroTransacao()))
            {
                Mensagem = "Excluído com sucesso"
            });
        }
        catch (Exception e)
        {
            return Json(new ViewResponse(false, e.Message));
        }
    }

    
    private string TabelaTransacoes(FiltroTransacao filtro)
    {
        string renderToString = _viewRenderService.RenderToString(this, "_tabelaTransacoes", new TransacaoViewModel()
        {
            Transacoes = _transacaoService.BuscarTodos(filtro).ToList()
        });

        return renderToString;
    }
}