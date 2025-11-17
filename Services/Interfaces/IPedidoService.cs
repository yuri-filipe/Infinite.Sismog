using Sismog.ViewModels.Pedido;

namespace Sismog.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<List<ViewModelPedido>> ObterPedidos(string user);
        Task<ViewModelPedido> ObterDetalhesPedido(string user, long id);
        Task<List<ViewModelItemPedido>> ObterItensPedido(string user, long id);
        Task<string> ConcluirPedido(string user, long id);
    }
}