using DreamsHub.Models.Dtos;

namespace DreamsHub.Services.Interface;

public interface ITotalizarTransacoesService
{
    TotalizadorMensalTransacaoesDto TotalizarTransacoesDoMes(int mes, int ano);
    List<TotalizadorCategoriasDto> TotalizarCategoriasDoMes(int mes, int ano);
}