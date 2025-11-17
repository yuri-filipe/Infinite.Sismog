using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Sismog.Models;
using Sismog.Services.Interfaces;

namespace Sismog.Controllers
{
    [Authorize]
    public class ClienteController : CustomController
    {
        private static IOrcamentoService _orcamentoService;
        private static IProdutoService _produtoService;
        private static IClienteService _clienteService;
        private static IPedidoService _pedidoService;


        public ClienteController(IOrcamentoService orcamentoService, IProdutoService produtoService, IClienteService clienteService, IPedidoService pedidoService)

        {
            _orcamentoService = orcamentoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _pedidoService = pedidoService;

        }

        public async Task<IActionResult> Index()
        {
            string user = User.Identity.Name;
            var clientes = await _clienteService.ObterClientes(user);
            return View(clientes);
        }

        public async Task<IActionResult> Details(long id)
        {
            string user = User.Identity.Name;
            var cliente = await _clienteService.ObterCliente(user, id);

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            string user = User.Identity.Name;
            var result = await _clienteService.InserirCliente(user, cliente);
            return result != "success" ? NotFound() : RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(long id)
        {
            string user = User.Identity.Name;
            var cliente = await _clienteService.ObterCliente(user, id);
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            string user = User.Identity.Name;
            var result = await _clienteService.ExcluirCliente(user, id);
            return result != "success" ? NotFound() : RedirectToAction(nameof(Index));
        }

    }
}
