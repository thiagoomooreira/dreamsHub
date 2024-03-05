using DreamsHub.Context;
using DreamsHub.Models;
using DreamsHub.Repository.Interface;

namespace DreamsHub.Repository;

public class TransacaoRepository: RepositoryBase<Transacao>, ITransacaoRepository
{
    private static List<Transacao> _listaDeTransacoes = new List<Transacao>();

    public TransacaoRepository(ContextModel db) : base(db){}
    
    public List<Transacao> BuscarTodos()
    {
        return _listaDeTransacoes;
    }
}