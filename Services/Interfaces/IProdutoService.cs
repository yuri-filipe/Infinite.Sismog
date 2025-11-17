using Sismog.Models;

namespace Sismog.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<List<Produto>> ObterProdutos(string user);
        Task<List<dynamic>?> ObterProdutosPorNome(string user, string nome);
        Task<dynamic> ObterDadosProdutosPorId(string user, long idProduto);
    }
}