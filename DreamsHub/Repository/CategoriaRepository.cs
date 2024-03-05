using DreamsHub.Dao.Interface;
using DreamsHub.Models;
using DreamsHub.Models.Tipos;

namespace DreamsHub.Dao;

public class CategoriaRepository : ICategoriaRepository
{
    private static List<Categoria> _listaDeCategorias = new List<Categoria>();

    public CategoriaRepository()
    {
        _listaDeCategorias = new List<Categoria>()
        {
            new()
            {
                Id = 1,
                Descricao = "Financiamento",
                Cor = ECoresCategoria.Azul
            },
            new()
            {
                Id = 2,
                Descricao = "Lazer",
                Cor = ECoresCategoria.Azul
            },
            new()
            {
                Id = 3,
                Descricao = "Transporte",
                Cor = ECoresCategoria.Azul
            },
            new()
            {
                Id = 3,
                Descricao = "Outras",
                Cor = ECoresCategoria.Azul
            }
        };   
    }
    
    public List<Categoria> BuscarTodos()
    {
        return _listaDeCategorias;
    }
}