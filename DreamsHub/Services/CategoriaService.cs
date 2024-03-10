using DreamsHub.Models;
using DreamsHub.Models.Tipos;
using DreamsHub.Repository.Interface;
using DreamsHub.Services.Interface;

namespace DreamsHub.Services;

public class CategoriaService: ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    
    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }
    
    public List<Categoria> BuscarTodos(ETipoTransacao tipoTransacao)
    {
        return _categoriaRepository.GerarIqueryable().Where(l => l.Tipo == tipoTransacao).ToList();
    }
}