using Npgsql;
namespace Sismog.Services.Interfaces
{
    public interface IDatabaseService
    {
        NpgsqlConnection GetConnection(string user);
        NpgsqlConnection ConnectDatabase(string user, string password);
        List<string> GetRoles(string usuario);
        bool CloseConnection(string login);
    }
}