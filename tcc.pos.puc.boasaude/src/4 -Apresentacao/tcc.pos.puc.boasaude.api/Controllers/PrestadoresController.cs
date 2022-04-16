using Microsoft.AspNetCore.Mvc;
using tcc.pos.puc.boasaude.domain.Interface;
using tcc.pos.puc.boasaude.domain.Models;
using tcc.pos.puc.boasaude.domain.ModelView;

namespace tcc.pos.puc.boasaude.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrestadoresController : ControllerBase
    {
        private readonly IAssociadoService _service;
        public PrestadoresController(IAssociadoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Listar todos os Prestadores.
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar")]
        public async Task<IActionResult> ObterTodosAssociados()
        {
            var retorno = await _service.BuscarTodosAssociados();
            return Ok(retorno);
        }

        /// <summary>
        /// Buscar prestador por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("obter/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var retorno = await _service.BuscarPorId(id);
            return Ok(retorno);
        }

        /// <summary>
        /// Criar de Prestador.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AssociadoViewModel model)
        {
            var retorno = await _service.CriarAssociado(model);
            return Ok(retorno);
        }

        /// <summary>
        /// Atualizar Prestador.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] Associados model, Guid id)
        {
            var retorno = await _service.AtualizarAssociado(model, id);
            return Ok(retorno);
        }

        /// <summary>
        /// Desativar Prestador.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var retorno = await _service.Deletar(id);
            return Ok();
        }
    }
}
