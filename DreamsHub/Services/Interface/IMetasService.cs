using DreamsHub.Models.Context;
using DreamsHub.Models.Dtos;

namespace DreamsHub.Services.Interface;

public interface IMetasService
{
    List<Metas> BuscarTodos();
    List<TotalizacaoMetas> TotalizacaoMetas();
}