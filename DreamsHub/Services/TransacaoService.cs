using DreamsHub.Models;
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
        Transacao converterParaModel = transacao.ConverterParaModel();

        _transacaoRepository.AdicionarOuAtualizar(converterParaModel);
    }

    public void Excluir(int codigo)
    {
        Transacao buscarPeloCodigo = this.BuscarPeloCodigo(codigo);


        _transacaoRepository.Excluir(buscarPeloCodigo);
    }
}