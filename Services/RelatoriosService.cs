using Npgsql;
using Sismog.Services.Interfaces;
using Sismog.ViewModels.Relatorios;

namespace Sismog.Services
{
    public class RelatoriosService : IRelatoriosService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<PedidoService> _logger;

        public RelatoriosService(IDatabaseService databaseService, ILogger<PedidoService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<Dashboard> ObterRelatorioGeral(string user)
        {
            var connection = _databaseService.GetConnection(user);

            var relatorio = new Dashboard();

            try
            {
                // 1) Quantidade total em estoque (estoque global)
                relatorio.QtdTotalEstoque = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT COALESCE(ROUND(SUM(qtd_atual),1),0)
                    FROM estoques.estoque;
                ");

                // 2) Quantidade aprovada (situação = 2)
                relatorio.QtdAprovada = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT COALESCE(ROUND(SUM(ite.quantidade * prod.unidades),1),0)
                    FROM pedidos.item_pedido ite
                    LEFT JOIN pedidos.pedido ped ON ped.id_pedido = ite.id_pedido
                    LEFT JOIN produtos.produto prod ON prod.id_produto = ite.item
                    WHERE ped.situacao = 2;
                ");

                // 3) Quantidade pendente (somente última versão pendente)
                relatorio.QtdPendente = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT COALESCE(ROUND(SUM(ite.quantidade * prod.unidades),1),0)
                    FROM orcamentos.item_versao_orcamento ite
                    LEFT JOIN orcamentos.versao_orcamento ver 
                        ON ver.id_versao_orcamento = ite.id_versao_orcamento
                    LEFT JOIN produtos.produto prod 
                        ON prod.id_produto = ite.item
                    WHERE ver.situacao = 1 
                      AND ver.id_versao_orcamento = (
                         SELECT MAX(v2.id_versao_orcamento)
                         FROM orcamentos.versao_orcamento v2
                         WHERE v2.id_orcamento = ver.id_orcamento
                     );
                ");

                // 4) Total em estoque — usando média de custo dos produtos
                relatorio.TotalEstoque = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT COALESCE(ROUND(
                        (SELECT SUM(qtd_atual) FROM estoques.estoque) 
                        *
                        (SELECT AVG(preco_custo) FROM produtos.produto)
                    , 1), 0);
                ");

                // 5) Total aprovado (preço histórico do item)
                relatorio.TotalAprovados = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT COALESCE(ROUND(SUM(ite.quantidade * ite.preco_unitario),1),0)
                    FROM pedidos.item_pedido ite
                    LEFT JOIN pedidos.pedido ped ON ped.id_pedido = ite.id_pedido
                    WHERE ped.situacao = 2;
                ");

                // 6) Total pendente — última versão pendente
                relatorio.TotalPendentes = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT COALESCE(ROUND(SUM(ite.quantidade * prod.preco_varejo),1),0)
                    FROM orcamentos.item_versao_orcamento ite
                    LEFT JOIN orcamentos.versao_orcamento ver 
                        ON ver.id_versao_orcamento = ite.id_versao_orcamento
                    LEFT JOIN produtos.produto prod 
                        ON prod.id_produto = ite.item
                    WHERE ver.situacao = 1
                      AND ver.id_versao_orcamento = (
                         SELECT MAX(v2.id_versao_orcamento)
                         FROM orcamentos.versao_orcamento v2
                         WHERE v2.id_orcamento = ver.id_orcamento
                     );
                ");

                return relatorio;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        private async Task<decimal> ExecuteScalarDecimalAsync(NpgsqlConnection conn, string sql)
        {
            using var cmd = new NpgsqlCommand(sql, conn);
            var result = await cmd.ExecuteScalarAsync();
            return result == DBNull.Value || result is null ? 0 : Convert.ToDecimal(result);
        }
    }
}
