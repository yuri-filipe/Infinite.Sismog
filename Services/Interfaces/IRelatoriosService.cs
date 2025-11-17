using Sismog.ViewModels.Relatorios;

namespace Sismog.Services.Interfaces
{
    public interface IRelatoriosService
    {
        Task<Dashboard> ObterRelatorioGeral(string user);
    }
}