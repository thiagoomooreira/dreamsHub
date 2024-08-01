using DreamsHub.Models.Context;
using DreamsHub.Models.Dtos;
using DreamsHub.Repository.Interface;
using DreamsHub.Services.Interface;

namespace DreamsHub.Services;

public class MetasServices: IMetasService
{
    private readonly ITMetasRepository _metasRepository;
    
    public MetasServices(ITMetasRepository metasRepository)
    {
        _metasRepository = metasRepository;
    }

    public List<Metas> BuscarTodos()
    {
        List<Metas> metasList = _metasRepository.GerarIqueryable().ToList();

        return metasList;
    }

    public List<TotalizacaoMetas> TotalizacaoMetas()
    {
        IQueryable<TotalizacaoMetas> totalizacaoMetasEnumerable = from m in _metasRepository.GerarIqueryable()
            let mov = _metasRepository.MovimentacaoMetas().Where(l=>l.MetasId == m.Id).ToList()
            select new TotalizacaoMetas()
            {
                Id = m.Id,
                Descricao = m.Descricao,
                Meta = m.ValorTotal,
                Valor = mov.Select(l => l.Valor).Sum()
            };

        return totalizacaoMetasEnumerable.ToList();
    }
}