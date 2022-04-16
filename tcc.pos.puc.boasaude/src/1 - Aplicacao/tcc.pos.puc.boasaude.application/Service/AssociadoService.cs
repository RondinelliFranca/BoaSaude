using tcc.pos.puc.boasaude.domain.Interface;
using tcc.pos.puc.boasaude.domain.Models;
using tcc.pos.puc.boasaude.domain.ModelView;

namespace tcc.pos.puc.boasaude.application.Service;

public class AssociadoService : IAssociadoService
{
    private readonly IBoaSaudeRepository _repository;
    public AssociadoService(IBoaSaudeRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Associados>> BuscarTodosAssociados()
    {
        return await _repository.BuscarAssociadosAsync();
    }

    public async Task<bool> AtualizarAssociado(Associados associado, Guid id)
    {
        return await _repository.AtualizarAssociadosAsync(associado, id);
    }

    public async Task<bool> CriarAssociado(AssociadoViewModel associado)
    {
        return await _repository.CriarAssociadosAsync(associado);
    }

    public async Task<Associados> BuscarPorId(Guid id)
    {
        return await _repository.BuscarAssociadosPorIdAsync(id);
    }

    public async Task<bool> Deletar(Guid id)
    {
        return await _repository.DeletarAssociadoAsync(id);
    }
}