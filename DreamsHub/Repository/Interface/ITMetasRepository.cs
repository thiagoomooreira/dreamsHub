using DreamsHub.Models.Context;

namespace DreamsHub.Repository.Interface;

public interface ITMetasRepository : IRepositoryBase<Metas>
{
    IQueryable<MovimentacaoMeta> MovimentacaoMetas();
}