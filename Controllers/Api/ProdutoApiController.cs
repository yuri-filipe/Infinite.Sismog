using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sismog.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sismog.Controllers.Api
{
    [Authorize]
    [Route("api/produto/")]
    [ApiController]
    public class ProdutoApiController : CustomController
    {
        private static IOrcamentoService _orcamentoService;
        private static IProdutoService _produtoService;

        public ProdutoApiController(IOrcamentoService orcamentoService, IProdutoService produtoService)
        {
            _orcamentoService = orcamentoService;
            _produtoService = produtoService;
        }
        [HttpGet]
        [Route("obterprodutospornome")]
        public async Task<IActionResult> ObterProdutosPorNome(string nome)
        {
            string user = User.Identity.Name;
            var result = await _produtoService.ObterProdutosPorNome(user, nome);

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
