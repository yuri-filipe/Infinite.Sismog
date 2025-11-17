using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sismog.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sismog.Controllers.Api
{
    [Authorize]
    [Route("api/cliente/")]
    [ApiController]
    public class ClienteApiController : CustomController
    {
        private static IOrcamentoService _orcamentoService;
        private static IProdutoService _produtoService;
        private static IClienteService _clienteService;

        public ClienteApiController(IOrcamentoService orcamentoService, IProdutoService produtoService, IClienteService clienteService)
        {
            _orcamentoService = orcamentoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
        }
        [HttpGet]
        [Route("buscarclientepornome")]
        public async Task<IActionResult> BuscarClientePorNome(string nome)
        {
            string user = User.Identity.Name;
            var result = await _clienteService.BuscarCliente(user, nome);

            return result == null ? NotFound() : Ok(result);
        }
        [HttpGet]
        [Route("obterdadosproduto")]
        public async Task<IActionResult> ObterDadosProdutosPorId(long id)
        {

            string user = User.Identity.Name;
            var result = await _produtoService.ObterDadosProdutosPorId(user, id);

            return result == null ? NotFound() : (IActionResult)Ok(result);
        }


    }
}
