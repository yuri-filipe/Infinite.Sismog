using Sismog.Models;
using Sismog.ViewModels;


namespace Sismog.Services.Interfaces
{
    public interface IOrcamentoService
    {
        Task<ViewModelOrcamento> ObterOrcamento(string user, long id);
        Task<List<ViewModelOrcamento>> ObterOrcamentos(string user);
        Task<List<ViewModelVersaoOrcamento>> ObterVersoesOrcamento(string user, long IdOrcamento);
        Task<List<ViewModelItemVersaoOrcamento>> ObterItensVersoesOrcamento(string user, long IdVersaoOrcamento);
        Task<string> AdicionarOrcamento(string user, ViewModelOrcamento orcamento);
        Task<string> AdicionarVersaoOrcamento(string user, ViewModelOrcamento orcamento);
        Task<string> ExcluirOrcamento(string user, long id);
        Task<ViewModelOrcamento> ObterDetalhesOrcamento(string user, long id);

        Task<string> AprovarOrcamento(string user, long IdVersao);

    }
}