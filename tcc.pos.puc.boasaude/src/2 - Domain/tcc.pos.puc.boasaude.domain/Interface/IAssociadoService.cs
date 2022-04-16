using tcc.pos.puc.boasaude.domain.Models;
using tcc.pos.puc.boasaude.domain.ModelView;

namespace tcc.pos.puc.boasaude.domain.Interface;

public interface IAssociadoService
{
    Task<List<Associados>> BuscarTodosAssociados();
    Task<bool> AtualizarAssociado(Associados associado, Guid id);
    Task<bool> CriarAssociado(AssociadoViewModel associado);
    Task<Associados> BuscarPorId(Guid id);
    Task<bool> Deletar(Guid id);
}
