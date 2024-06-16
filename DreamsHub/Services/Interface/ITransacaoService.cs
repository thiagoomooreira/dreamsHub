using DreamsHub.Models;
using DreamsHub.Models.Context;
using DreamsHub.Models.Dtos;

namespace DreamsHub.Services.Interface;

public interface ITransacaoService
{
    IQueryable<Transacao> BuscarTodos();
    IQueryable<Transacao> BuscarTodos(FiltroTransacao filtro);
    Transacao BuscarPeloCodigo(int codigo);
    void AdicionarOuAtualizar(TransacaoDto transacao);
    void Excluir(int codigo);
    IQueryable<Transacao> BuscarPorCategoriaPorMes(int categoriaId, DateTime data);
}