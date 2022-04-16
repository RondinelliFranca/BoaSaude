using tcc.pos.puc.boasaude.domain.Models;

namespace tcc.pos.puc.boasaude.domain.Interface;

public interface IPlanoService
{
    Task<IEnumerable<SituacaoPlano>> ObterSituacoesPlanos();
    Task<IEnumerable<TipoPlano>> ObterTiposPlano();
    Task<TipoPlano> ObterPorId();
    Task<bool> Criar(Plano plano);
    Task<bool> Atualizar(Plano plano);
}