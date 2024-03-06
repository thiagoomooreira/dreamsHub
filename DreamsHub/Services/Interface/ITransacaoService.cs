using DreamsHub.Models;
using DreamsHub.Models.Dtos;

namespace DreamsHub.Services.Interface;

public interface ITransacaoService
{
    List<Transacao> BuscarTodos();
    Transacao BuscarPeloCodigo(int codigo);
    void AdicionarOuAtualizar(TransacaoDto transacao);
    void Excluir(int codigo);
}