using DreamsHub.Dao.Interface;
using DreamsHub.Models;
using DreamsHub.Models.Tipos;

namespace DreamsHub.Dao;

public class TransacaoDao: ITransacaoDao
{
    private static List<Transacao> _listaDeTransacoes = new List<Transacao>();

    public TransacaoDao()
    {
        _listaDeTransacoes = new List<Transacao>()
        {
            new Transacao()
            {
                Id = 1,
                Descricao = "Financiamento",
                Valor = 100,
                Status = EStatusTransacao.Efetuado,
                Categoria = new Categoria()
                {
                    Id = 1,
                    Descricao = "Outros",
                    Cor = ECoresCategoria.Azul
                },
                Data = DateTime.Now,
                Tipo = ETipoTransacao.Despesa
            },
            new Transacao()
            {
                Id = 2,
                Descricao = "Combustivel",
                Valor = 67,
                Categoria = new Categoria()
                {
                    Id = 1,
                    Descricao = "Transporte",
                    Cor = ECoresCategoria.Vermelho
                },
                Data = DateTime.Now.AddDays(-1),
                Status = EStatusTransacao.Efetuado,
                Tipo = ETipoTransacao.Despesa
            },
            new Transacao()
            {
                Id = 3,
                Descricao = "Salário",
                Valor = new decimal(800.30),
                Categoria = new Categoria()
                {
                    Id = 1,
                    Descricao = "Salário",
                    Cor = ECoresCategoria.Azul
                },
                Data = DateTime.Now.AddDays(+1),
                Status = EStatusTransacao.Pendente,
                Tipo = ETipoTransacao.Receita
            }
        };
    }
    
    public List<Transacao> BuscarTodos()
    {
        return _listaDeTransacoes;
    }
}