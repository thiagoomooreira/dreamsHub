using DreamsHub.Models.Dtos;
using DreamsHub.Models.Tipos;
using DreamsHub.Repository.Interface;
using DreamsHub.Services.Interface;

namespace DreamsHub.Services;

public class TotalizarTransacoesService: ITotalizarTransacoesService
{
    private readonly ITransacaoRepository _transacaoRepository;

    public TotalizarTransacoesService(ITransacaoRepository transacaoRepository)
    {
        _transacaoRepository = transacaoRepository;
    }
    
    public TotalizadorMensalTransacaoesDto TotalizarTransacoesDoMes(int mes, int ano)
    {
        var transacoes = _transacaoRepository.GerarIqueryable()
            .Where(l=>l.Data.Date.Month == mes && l.Data.Date.Year == ano);

        return new TotalizadorMensalTransacaoesDto()
        {
            Despesas = transacoes.Where(l => l.Tipo == ETipoTransacao.Despesa).Sum(l => l.Valor),
            Receitas = transacoes.Where(l => l.Tipo == ETipoTransacao.Receita).Sum(l => l.Valor)
        };
    }
}