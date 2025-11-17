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
                // 1) Quantidade total em estoque
                relatorio.QtdTotalEstoque = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT ROUND(SUM(qtd_atual),1) 
                    FROM estoques.estoque;
                ");

                // 2) Quantidade aprovada
                relatorio.QtdAprovada = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT COALESCE(ROUND(SUM(ite.quantidade * prod.unidades),1),0)
                    FROM pedidos.item_pedido ite
                    LEFT JOIN pedidos.pedido ped ON ped.id_pedido = ite.id_pedido
                    LEFT JOIN produtos.produto prod ON prod.id_produto = ite.item
                    WHERE ped.situacao = 2;
                ");

                // 3) Quantidade pendente (última versão do orçamento)
                relatorio.QtdPendente = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT COALESCE(ROUND(SUM(ite.quantidade * prod.unidades),1),0)
                    FROM orcamentos.item_versao_orcamento ite
                    LEFT JOIN orcamentos.versao_orcamento ver 
                        ON ver.id_versao_orcamento = ite.id_versao_orcamento
                    LEFT JOIN produtos.produto prod 
                        ON prod.id_produto = ite.item
                    WHERE ver.situacao = 1 
                      AND ver.id_versao_orcamento = (
                            SELECT MAX(ver2.id_versao_orcamento)
                            FROM orcamentos.versao_orcamento ver2
                            WHERE ver2.id_orcamento = ver.id_orcamento
                      );
                ");

                // 4) Total em estoque (valor)
                relatorio.TotalEstoque = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT ROUND(
                        (
                            (SELECT SUM(est.qtd_atual) FROM estoques.estoque est)
                            *
                            (SELECT prod.preco_custo 
                             FROM produtos.produto prod 
                             WHERE unidades = 1 LIMIT 1)
                        ), 
                        1
                    );
                ");

                // 5) Total aprovado
                relatorio.TotalAprovados = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT ROUND(SUM(COALESCE((ite.quantidade * prod.preco_varejo),0)),1)
                    FROM pedidos.item_pedido ite
                    LEFT JOIN pedidos.pedido ped ON ped.id_pedido = ite.id_pedido
                    LEFT JOIN produtos.produto prod ON prod.id_produto = ite.item
                    WHERE ped.situacao = 2;
                ");

                // 6) Total pendente (última versão)
                relatorio.TotalPendentes = await ExecuteScalarDecimalAsync(connection, @"
                    SELECT ROUND(SUM(COALESCE((ite.quantidade * prod.preco_varejo),0)),1)
                    FROM orcamentos.item_versao_orcamento ite
                    LEFT JOIN orcamentos.versao_orcamento ver 
                        ON ver.id_versao_orcamento = ite.id_versao_orcamento
                    LEFT JOIN produtos.produto prod 
                        ON prod.id_produto = ite.item
                    WHERE ver.situacao = 1 
                      AND ver.id_versao_orcamento = (
                            SELECT MAX(ver2.id_versao_orcamento)
                            FROM orcamentos.versao_orcamento ver2
                            WHERE ver2.id_orcamento = ver.id_orcamento
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