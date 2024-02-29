using DreamsHub.Models;

namespace DreamsHub.Dao.Interface;

public interface ITransacaoDao
{
    public List<Transacao> BuscarTodos();
}