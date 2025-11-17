using Sismog.Models;


namespace Sismog.Services.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> ObterClientes(string user);
        Task<string> InserirCliente(string user, Cliente cliente);
        Task<Cliente?> ObterCliente(string user, long id);
        Task<string> ExcluirCliente(string user, long id);
        Task<List<dynamic>>? BuscarCliente(string user, string nome);
    }
}