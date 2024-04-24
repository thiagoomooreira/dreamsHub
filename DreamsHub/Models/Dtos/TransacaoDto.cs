using DreamsHub.Models.Context;
using DreamsHub.Models.Tipos;

namespace DreamsHub.Models.Dtos;

public class TransacaoDto
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public int Categoria { get; set; }
    public string Tipo { get; set; }
    public bool Status { get; set; }

    public TransacaoDto() { }

    public TransacaoDto(Transacao transacao)
    {
        this.Id = transacao.Id;
        this.Valor = transacao.Valor;
        this.Descricao = transacao.Descricao;
        this.Data = transacao.Data;
        this.Categoria = transacao.CategoriaId;
        this.Status = transacao.Status == EStatusTransacao.Efetuado;
        this.Tipo = transacao.Tipo.ToString();
    }
    
    public Transacao ConverterParaModel()
    {
        return new Transacao()
        {
            CategoriaId = this.Categoria,
            Categoria = null,
            Data = this.Data,
            Descricao = this.Descricao,
            Id = this.Id,
            Status = this.Status ? EStatusTransacao.Efetuado : EStatusTransacao.Pendente,
            Tipo = Enum.Parse<ETipoTransacao>(this.Tipo),
            Valor = this.Valor
        };
    }
}