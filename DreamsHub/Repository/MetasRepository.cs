using DreamsHub.Context;
using DreamsHub.Models.Context;
using DreamsHub.Repository.Interface;

namespace DreamsHub.Repository;

public class MetasRepository: RepositoryBase<Metas>, ITMetasRepository
{
    public MetasRepository(ContextModel db) : base(db){}

    public IQueryable<MovimentacaoMeta> MovimentacaoMetas()
    {
        return Db.MovimentacaoMetas;
    }
}