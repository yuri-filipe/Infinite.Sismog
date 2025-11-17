using Npgsql;
using Sismog.Services.Interfaces;
using System.Data;
using System.Security.Authentication;

namespace Sismog.Services
{
    public class DatabaseService : IDatabaseService
    {
        private static readonly Dictionary<string, NpgsqlConnection> Connections = [];

        private readonly IConfiguration _configuration;
        private readonly ILogger<DatabaseService> _logger;

        // Construtor atualizado para usar injeção de dependências
        public DatabaseService(IConfiguration configuration, ILogger<DatabaseService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public NpgsqlConnection GetConnection(string user)
        {
            if (Connections.ContainsKey(user.Trim().ToLower()))
            {
                var connection = Connections[user];
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return connection;
            }
            throw new AuthenticationException($"Usuário {user} não está autenticado no sistema!");
        }

        public NpgsqlConnection ConnectDatabase(string user, string password)
        {
            try
            {
                var baseConnection = _configuration.GetConnectionString("PostgresConnection");

                var builder = new NpgsqlConnectionStringBuilder(baseConnection)
                {
                    Username = user,
                    Password = password,
                    ApplicationName = "Sismog"
                };

                NpgsqlConnection connection = new NpgsqlConnection(builder.ConnectionString);

                connection.Open();

                if (Connections.ContainsKey(user.Trim().ToLower()))
                {
                    connection = Connections[user];
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    return connection;
                }

                Connections.Add(user, connection);

                return connection;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new AuthenticationException();
            }
        }

        public List<string> GetRoles(string user)
        {
            var connection = GetConnection(user);

            var sql = $@"SELECT r.rolname
                         FROM pg_catalog.pg_roles r 
                         INNER JOIN pg_catalog.pg_auth_members m ON m.roleid = r.oid
                         WHERE m.member = (SELECT rol.oid FROM pg_catalog.pg_roles rol WHERE rol.rolname = '{user}')";

            var command = new NpgsqlCommand(sql, connection);

            try
            {
                var reader = command.ExecuteReader();

                var roles = new List<string>();

                while (reader.Read())
                {
                    roles.Add(reader.GetString(0));
                }
                return roles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new AuthenticationException();
            }
            finally
            {
                connection.Close();
            }
        }

        public bool CloseConnection(string login)
        {
            return Connections.ContainsKey(login) && Connections.Remove(login);
        }
    }
}
