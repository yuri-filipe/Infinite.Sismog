using Npgsql;
using Sismog.Services.Interfaces;
using Sismog.ViewModels.Orcamento;

namespace Sismog.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<OrcamentoService> _logger;

        public OrcamentoService(IDatabaseService databaseService, ILogger<OrcamentoService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<ViewModelOrcamento> ObterOrcamento(string user, long id)
        {
            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT orc.*, clien.Nome, sit.nome FROM orcamentos.orcamento orc";
            sql += " INNER JOIN cadastro.cliente clien ON orc.id_cliente = clien.id_cliente";
            sql += " INNER JOIN info.situacao sit ON sit.id_situacao = orc.situacao";
            sql += " WHERE id_orcamento = @id";
            var command = new NpgsqlCommand(sql, connection);
            _ = command.Parameters.AddWithValue("id", id);
            try
            {
                var reader = await command.ExecuteReaderAsync();

                var orcamento = new ViewModelOrcamento();
                if (reader.Read())
                {
                    orcamento.IdOrcamento = reader.GetInt64(0);
                    orcamento.NumeroOrcamento = reader.GetInt64(1);
                    orcamento.IdCliente = reader.GetInt64(2);
                    orcamento.DataCriacao = reader.IsDBNull(3) ? null : reader.GetDateTime(3);
                    orcamento.Entrega = reader.IsDBNull(4) ? 0 : reader.GetInt64(4);
                    orcamento.Retirada = reader.IsDBNull(5) ? 0 : reader.GetInt64(5);
                    orcamento.IdSituacao = reader.IsDBNull(6) ? 0 : reader.GetInt64(6);
                    orcamento.Observacao = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                    orcamento.MeioDeConhecimento = reader.IsDBNull(8) ? 0 : reader.GetInt64(8);
                    orcamento.NomeCliente = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                    orcamento.Situacao = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                }
                return orcamento;

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
        public async Task<List<ViewModelOrcamento>> ObterOrcamentos(string user)
        {
            List<ViewModelOrcamento> orcamentos = [];
            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT orc.*, clien.nome, sit.nome FROM orcamentos.orcamento orc";
            sql += " INNER JOIN cadastro.cliente clien ON orc.id_cliente = clien.id_cliente";
            sql += " INNER JOIN info.situacao sit ON sit.id_situacao = orc.situacao";
            sql += " ORDER BY id_orcamento DESC";

            var command = new NpgsqlCommand(sql, connection);
            try
            {
                var reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    var orcamento = new ViewModelOrcamento
                    {
                        IdOrcamento = reader.GetInt64(0),
                        NumeroOrcamento = reader.GetInt64(1),
                        IdCliente = reader.GetInt64(2),
                        DataCriacao = reader.IsDBNull(3) ? null : reader.GetDateTime(3),
                        Entrega = reader.IsDBNull(4) ? 0 : reader.GetInt64(4),
                        Retirada = reader.IsDBNull(5) ? 0 : reader.GetInt64(5),
                        IdSituacao = reader.IsDBNull(6) ? 0 : reader.GetInt64(6),
                        Observacao = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        MeioDeConhecimento = reader.IsDBNull(8) ? 0 : reader.GetInt64(8),
                        NomeCliente = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        Situacao = reader.IsDBNull(10) ? string.Empty : reader.GetString(10)
                    };
                    orcamentos.Add(orcamento);
                }

                return orcamentos;
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
        public async Task<List<ViewModelVersaoOrcamento>> ObterVersoesOrcamento(string user, long IdOrcamento)
        {
            List<ViewModelVersaoOrcamento> versoes = [];
            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT ver.*, sit.nome FROM orcamentos.versao_orcamento ver";
            sql += " INNER JOIN info.situacao sit ON sit.id_situacao = ver.situacao";
            sql += " WHERE ver.id_orcamento = @id_orcamento";

            var command = new NpgsqlCommand(sql, connection);
            _ = command.Parameters.AddWithValue("id_orcamento", IdOrcamento);
            try
            {
                var reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    var versao = new ViewModelVersaoOrcamento
                    {
                        IdVersaoOrcamento = reader.GetInt64(0),
                        NumeroVersaoOrcamento = reader.IsDBNull(1) ? 0 : reader.GetInt64(1),
                        NomeVersaoOrcamento = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Entrega = reader.IsDBNull(4) ? 0 : reader.GetInt64(4),
                        Retirada = reader.IsDBNull(5) ? 0 : reader.GetInt64(5),
                        ValorItens = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                        ValorEntrega = reader.IsDBNull(5) ? 0 : reader.GetDecimal(7),
                        Desconto = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8),
                        Acrescimo = reader.IsDBNull(9) ? 0 : reader.GetDecimal(9),
                        Subtotal = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                        Total = reader.IsDBNull(11) ? 0 : reader.GetDecimal(11),
                        FormaDePagamento = reader.IsDBNull(12) ? 0 : reader.GetInt64(12),
                        DataCriacao = reader.IsDBNull(13) ? null : reader.GetDateTime(13),
                        IdSituacao = reader.IsDBNull(14) ? 0 : reader.GetInt64(14),
                        Situacao = reader.IsDBNull(14) ? string.Empty : reader.IsDBNull(15) ? string.Empty : reader.GetString(15)
                    };
                    ;
                    versoes.Add(versao);
                }
                return versoes;

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
        public async Task<List<ViewModelItemVersaoOrcamento>> ObterItensVersoesOrcamento(string user, long IdVersao)
        {
            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT item.*, prod.nome_produto FROM orcamentos.item_versao_orcamento item";
            sql += " INNER JOIN produtos.produto prod ON prod.id_produto = item.item";
            sql += " WHERE item.id_versao_orcamento = @id_versao_orcamento";
            var command = new NpgsqlCommand(sql, connection);
            _ = command.Parameters.AddWithValue("id_versao_orcamento", IdVersao);
            try
            {
                var reader = await command.ExecuteReaderAsync();
                List<ViewModelItemVersaoOrcamento> itens = [];
                while (reader.Read())
                {
                    var item = new ViewModelItemVersaoOrcamento
                    {
                        IdItemVersaoOrcamento = reader.GetInt64(0),
                        Item = reader.GetInt64(1),
                        IdVersaoOrcamento = reader.GetInt64(2),
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

        public async Task<string> AdicionarOrcamento(string user, ViewModelOrcamento orcamento)
        {
            var connection = _databaseService.GetConnection(user);
            var transaction = connection.BeginTransaction();

            try
            {

                var sql = " INSERT INTO orcamentos.orcamento (numero_orcamento, id_cliente, data_criacao, observacao, situacao)";
                sql += " VALUES (@numero_orcamento, @id_cliente, @data_criacao, @observacao, @situacao)";
                sql += " RETURNING id_orcamento";

                var command = new NpgsqlCommand(sql, connection);
                _ = command.Parameters.AddWithValue("numero_orcamento", 1);
                _ = command.Parameters.AddWithValue("id_cliente", orcamento.IdCliente);
                _ = command.Parameters.AddWithValue("data_criacao", DateTime.Now);
                _ = command.Parameters.AddWithValue("observacao", orcamento.Observacao ?? "");
                _ = command.Parameters.AddWithValue("situacao", 1);

                var idOrcamento = (long)command.ExecuteScalar();

                var sqlVersao = " INSERT INTO orcamentos.versao_orcamento (id_orcamento, data_criacao, situacao, forma_de_pagamento)";
                sqlVersao += " VALUES (@id_orcamento, @data_criacao, @situacao, @forma_de_pagamento)";
                sqlVersao += " RETURNING id_versao_orcamento";

                command = new NpgsqlCommand(sqlVersao, connection);
                _ = command.Parameters.AddWithValue("id_orcamento", idOrcamento);
                _ = command.Parameters.AddWithValue("data_criacao", DateTime.Now);
                _ = command.Parameters.AddWithValue("situacao", 1);
                _ = command.Parameters.AddWithValue("forma_de_pagamento", orcamento.FormaDePagamento);

                var idVersao = (long)command.ExecuteScalar();

                var sqlItemVersao = " INSERT INTO orcamentos.item_versao_orcamento (item, id_versao_orcamento, quantidade, preco_unitario, desconto)";
                sqlItemVersao += " VALUES (@item, @id_versao_orcamento, @quantidade, @preco_unitario, @desconto)";

                command = new NpgsqlCommand(sqlItemVersao, connection);

                foreach (var item in orcamento.ListaProdutos!)
                {
                    _ = command.Parameters.AddWithValue("item", item.IdProduto);
                    _ = command.Parameters.AddWithValue("id_versao_orcamento", idVersao);
                    _ = command.Parameters.AddWithValue("quantidade", item.Quantidade);
                    _ = command.Parameters.AddWithValue("preco_unitario", item.Preco ?? 0);
                    _ = command.Parameters.AddWithValue("desconto", item.Desconto ?? 0);
                    _ = await command.ExecuteNonQueryAsync();
                }
                await transaction.CommitAsync();
                return "success";
            }
            catch (System.Exception ex)
            {
                await transaction.RollbackAsync();
                throw new System.Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public async Task<string> AdicionarVersaoOrcamento(string user, ViewModelOrcamento orcamento)
        {
            var connection = _databaseService.GetConnection(user);
            var transaction = connection.BeginTransaction();

            try
            {

                var sqlVersao = " INSERT INTO orcamentos.versao_orcamento (id_orcamento, data_criacao, situacao, forma_de_pagamento)";
                sqlVersao += " VALUES (@id_orcamento, @data_criacao, @situacao, @forma_de_pagamento)";
                sqlVersao += " RETURNING id_versao_orcamento";

                var command = new NpgsqlCommand(sqlVersao, connection);
                _ = command.Parameters.AddWithValue("id_orcamento", orcamento.IdOrcamento);
                _ = command.Parameters.AddWithValue("data_criacao", DateTime.Now);
                _ = command.Parameters.AddWithValue("situacao", 1);
                _ = command.Parameters.AddWithValue("forma_de_pagamento", orcamento.FormaDePagamento);

                var idVersao = (long)command.ExecuteScalar();

                var sqlItemVersao = " INSERT INTO orcamentos.item_versao_orcamento (item, id_versao_orcamento, quantidade, preco_unitario, desconto)";
                sqlItemVersao += " VALUES (@item, @id_versao_orcamento, @quantidade, @preco_unitario, @desconto)";

                command = new NpgsqlCommand(sqlItemVersao, connection);

                foreach (var item in orcamento.ListaProdutos!)
                {
                    _ = command.Parameters.AddWithValue("item", item.IdProduto);
                    _ = command.Parameters.AddWithValue("id_versao_orcamento", idVersao);
                    _ = command.Parameters.AddWithValue("quantidade", item.Quantidade);
                    _ = command.Parameters.AddWithValue("preco_unitario", item.Preco ?? 0);
                    _ = command.Parameters.AddWithValue("desconto", item.Desconto ?? 0);
                    _ = await command.ExecuteNonQueryAsync();
                }
                await transaction.CommitAsync();
                return "success";
            }
            catch (System.Exception ex)
            {
                await transaction.RollbackAsync();
                throw new System.Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public async Task<ViewModelOrcamento> ObterDetalhesOrcamento(string user, long id)
        {
            var connection = _databaseService.GetConnection(user);
            var sql = "SELECT orc.*, clien.Nome, sit.nome FROM orcamentos.orcamento orc";
            sql += " INNER JOIN cadastro.cliente clien ON orc.id_cliente = clien.id_cliente";
            sql += " INNER JOIN info.situacao sit ON sit.id_situacao = orc.situacao";
            sql += " WHERE id_orcamento = @id";
            var command = new NpgsqlCommand(sql, connection);
            _ = command.Parameters.AddWithValue("id", id);
            try
            {
                var reader = await command.ExecuteReaderAsync();

                var orcamento = new ViewModelOrcamento();
                if (reader.Read())
                {
                    orcamento.IdOrcamento = reader.GetInt64(0);
                    orcamento.NumeroOrcamento = reader.GetInt64(1);
                    orcamento.IdCliente = reader.GetInt64(2);
                    orcamento.DataCriacao = reader.IsDBNull(3) ? null : reader.GetDateTime(3);
                    orcamento.Entrega = reader.IsDBNull(4) ? 0 : reader.GetInt64(4);
                    orcamento.Retirada = reader.IsDBNull(5) ? 0 : reader.GetInt64(5);
                    orcamento.IdSituacao = reader.IsDBNull(6) ? 0 : reader.GetInt64(6);
                    orcamento.Observacao = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                    orcamento.MeioDeConhecimento = reader.IsDBNull(8) ? 0 : reader.GetInt64(8);
                    orcamento.NomeCliente = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                    orcamento.Situacao = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                }

                return orcamento;

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
        public async Task<string> ExcluirOrcamento(string user, long id)
        {
            var connection = _databaseService.GetConnection(user);
            var transaction = connection.BeginTransaction();
            try
            {
                var sql = "DELETE FROM orcamentos.orcamento WHERE id_orcamento = @id_orcamento";
                var command = new NpgsqlCommand(sql, connection);
                _ = command.Parameters.AddWithValue("id_orcamento", id);
                _ = await command.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
                return "success";
            }
            catch (System.Exception)
            {
                await transaction.RollbackAsync();
                return "error";
                throw new System.Exception("Erro ao excluir orçamento");
            }
        }

        public async Task<string> AprovarOrcamento(string user, long idVersao)
        {
            var connection = _databaseService.GetConnection(user);
            var transaction = connection.BeginTransaction();

            try
            {
                var sql = $"SELECT * FROM orcamentos.p_aprovar_orcamento({idVersao})";
                var command = new NpgsqlCommand(sql, connection);
                var result = (string)await command.ExecuteScalarAsync();
                await transaction.CommitAsync();

                return result == "success" ? "success" : "error";

            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                return e.Message;
            }

        }

    }
}