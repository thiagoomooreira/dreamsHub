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

    public List<Transacao> BuscarTodos()
    {
        var transacaos = _transacaoRepository.BuscarTodos().ToList();

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