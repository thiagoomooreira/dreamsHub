namespace DreamsHub.Repository.Interface
{
    public interface IRepositoryBase<T> where T: class
    {
        T AdicionarOuAtualizar(T model);
        void Excluir(T model);
        IQueryable<T> GerarIqueryable();
        T BuscarPeloCodigo(int codigo);
    }
}