using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sismog.Services.Interfaces;
using Sismog.ViewModels.Orcamento;


namespace Sismog.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrcamentoController : CustomController
    {
        private static IOrcamentoService _orcamentoService;
        private static IProdutoService _produtoService;
        private static IClienteService _clienteService;
        private static IPedidoService _pedidoService;


        public OrcamentoController(IOrcamentoService orcamentoService, IProdutoService produtoService, IClienteService clienteService, IPedidoService pedidoService)

        {
            _orcamentoService = orcamentoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _pedidoService = pedidoService;

        }
        public async Task<IActionResult> Index()
        {
            string user = User.Identity.Name;

            var orcamentos = await _orcamentoService.ObterOrcamentos(user);

            foreach (var orcamento in orcamentos)
            {
                orcamento.Versoes = await _orcamentoService.ObterVersoesOrcamento(user, orcamento.IdOrcamento);
                foreach (var versao in orcamento.Versoes)
                {
                    versao.Itens = await _orcamentoService.ObterItensVersoesOrcamento(user, versao.IdVersaoOrcamento);
                }
            }

            return View(orcamentos);
        }

        public async Task<IActionResult> Details(long id)
        {
            string user = User.Identity.Name;
            ViewModelOrcamento orcamento = await _orcamentoService.ObterDetalhesOrcamento(user, id);

            orcamento.Versoes = await _orcamentoService.ObterVersoesOrcamento(user, orcamento.IdOrcamento);

            foreach (var versao in orcamento.Versoes)
            {
                versao.Itens = await _orcamentoService.ObterItensVersoesOrcamento(user, versao.IdVersaoOrcamento);
            }
            orcamento.FormaDePagamento = orcamento.Versoes[0].FormaDePagamento;

            return orcamento == null ? RedirectToAction(nameof(Index)) : View(orcamento);
        }

        // GET: Orcamentos/Create
        public async Task<IActionResult> Create()
        {
            string user = User.Identity.Name;
            ViewBag.ListaProdutos = await _produtoService.ObterProdutos(user);
            ViewBag.IdTabela = "TabelaProdutosOrcamento";

            return View();
        }

        // GET: Orcamentos/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            string user = User.Identity.Name;
            ViewBag.ListaProdutos = await _produtoService.ObterProdutos(user);
            ViewBag.IdTabela = "TabelaProdutosOrcamento";

            ViewModelOrcamento orcamento = await _orcamentoService.ObterDetalhesOrcamento(user, id);

            return View(orcamento);
        }

        public async Task<IActionResult> Delete(long id)
        {
            string user = User.Identity.Name;
            var orcamento = await _orcamentoService.ObterOrcamento(user, id);
            return View(orcamento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            string user = User.Identity.Name;
            var result = await _orcamentoService.ExcluirOrcamento(user, id);
            return result != "success" ? NotFound() : RedirectToAction(nameof(Index));
        }

    }
}
