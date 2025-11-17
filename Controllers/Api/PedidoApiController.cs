using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sismog.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sismog.Controllers.Api
{
    [Authorize]
    [Route("api/pedido")]
    [ApiController]
    public class PedidoApiController : CustomController
    {
        private static IOrcamentoService _orcamentoService;
        private static IProdutoService _produtoService;
        private static IClienteService _clienteService;
        private static IPedidoService _pedidoService;


        public PedidoApiController(IOrcamentoService orcamentoService, IProdutoService produtoService, IClienteService clienteService, IPedidoService pedidoService)

        {
            _orcamentoService = orcamentoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _pedidoService = pedidoService;

        }
        [HttpGet]
        [Route("concluirpedido")]
        public async Task<IActionResult> ConcluirPedido(long id)
        {
            string user = User.Identity.Name;
            var result = await _pedidoService.ConcluirPedido(user, id);

            return result != "success" ? NotFound(result) : Ok(result);
        }


    }
}
