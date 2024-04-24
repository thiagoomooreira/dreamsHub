using DreamsHub.Models;
using DreamsHub.Models.Context;
using DreamsHub.Models.Dtos;

namespace DreamsHub.ViewModels;

public class TransacaoViewModel
{
    public List<Transacao> Transacoes { get; set; }
    public TotalizadorMensalTransacaoesDto TotalizadorMensal { get; set; }
    public DateTime Data { get; set; }
}