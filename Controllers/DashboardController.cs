using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sismog.Services.Interfaces;

namespace Sismog.Controllers
{
    [Authorize]
    public class DashboardController : CustomController
    {
        private static IPedidoService _pedidoService;
        private static IRelatoriosService _relatoriosService;
        public DashboardController(IPedidoService pedidoService, IRelatoriosService relatoriosService)
        {
            _relatoriosService = relatoriosService;
            _pedidoService = pedidoService;
        }

        public async Task<IActionResult> Index()
        {
            string user = User.Identity.Name;
            var pedidos = await _relatoriosService.ObterRelatorioGeral(user);
            return View(pedidos);
        }

    }
}
