using DreamsHub.Models.Dtos;

namespace DreamsHub.Services.Interface;

public interface ITotalizarTransacoesService
{
    TotalizadorMensalTransacaoesDto TotalizarTransacoesDoMes(int mes, int ano);
}