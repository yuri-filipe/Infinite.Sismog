using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sismog.Services.Interfaces;

namespace Sismog.Controllers
{
    [Authorize]
    public class PedidoController : CustomController
    {
        private static IOrcamentoService _orcamentoService;
        private static IProdutoService _produtoService;
        private static IClienteService _clienteService;
        private static IPedidoService _pedidoService;


        public PedidoController(IOrcamentoService orcamentoService, IProdutoService produtoService, IClienteService clienteService, IPedidoService pedidoService)

        {
            _orcamentoService = orcamentoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _pedidoService = pedidoService;

        }

        public async Task<IActionResult> Index()
        {
            string user = User.Identity.Name;
            var pedidos = await _pedidoService.ObterPedidos(user);
            return View(pedidos);
        }

        public async Task<IActionResult> Details(long id)
        {
            string user = User.Identity.Name;
            var pedido = await _pedidoService.ObterDetalhesPedido(user, id);
            pedido.Itens = await _pedidoService.ObterItensPedido(user, id);

            return View(pedido);
        }

        public async Task<IActionResult> Delete(long id)
        {
            string user = User.Identity.Name;
            var pedido = await _pedidoService.ObterDetalhesPedido(user, id);

            return View(pedido);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            // string user = User.Identity.Name;
            // var result = await _pedidoService.(user, id);
            // if (result != "success")
            // {
            //     return NotFound();
            // }
            return RedirectToAction(nameof(Index));
        }
    }
}
