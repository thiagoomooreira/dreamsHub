using DreamsHub.Models;

namespace DreamsHub.Dao.Interface;

public interface ICategoriaRepository
{
    public List<Categoria> BuscarTodos();
}