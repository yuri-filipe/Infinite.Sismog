using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sismog.Services.Interfaces;
using Sismog.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sismog.Controllers.Api
{
    [Authorize]
    [Route("api/orcamento/")]
    [ApiController]
    public class OrcamentoApiController : CustomController
    {
        private static IOrcamentoService _orcamentoService;
        private static IProdutoService _produtoService;
        private static IClienteService _clienteService;

        public OrcamentoApiController(IOrcamentoService orcamentoService, IProdutoService produtoService, IClienteService clienteService)
        {
            _orcamentoService = orcamentoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
        }
        [HttpPost]
        [Route("adicionar-orcamento")]
        public async Task<IActionResult> AdicionarOrcamento([FromBody] ViewModelOrcamento orcamento)
        {
            string user = User.Identity.Name;
            var result = await _orcamentoService.AdicionarOrcamento(user, orcamento);
            try
            {
                return result == "success" ? Ok("Orçamento adicionado com sucesso") : BadRequest(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("adicionar-versao-orcamento")]
        public async Task<IActionResult> AdicionarVersaoOrcamento([FromBody] ViewModelOrcamento orcamento)
        {
            string user = User.Identity.Name;
            var result = await _orcamentoService.AdicionarVersaoOrcamento(user, orcamento);
            try
            {
                return result == "success" ? Ok("Versão adicionada com sucesso") : BadRequest(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("aprovar-orcamento")]
        public async Task<IActionResult> AprovarOrcamento(long id)
        {
            string user = User.Identity.Name;
            var result = await _orcamentoService.AprovarOrcamento(user, id);
            try
            {
                return result == "success" ? Ok(result) : BadRequest(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
