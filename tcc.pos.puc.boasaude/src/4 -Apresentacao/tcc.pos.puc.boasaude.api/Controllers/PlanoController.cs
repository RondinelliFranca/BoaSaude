using Microsoft.AspNetCore.Mvc;
using tcc.pos.puc.boasaude.domain.Interface;
using tcc.pos.puc.boasaude.domain.Models;

namespace tcc.pos.puc.boasaude.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanoController : ControllerBase
    {
        private readonly IPlanoService _service;
        public PlanoController(IPlanoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Listar planos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterTodosPlanos")]
        public async Task<IActionResult> ObterTodosPlanos()
        {
            var retorno = await _service.ObterSituacoesPlanos();
            return Ok(retorno);
        }

        /// <summary>
        /// Buscar plano por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ObterPlanoPorId")]
        public async Task<IActionResult> ObterTodosPlanos(Guid id)
        {
            var retorno = await _service.ObterSituacoesPlanos();
            return Ok(retorno);
        }

        /// <summary>
        /// Listar tipos de planos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterTiposPlano")]
        public async Task<IActionResult> ObterTiposPlano()
        {
            var retorno = await _service.ObterSituacoesPlanos();
            return Ok(retorno);
        }

        /// <summary>
        /// Criar Planos
        /// </summary>
        /// <param name="plano"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Plano plano)
        {
            var retorno = await _service.Criar(plano);
            return Ok(retorno);
        }
        /// <summary>
        /// Atualizar Plano.
        /// </summary>
        /// <param name="plano"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Plano plano)
        {
            var retorno = await _service.Criar(plano);
            return Ok(retorno);
        }
    }
}
