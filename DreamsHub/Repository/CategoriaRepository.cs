using DreamsHub.Context;
using DreamsHub.Models;
using DreamsHub.Models.Tipos;
using DreamsHub.Repository.Interface;

namespace DreamsHub.Repository;

public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(ContextModel db) : base(db){}
}