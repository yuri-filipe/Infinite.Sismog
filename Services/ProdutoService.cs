using Npgsql;
using Sismog.Models;
using Sismog.Services.Interfaces;

namespace Sismog.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<ProdutoService> _logger;

        public ProdutoService(IDatabaseService databaseService, ILogger<ProdutoService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<List<Produto>> ObterProdutos(string user)
        {
            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT * FROM produtos.produto";
            var command = new NpgsqlCommand(sql, connection);
            try
            {
                var reader = await command.ExecuteReaderAsync();
                var produtos = new List<Produto>();
                while (reader.Read())
                {
                    var produto = new Produto
                    {
                        IdProduto = reader.IsDBNull(0) ? 0 : reader.GetInt64(0),
                        NomeProduto = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Descricao = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        PrecoVarejo = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                        Observacao = reader.IsDBNull(10) ? string.Empty : reader.GetString(10)
                    };
                    produtos.Add(produto);
                }
                return produtos;

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
        public async Task<List<dynamic>> ObterProdutosPorNome(string user, string nome)
        {

            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT * FROM produtos.produto WHERE nome_produto LIKE @nome";
            var command = new NpgsqlCommand(sql, connection);
            _ = command.Parameters.AddWithValue("@nome", "%" + nome + "%");
            try
            {
                var reader = await command.ExecuteReaderAsync();
                var produtos = new List<dynamic>();
                while (reader.Read())
                {
                    var produto = new
                    {
                        IdProduto = reader.IsDBNull(0) ? 0 : reader.GetInt64(0),
                        NomeProduto = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Descricao = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        PrecoVarejo = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                        Observacao = reader.IsDBNull(10) ? string.Empty : reader.GetString(10)
                    };
                    produtos.Add(produto);
                }
                return produtos;

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
        public async Task<dynamic> ObterDadosProdutosPorId(string user, long idProduto)
        {

            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT * FROM produtos.produto WHERE id_produto = @id";
            var command = new NpgsqlCommand(sql, connection);
            _ = command.Parameters.AddWithValue("@id", idProduto);
            try
            {
                var reader = await command.ExecuteReaderAsync();
                dynamic produto = null;

                while (reader.Read())
                {
                    produto = new
                    {
                        IdProduto = reader.IsDBNull(0) ? 0 : reader.GetInt64(0),
                        NomeProduto = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Descricao = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        PrecoVarejo = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                        Observacao = reader.IsDBNull(10) ? string.Empty : reader.GetString(10)
                    };
                }
                return produto;

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