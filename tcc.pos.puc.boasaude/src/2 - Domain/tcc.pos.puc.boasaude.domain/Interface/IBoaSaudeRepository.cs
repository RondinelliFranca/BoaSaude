using tcc.pos.puc.boasaude.domain.Models;
using tcc.pos.puc.boasaude.domain.ModelView;

namespace tcc.pos.puc.boasaude.domain.Interface
{
    public interface IBoaSaudeRepository
    {
        Task<List<TipoPlano>> BuscarTipoPlanosAsync();
        Task<List<SituacaoPlano>> BuscarSituacaoPlanoAsync();
        Task<bool> Criar(Plano plano);

        Task<List<Associados>> BuscarAssociadosAsync();
        Task<Associados> BuscarAssociadosPorIdAsync(Guid id);
        Task<bool> CriarAssociadosAsync(AssociadoViewModel associados);
        Task<bool> AtualizarAssociadosAsync(Associados associados, Guid idAssociado);
        Task<bool> DeletarAssociadoAsync(Guid idAssociado);

    }
}
