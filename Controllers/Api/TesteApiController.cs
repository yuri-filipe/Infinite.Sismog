using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sismog.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sismog.Controllers.Api
{
    [Authorize]
    [Route("api/teste/")]
    [ApiController]
    public class TesteApiController : CustomController
    {
        private static IOrcamentoService _orcamentoService;
        private static IProdutoService _produtoService;
        private static IClienteService _clienteService;

        public TesteApiController(IOrcamentoService orcamentoService, IProdutoService produtoService, IClienteService clienteService)
        {
            _orcamentoService = orcamentoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
        }
        [HttpGet("temporequisicao")]
        public IActionResult TempoRequisicao(long segundos)
        {
            _ = User.Identity.Name;

            Thread.Sleep((int)segundos * 1000);

            return Ok($@"A requisição com o tempo de {segundos} segundos chegou ao fim !");
        }

    }
}
