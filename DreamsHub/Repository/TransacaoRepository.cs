using DreamsHub.Context;
using DreamsHub.Models;
using DreamsHub.Models.Context;
using DreamsHub.Repository.Interface;

namespace DreamsHub.Repository;

public class TransacaoRepository: RepositoryBase<Transacao>, ITransacaoRepository
{
    public TransacaoRepository(ContextModel db) : base(db){}
    
    public IQueryable<Transacao> BuscarTodos()
    {
        return (from t in this.GerarIqueryable()
            join c in Db.Categorias on t.CategoriaId equals c.Id
            select new Transacao()
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Categoria = c,
                CategoriaId = t.CategoriaId,
                Data = t.Data,
                Status = t.Status,
                Tipo = t.Tipo,
                Valor = t.Valor
            });
    }
    
    public IQueryable<Transacao> BuscarEntreDatas(DateTime dataInicial, DateTime dataFinal)
    {
        return this.GerarIqueryable().Where(l => l.Data >= dataInicial && l.Data <= dataFinal);
    }
}