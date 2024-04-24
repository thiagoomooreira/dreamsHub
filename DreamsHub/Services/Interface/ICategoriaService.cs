using DreamsHub.Models;
using DreamsHub.Models.Context;
using DreamsHub.Models.Tipos;

namespace DreamsHub.Services.Interface;

public interface ICategoriaService
{
    List<Categoria> BuscarTodos(ETipoTransacao tipoTransacao);
}