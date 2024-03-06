using DreamsHub.Models;
using DreamsHub.Models.Dtos;
using DreamsHub.Models.Tipos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DreamsHub.ViewModels;

public class AdicionarTransacaoViewModel
{
    public TransacaoDto Transacao { get; set; }
    public List<Categoria> Categorias { get; set; }

    public AdicionarTransacaoViewModel()
    {
        this.Transacao = new TransacaoDto();
    }
    
    public AdicionarTransacaoViewModel(ETipoTransacao tipo)
    {
        this.Transacao = new TransacaoDto
        {
            Tipo = tipo.ToString(),
            Data = DateTime.Now,
            Status = true
        };
    }
    
    public SelectList CategoriasDropdown()
    {
        List<SelectListItem> list = new List<SelectListItem>
        {
            
        };
        
        foreach (Categoria categoria in this.Categorias)
            list.Add(new SelectListItem()
            {
                Text = categoria.Descricao,
                Value = categoria.Id.ToString()
            });
        
        return new SelectList(list, "Value", "Text", "andamento");
    }
}