using Npgsql;
using Sismog.Models;
using Sismog.Services.Interfaces;

namespace Sismog.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IDatabaseService _databaseService;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(IDatabaseService databaseService, ILogger<ClienteService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<List<Cliente>> ObterClientes(string user)
        {
            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT * FROM cadastro.cliente";
            var command = new NpgsqlCommand(sql, connection);

            try
            {
                var reader = await command.ExecuteReaderAsync();
                var clientes = new List<Cliente>();
                while (reader.Read())
                {
                    var cliente = new Cliente
                    {
                        IdCliente = reader.GetInt32(0),
                        Nome = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Cpf = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Rg = reader.IsDBNull(3) ? string.Empty : reader.GetString(2),
                        Tipo = reader.IsDBNull(4) ? 0 : reader.GetInt64(4),
                        Nascimento = reader.IsDBNull(5) ? null : reader.GetDateTime(5),
                        Idade = reader.IsDBNull(6) ? 0 : reader.GetInt64(6),
                        Sexo = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        ClienteDesde = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                        ObservacaoCliente = reader.IsDBNull(9) ? string.Empty : reader.GetString(9)
                    };
                    clientes.Add(cliente);
                }
                return clientes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public async Task<string> InserirCliente(string user, Cliente cliente)
        {
            var connection = _databaseService.GetConnection(user);

            try
            {
                var sql = "INSERT INTO cadastro.cliente (nome, cpf, rg, tipo, nascimento, idade, sexo, cliente_desde, observacao_cliente)";
                sql += " VALUES (@nome, @cpf, @rg, @tipo, @nascimento, @idade, @sexo, @cliente_desde, @observacao_cliente)";

                var command = new NpgsqlCommand(sql, connection);
                _ = command.Parameters.AddWithValue("@nome", cliente.Nome.ToLower());
                _ = command.Parameters.AddWithValue("@cpf", cliente.Cpf ?? "");
                _ = command.Parameters.AddWithValue("@rg", cliente.Rg ?? "");
                _ = command.Parameters.AddWithValue("@tipo", cliente.Tipo ?? 0);
                _ = command.Parameters.AddWithValue("@nascimento", cliente.Nascimento ?? DateTime.Now);
                _ = command.Parameters.AddWithValue("@idade", cliente.Idade ?? 30);
                _ = command.Parameters.AddWithValue("@sexo", cliente.Sexo ?? "");
                _ = command.Parameters.AddWithValue("@cliente_desde", DateTime.Now);
                _ = command.Parameters.AddWithValue("@observacao_cliente", cliente.ObservacaoCliente ?? "");
                var result = await command.ExecuteNonQueryAsync();

                return result == 1 ? "success" : "error";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public async Task<Cliente?> ObterCliente(string user, long id)
        {
            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT * FROM cadastro.cliente WHERE id_cliente = @id";

            try
            {
                var command = new NpgsqlCommand(sql, connection);
                _ = command.Parameters.AddWithValue("@id", id);
                var reader = await command.ExecuteReaderAsync();
                Cliente? cliente = null;
                while (reader.Read())
                {
                    cliente = new Cliente
                    {
                        IdCliente = reader.GetInt32(0),
                        Nome = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Cpf = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Rg = reader.IsDBNull(3) ? string.Empty : reader.GetString(2),
                        Tipo = reader.IsDBNull(4) ? 0 : reader.GetInt64(4),
                        Nascimento = reader.IsDBNull(5) ? null : reader.GetDateTime(5),
                        Idade = reader.IsDBNull(6) ? 0 : reader.GetInt64(6),
                        Sexo = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        ClienteDesde = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                        ObservacaoCliente = reader.IsDBNull(9) ? string.Empty : reader.GetString(9)
                    };
                }
                return cliente;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task<string> ExcluirCliente(string user, long id)
        {
            var connection = _databaseService.GetConnection(user);

            var transaction = await connection.BeginTransactionAsync();

            var sql = "DELETE FROM cadastro.cliente WHERE id_cliente = @id";
            try
            {
                var command = new NpgsqlCommand(sql, connection);

                _ = command.Parameters.AddWithValue("@id", id);

                var result = command.ExecuteNonQuery();

                if (result == 1)
                {
                    await transaction.CommitAsync();
                    return "success";
                }
                else
                {
                    await transaction.RollbackAsync();
                    return "Erro ao excluir cliente!";
                }

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Erro ao excluir cliente!");
                throw new Exception("Erro ao excluir cliente!");
            }
            finally
            {
                connection.Close();
            }
        }
        public async Task<List<dynamic>>? BuscarCliente(string user, string nome)
        {
            var connection = _databaseService.GetConnection(user);

            var sql = "SELECT * FROM cadastro.cliente WHERE nome ILIKE @nome";

            var command = new NpgsqlCommand(sql, connection);

            _ = command.Parameters.AddWithValue("@nome", $"%{nome}%");

            try
            {
                var reader = await command.ExecuteReaderAsync();

                var clientes = new List<dynamic>();
                while (reader.Read())
                {
                    var cliente = new Cliente
                    {
                        IdCliente = reader.GetInt32(0),
                        Nome = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Cpf = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Rg = reader.IsDBNull(3) ? string.Empty : reader.GetString(2),
                        Tipo = reader.IsDBNull(4) ? 0 : reader.GetInt64(4),
                        Nascimento = reader.IsDBNull(5) ? null : reader.GetDateTime(5),
                        Idade = reader.IsDBNull(6) ? 0 : reader.GetInt64(6),
                        Sexo = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        ClienteDesde = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                        ObservacaoCliente = reader.IsDBNull(9) ? string.Empty : reader.GetString(9)
                    };
                    clientes.Add(cliente);
                }
                return clientes;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}