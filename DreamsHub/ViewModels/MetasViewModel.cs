using DreamsHub.Models.Context;

namespace DreamsHub.ViewModels;

public class MetasViewModel
{
    public List<Metas> Metas { get; set; }
    public List<MovimentacaoMeta> Movimentacoes { get; set; }
    public Metas Meta { get; set; }
}