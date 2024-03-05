using DreamsHub.Context;
using DreamsHub.Repository.Interface;

namespace DreamsHub.Repository
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T: class
    {
        protected readonly ContextModel Db;

        public RepositoryBase(ContextModel db)
        {
            this.Db = db;
        }
        
        protected void SaveChanges()
        {
            Db.SaveChanges();
        }
        
        public virtual T AdicionarOuAtualizar(T model)
        {
            Db.Set<T>().Update(model);
            SaveChanges();

            return model;
        }

        public void Excluir(T model)
        {
            Db.Set<T>().Remove(model);
            SaveChanges();        
        }

        public IQueryable<T> GerarIqueryable()
        {
            return Db.Set<T>();
        }

        public T BuscarPeloCodigo(int codigo)
        {
            return Db.Set<T>().Find(codigo);
        }
    }
}