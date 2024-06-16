using DreamsHub.Models;
using DreamsHub.Models.Context;
using DreamsHub.Models.Dtos;
using DreamsHub.Models.Infra;
using DreamsHub.Models.Tipos;
using DreamsHub.Repository.Interface;
using DreamsHub.Services.Interface;

namespace DreamsHub.Services;

public class TotalizarTransacoesService: ITotalizarTransacoesService
{
    private readonly ITransacaoRepository _transacaoRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public TotalizarTransacoesService(ITransacaoRepository transacaoRepository, ICategoriaRepository categoriaRepository)
    {
        _transacaoRepository = transacaoRepository;
        _categoriaRepository = categoriaRepository;
    }
    
    public TotalizadorMensalTransacaoesDto TotalizarTransacoesDoMes(int mes, int ano)
    {
        IQueryable<Transacao> transacoes = _transacaoRepository.GerarIqueryable()
            .Where(l=>l.Data.Date.Month == mes && l.Data.Date.Year == ano);

        return new TotalizadorMensalTransacaoesDto()
        {
            Despesas = transacoes.Where(l => l.Tipo == ETipoTransacao.Despesa).Sum(l => l.Valor),
            Receitas = transacoes.Where(l => l.Tipo == ETipoTransacao.Receita).Sum(l => l.Valor)
        };
    }

    public List<TotalizadorCategoriasDto> TotalizarCategoriasDoMes(int mes, int ano)
    {
        List<TotalizadorCategoriasDto> totalizadorCategoriasDtos = new List<TotalizadorCategoriasDto>();
        List<Transacao> transacaos = _transacaoRepository.GerarIqueryable()
            .Where(l=>l.Data.Date.Month == mes && l.Data.Date.Year == ano).ToList();

        DateTime dataMediaFinal = new DateTime(ano, mes, 1).AddMonths(-1);
        DateTime dataMediaInicial = dataMediaFinal.AddMonths(-6);

        IQueryable<Transacao> ultimosSeisMeses = _transacaoRepository.BuscarEntreDatas(dataMediaInicial, dataMediaFinal);
        
        foreach (Categoria categoria in _categoriaRepository.GerarIqueryable().ToList())
        {
            IQueryable<Transacao> ultimosSeisMesesPorCategoria = ultimosSeisMeses.Where(l => l.CategoriaId == categoria.Id);

            
            List<Transacao> list = ultimosSeisMesesPorCategoria.ToList();
            TotalizadorCategoriasDto totalizador = new()
            {
                Categoria = categoria,
                Total = transacaos.Where(l=>l.CategoriaId == categoria.Id).Sum(l=>l.Valor),
            };

            if (ultimosSeisMesesPorCategoria.Any())
            {
                List<decimal> listaAgrupada = new();
                for (DateTime data = dataMediaInicial; data.Date < dataMediaFinal.Date; data = data.AddMonths(1))
                {
                    listaAgrupada.Add(ultimosSeisMesesPorCategoria.Where(l=>l.Data.Month == data.Month && l.Data.Year == data.Year)
                        .Sum(l=>l.Valor));
                }
                totalizador.Media = listaAgrupada.Where(l=>l != 0)
                    .Average();
            }
                
            
            totalizadorCategoriasDtos.Add(totalizador);
        }

        return totalizadorCategoriasDtos.OrderByDescending(l=>l.Total).ToList();
    }

    public void GerarGraficoPorCategoria(int mes, int ano)
    {
        List<Transacao> transacaos = _transacaoRepository.GerarIqueryable()
            .Where(l=>l.Data.Date.Month == mes && l.Data.Date.Year == ano).ToList();

        List<decimal> teste = new List<decimal>();
        
        
    }
}