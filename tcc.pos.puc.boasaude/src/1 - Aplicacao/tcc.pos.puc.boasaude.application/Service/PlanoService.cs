using tcc.pos.puc.boasaude.domain.Interface;
using tcc.pos.puc.boasaude.domain.Models;

namespace tcc.pos.puc.boasaude.application.Service;

public class PlanoService : IPlanoService
{
    private readonly IBoaSaudeRepository _repository;
    public PlanoService(IBoaSaudeRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<SituacaoPlano>> ObterSituacoesPlanos()
    {
        return await _repository.BuscarSituacaoPlanoAsync();
    }

    public async Task<IEnumerable<TipoPlano>> ObterTiposPlano()
    {
        return await _repository.BuscarTipoPlanosAsync();
    }

    public Task<TipoPlano> ObterPorId()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Criar(Plano plano)
    {
        return await _repository.Criar(plano);
    }

    public Task<bool> Atualizar(Plano plano)
    {
        throw new NotImplementedException();
    }
}