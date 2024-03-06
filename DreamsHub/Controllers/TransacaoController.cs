using DreamsHub.Models;
using DreamsHub.Models.Dtos;
using DreamsHub.Models.Infra;
using DreamsHub.Models.Infra.ControllerComponent;
using DreamsHub.Models.Tipos;
using DreamsHub.Repository.Interface;
using DreamsHub.Services.Interface;
using DreamsHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DreamsHub.Controllers;

public class TransacaoController : Controller
{
    private readonly IViewRenderService _viewRenderService;
    private readonly ITransacaoService _transacaoService;
    private readonly ICategoriaRepository _categoriaRepository;

    public TransacaoController(IViewRenderService viewRenderService, ICategoriaRepository categoriaRepository, ITransacaoService transacaoService)
    {
        _viewRenderService = viewRenderService;
        _categoriaRepository = categoriaRepository;
        _transacaoService = transacaoService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View(new TransacaoViewModel()
        {
            Transacoes = _transacaoService.BuscarTodos().ToList()
        });
    }

    [HttpPost]
    public JsonResult ModalAdicionarTransacao(ETipoTransacao tipo, int codigo = 0)
    {
        try
        {
            AdicionarTransacaoViewModel viewModel = new AdicionarTransacaoViewModel(tipo)
            {
                Categorias = _categoriaRepository.GerarIqueryable().ToList(),
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

            return Json(new ViewResponse(TabelaTransacoes())
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

            return Json(new ViewResponse(TabelaTransacoes())
            {
                Mensagem = "Excluído com sucesso"
            });
        }
        catch (Exception e)
        {
            return Json(new ViewResponse(false, e.Message));
        }
    }

    
    private string TabelaTransacoes()
    {
        string renderToString = _viewRenderService.RenderToString(this, "_tabelaTransacoes", new TransacaoViewModel()
        {
            Transacoes = _transacaoService.BuscarTodos().ToList()
        });

        return renderToString;
    }
}