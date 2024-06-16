using DreamsHub.Models;
using DreamsHub.Models.Context;

namespace DreamsHub.Repository.Interface;

public interface ITransacaoRepository: IRepositoryBase<Transacao>
{
    public IQueryable<Transacao> BuscarTodos();
    public IQueryable<Transacao> BuscarEntreDatas(DateTime dataInicial, DateTime dataFinal);
}