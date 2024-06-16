using DreamsHub.Models;
using DreamsHub.Models.Context;
using DreamsHub.Models.Dtos;
using DreamsHub.Repository.Interface;
using DreamsHub.Services.Interface;

namespace DreamsHub.Services;

public class TransacaoService: ITransacaoService
{
    private readonly ITransacaoRepository _transacaoRepository;
    
    public TransacaoService(ITransacaoRepository transacaoRepository)
    {
        _transacaoRepository = transacaoRepository;
    }

    public IQueryable<Transacao> BuscarTodos()
    {
        IQueryable<Transacao> transacaos = _transacaoRepository.BuscarTodos();
        
        return transacaos;
    }
    
    public IQueryable<Transacao> BuscarTodos(FiltroTransacao filtro)
    {
        var transacaos = this.BuscarTodos();

        transacaos = transacaos.Where(l => l.Data >= filtro.DataInicial && l.Data <= filtro.DataFinal);
        
        return transacaos;
    }

    public Transacao BuscarPeloCodigo(int codigo)
    {
        return _transacaoRepository.BuscarTodos().FirstOrDefault(l => l.Id == codigo) 
               ?? throw new Exception("Transação não encontrada!");
    }

    public void AdicionarOuAtualizar(TransacaoDto transacao)
    {
        Transacao transacaoPrincipal = transacao.ConverterParaModel();
        List<Transacao> converterParaModel = new()
        {
            transacaoPrincipal
        };
        
        if (transacao.Parcelas > 1)
        {
            transacaoPrincipal.Descricao = $"{transacaoPrincipal.Descricao} (1x)"; 
            for (int i = 2; i <= transacao.Parcelas; i++)
            {
                Transacao parcela = transacao.ConverterParaModel();
                parcela.Data = parcela.Data.AddMonths(i-1);
                parcela.Descricao = $"{parcela.Descricao} ({i}x)"; 
                converterParaModel.Add(parcela);
            }
        }

        foreach (Transacao item in converterParaModel)
            _transacaoRepository.AdicionarOuAtualizar(item);
    }

    public void Excluir(int codigo)
    {
        Transacao buscarPeloCodigo = this.BuscarPeloCodigo(codigo);


        _transacaoRepository.Excluir(buscarPeloCodigo);
    }

    public IQueryable<Transacao> BuscarPorCategoriaPorMes(int categoriaId, DateTime data)
    {
        return this.BuscarTodos().Where(l => l.CategoriaId == categoriaId &&
                                             l.Data.Month == data.Month &&
                                             l.Data.Year == data.Year);
    }
}