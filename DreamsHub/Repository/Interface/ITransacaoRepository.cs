using DreamsHub.Models;

namespace DreamsHub.Repository.Interface;

public interface ITransacaoRepository: IRepositoryBase<Transacao>
{
    public List<Transacao> BuscarTodos();
}