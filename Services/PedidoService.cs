using Npgsql;
using Sismog.Services.Interfaces;
using Sismog.ViewModels.Pedido;
namespace Sismog.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<PedidoService> _logger;

        public PedidoService(IDatabaseService databaseService, ILogger<PedidoService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<List<ViewModelPedido>> ObterPedidos(string user)
        {
            var connection = _databaseService.GetConnection(user);

            var sql = "SELECT ped.*, clien.nome, sit.nome FROM pedidos.pedido ped";
            sql += " INNER JOIN cadastro.cliente clien ON clien.id_cliente = ped.id_cliente";
            sql += " INNER JOIN info.situacao sit ON sit.id_situacao = ped.situacao";
            sql += " ORDER BY id_pedido DESC";

            var command = new NpgsqlCommand(sql, connection);

            try
            {
                var reader = await command.ExecuteReaderAsync();
                var lista = new List<ViewModelPedido>();
                while (reader.Read())
                {
                    var pedido = new ViewModelPedido
                    {
                        IdPedido = reader.GetInt64(0),
                        IdOrcamento = reader.GetInt64(1),
                        IdVersaoOrcamento = reader.GetInt64(2),
                        IdCliente = reader.IsDBNull(3) ? 0 : reader.GetInt64(3),
                        ValorProdutos = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                        Desconto = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8),
                        Subtotal = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                        Total = reader.IsDBNull(11) ? 0 : reader.GetDecimal(11),
                        FormaDePagamento = reader.IsDBNull(12) ? 0 : reader.GetInt64(12),
                        DataCriacao = reader.IsDBNull(13) ? null : reader.GetDateTime(13),
                        IdSituacao = reader.IsDBNull(14) ? 0 : reader.GetInt64(14),
                        NomeCliente = reader.IsDBNull(15) ? string.Empty : reader.GetString(15),
                        Situacao = reader.IsDBNull(16) ? string.Empty : reader.GetString(16)
                    };
                    lista.Add(pedido);
                }
                return lista;

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
        public async Task<ViewModelPedido> ObterDetalhesPedido(string user, long id)
        {
            var connection = _databaseService.GetConnection(user);

            var sql = "SELECT ped.*, clien.nome, sit.nome FROM pedidos.pedido ped";
            sql += " INNER JOIN cadastro.cliente clien ON clien.id_cliente = ped.id_cliente";
            sql += " INNER JOIN info.situacao sit ON sit.id_situacao = ped.situacao";
            sql += " WHERE ped.id_pedido = @id";
            var command = new NpgsqlCommand(sql, connection);
            _ = command.Parameters.AddWithValue("@id", id);

            try
            {
                var reader = await command.ExecuteReaderAsync();
                var pedido = new ViewModelPedido();
                while (reader.Read())
                {
                    pedido.IdPedido = reader.GetInt64(0);
                    pedido.IdOrcamento = reader.GetInt64(1);
                    pedido.IdVersaoOrcamento = reader.GetInt64(2);
                    pedido.IdCliente = reader.IsDBNull(3) ? 0 : reader.GetInt64(3);
                    pedido.ValorProdutos = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
                    pedido.Desconto = reader.IsDBNull(8) ? 0 : reader.GetInt64(8);
                    pedido.Subtotal = reader.IsDBNull(10) ? 0 : reader.GetInt64(10);
                    pedido.Total = reader.IsDBNull(11) ? 0 : reader.GetInt64(11);
                    pedido.FormaDePagamento = reader.IsDBNull(12) ? 0 : reader.GetInt64(12);
                    pedido.DataCriacao = reader.IsDBNull(13) ? null : reader.GetDateTime(13);
                    pedido.IdSituacao = reader.IsDBNull(14) ? 0 : reader.GetInt64(14);
                    pedido.NomeCliente = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
                    pedido.Situacao = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
                }
                return pedido;

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

        public async Task<string> ConcluirPedido(string user, long id)
        {
            var connection = _databaseService.GetConnection(user);

            var sql = "SELECT * FROM pedidos.p_concluir_pedido(@id)";
            var command = new NpgsqlCommand(sql, connection);
            _ = command.Parameters.AddWithValue("id", id);
            try
            {
                var result = "";
                var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                }

                return result == "success" ? "success" : result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                connection.Close();
            }

        }
        public async Task<List<ViewModelItemPedido>> ObterItensPedido(string user, long id)
        {
            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT item.*, prod.nome_produto FROM pedidos.item_pedido item";
            sql += " INNER JOIN produtos.produto prod ON prod.id_produto = item.item";
            sql += " WHERE item.id_pedido = @id_pedido";
            var command = new NpgsqlCommand(sql, connection);
            _ = command.Parameters.AddWithValue("id_pedido", id);
            try
            {
                var reader = await command.ExecuteReaderAsync();
                List<ViewModelItemPedido> itens = [];
                while (reader.Read())
                {
                    var item = new ViewModelItemPedido
                    {
                        IdItemPedido = reader.IsDBNull(0) ? 0 : reader.GetInt64(0),
                        Item = reader.IsDBNull(1) ? 0 : reader.GetInt64(1),
                        IdPedido = reader.IsDBNull(2) ? 0 : reader.GetInt64(2),
                        Quantidade = reader.IsDBNull(3) ? 0 : reader.GetInt64(3),
                        IdLote = reader.IsDBNull(4) ? 0 : reader.GetInt64(4),
                        PrecoUnitario = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5),
                        Desconto = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                        Nome = reader.IsDBNull(7) ? string.Empty : reader.GetString(7)
                    };
                    itens.Add(item);
                }
                return itens;

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