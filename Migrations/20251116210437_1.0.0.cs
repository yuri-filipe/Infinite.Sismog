using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sismog.Migrations
{
    /// <inheritdoc />
    public partial class _100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.EnsureSchema(
                name: "cadastro");

            _ = migrationBuilder.EnsureSchema(
                name: "estoques");

            _ = migrationBuilder.EnsureSchema(
                name: "produtos");

            _ = migrationBuilder.EnsureSchema(
                name: "pedidos");

            _ = migrationBuilder.EnsureSchema(
                name: "orcamentos");

            _ = migrationBuilder.EnsureSchema(
                name: "info");

            _ = migrationBuilder.CreateTable(
                name: "bairro",
                schema: "cadastro",
                columns: table => new
                {
                    id_bairro = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    codigo = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_bairro", x => x.id_bairro);
                });

            _ = migrationBuilder.CreateTable(
                name: "cidade",
                schema: "cadastro",
                columns: table => new
                {
                    id_cidade = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    codigo = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_cidade", x => x.id_cidade);
                });

            _ = migrationBuilder.CreateTable(
                name: "cliente",
                schema: "cadastro",
                columns: table => new
                {
                    id_cliente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    rg = table.Column<string>(type: "text", nullable: true),
                    tipo = table.Column<long>(type: "bigint", nullable: true),
                    nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    idade = table.Column<long>(type: "bigint", nullable: true),
                    sexo = table.Column<string>(type: "text", nullable: true),
                    cliente_desde = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    observacao_cliente = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_cliente", x => x.id_cliente);
                });

            _ = migrationBuilder.CreateTable(
                name: "entrada",
                schema: "produtos",
                columns: table => new
                {
                    id_entrada = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_entrada = table.Column<long>(type: "bigint", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false),
                    responsavel = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_entrada", x => x.id_entrada);
                });

            _ = migrationBuilder.CreateTable(
                name: "estado",
                schema: "cadastro",
                columns: table => new
                {
                    id_estado = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    codigo = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_estado", x => x.id_estado);
                });

            _ = migrationBuilder.CreateTable(
                name: "estoque",
                schema: "estoques",
                columns: table => new
                {
                    id_estoque = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_estoque = table.Column<string>(type: "text", nullable: true),
                    qtd_minima = table.Column<decimal>(type: "numeric", nullable: true),
                    qtd_atual = table.Column<decimal>(type: "numeric", nullable: true),
                    qtd_maxima = table.Column<decimal>(type: "numeric", nullable: true),
                    observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_estoque", x => x.id_estoque);
                });

            _ = migrationBuilder.CreateTable(
                name: "meio_de_conhecimento",
                schema: "cadastro",
                columns: table => new
                {
                    id_meio_de_conhecimento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    motivo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_meio_de_conhecimento", x => x.id_meio_de_conhecimento);
                });

            _ = migrationBuilder.CreateTable(
                name: "orcamento",
                schema: "orcamentos",
                columns: table => new
                {
                    id_orcamento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_orcamento = table.Column<long>(type: "bigint", nullable: true),
                    id_cliente = table.Column<long>(type: "bigint", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    entrega = table.Column<long>(type: "bigint", nullable: true),
                    retirada = table.Column<long>(type: "bigint", nullable: true),
                    situacao = table.Column<long>(type: "bigint", nullable: true),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    meio_de_conhecimento = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_orcamento", x => x.id_orcamento);
                });

            _ = migrationBuilder.CreateTable(
                name: "pedido",
                schema: "pedidos",
                columns: table => new
                {
                    id_pedido = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_orcamento = table.Column<long>(type: "bigint", nullable: false),
                    id_versao_orcamento = table.Column<long>(type: "bigint", nullable: false),
                    id_cliente = table.Column<long>(type: "bigint", nullable: false),
                    entrega = table.Column<long>(type: "bigint", nullable: true),
                    retirada = table.Column<long>(type: "bigint", nullable: true),
                    valor_produtos = table.Column<decimal>(type: "numeric", nullable: true),
                    valor_entrega = table.Column<decimal>(type: "numeric", nullable: true),
                    desconto = table.Column<decimal>(type: "numeric", nullable: true),
                    acrescimo = table.Column<decimal>(type: "numeric", nullable: true),
                    subtotal = table.Column<decimal>(type: "numeric", nullable: true),
                    total = table.Column<decimal>(type: "numeric", nullable: true),
                    forma_de_pagamento = table.Column<long>(type: "bigint", nullable: true),
                    data_criacao = table.Column<DateOnly>(type: "date", nullable: true),
                    situacao = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_pedido", x => x.id_pedido);
                });

            _ = migrationBuilder.CreateTable(
                name: "produto",
                schema: "produtos",
                columns: table => new
                {
                    id_produto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_produto = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    unidades = table.Column<long>(type: "bigint", nullable: true),
                    preco_custo = table.Column<decimal>(type: "numeric", nullable: true),
                    preco_atacado = table.Column<decimal>(type: "numeric", nullable: true),
                    preco_varejo = table.Column<decimal>(type: "numeric", nullable: true),
                    tipo = table.Column<long>(type: "bigint", nullable: true),
                    peso = table.Column<decimal>(type: "numeric", nullable: true),
                    altura = table.Column<decimal>(type: "numeric", nullable: true),
                    observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_produto", x => x.id_produto);
                });

            _ = migrationBuilder.CreateTable(
                name: "situacao",
                schema: "info",
                columns: table => new
                {
                    id_situacao = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_situacao", x => x.id_situacao);
                });

            _ = migrationBuilder.CreateTable(
                name: "email",
                schema: "cadastro",
                columns: table => new
                {
                    id_email = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    endereco = table.Column<string>(type: "text", nullable: true),
                    id_cliente = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_email", x => x.id_email);
                    _ = table.ForeignKey(
                        name: "FK_email_cliente_id_cliente",
                        column: x => x.id_cliente,
                        principalSchema: "cadastro",
                        principalTable: "cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "endereco",
                schema: "cadastro",
                columns: table => new
                {
                    id_endereco = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_cliente = table.Column<long>(type: "bigint", nullable: false),
                    logradouro = table.Column<string>(type: "text", nullable: true),
                    cep = table.Column<string>(type: "text", nullable: true),
                    numero = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<long>(type: "bigint", nullable: true),
                    cidade = table.Column<long>(type: "bigint", nullable: true),
                    estado = table.Column<long>(type: "bigint", nullable: true),
                    complemento = table.Column<string>(type: "text", nullable: true),
                    ponto_referencia = table.Column<string>(type: "text", nullable: true),
                    observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_endereco", x => x.id_endereco);
                    _ = table.ForeignKey(
                        name: "FK_endereco_cliente_id_cliente",
                        column: x => x.id_cliente,
                        principalSchema: "cadastro",
                        principalTable: "cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "sms",
                schema: "cadastro",
                columns: table => new
                {
                    id_sms = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<string>(type: "text", nullable: true),
                    id_cliente = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_sms", x => x.id_sms);
                    _ = table.ForeignKey(
                        name: "FK_sms_cliente_id_cliente",
                        column: x => x.id_cliente,
                        principalSchema: "cadastro",
                        principalTable: "cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "telefone",
                schema: "cadastro",
                columns: table => new
                {
                    id_telefone = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<string>(type: "text", nullable: true),
                    id_cliente = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_telefone", x => x.id_telefone);
                    _ = table.ForeignKey(
                        name: "FK_telefone_cliente_id_cliente",
                        column: x => x.id_cliente,
                        principalSchema: "cadastro",
                        principalTable: "cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "telegram",
                schema: "cadastro",
                columns: table => new
                {
                    id_telegram = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<string>(type: "text", nullable: true),
                    id_cliente = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_telegram", x => x.id_telegram);
                    _ = table.ForeignKey(
                        name: "FK_telegram_cliente_id_cliente",
                        column: x => x.id_cliente,
                        principalSchema: "cadastro",
                        principalTable: "cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "whatsapp",
                schema: "cadastro",
                columns: table => new
                {
                    id_whatsapp = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<string>(type: "text", nullable: true),
                    id_cliente = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_whatsapp", x => x.id_whatsapp);
                    _ = table.ForeignKey(
                        name: "FK_whatsapp_cliente_id_cliente",
                        column: x => x.id_cliente,
                        principalSchema: "cadastro",
                        principalTable: "cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "lote_entrada",
                schema: "produtos",
                columns: table => new
                {
                    id_lote_entrada = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_lote_entrada = table.Column<string>(type: "text", nullable: true),
                    numero_lote_entrada = table.Column<long>(type: "bigint", nullable: false),
                    id_entrada = table.Column<long>(type: "bigint", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    tipo_produto = table.Column<long>(type: "bigint", nullable: true),
                    responsavel = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_lote_entrada", x => x.id_lote_entrada);
                    _ = table.ForeignKey(
                        name: "FK_lote_entrada_entrada_id_entrada",
                        column: x => x.id_entrada,
                        principalSchema: "produtos",
                        principalTable: "entrada",
                        principalColumn: "id_entrada",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "lote_estoque",
                schema: "produtos",
                columns: table => new
                {
                    id_lote_estoque = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_lote_estoque = table.Column<string>(type: "text", nullable: true),
                    numero_lote_estoque = table.Column<long>(type: "bigint", nullable: false),
                    id_estoque = table.Column<long>(type: "bigint", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    tipo_produto = table.Column<long>(type: "bigint", nullable: true),
                    responsavel = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_lote_estoque", x => x.id_lote_estoque);
                    _ = table.ForeignKey(
                        name: "FK_lote_estoque_estoque_id_estoque",
                        column: x => x.id_estoque,
                        principalSchema: "estoques",
                        principalTable: "estoque",
                        principalColumn: "id_estoque",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "versao_orcamento",
                schema: "orcamentos",
                columns: table => new
                {
                    id_versao_orcamento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_versao_orcamento = table.Column<long>(type: "bigint", nullable: true),
                    nome_versao_orcamento = table.Column<string>(type: "text", nullable: true),
                    id_orcamento = table.Column<long>(type: "bigint", nullable: true),
                    entrega = table.Column<long>(type: "bigint", nullable: true),
                    retirada = table.Column<long>(type: "bigint", nullable: true),
                    valor_itens = table.Column<decimal>(type: "numeric", nullable: true),
                    valor_entrega = table.Column<decimal>(type: "numeric", nullable: true),
                    desconto = table.Column<decimal>(type: "numeric", nullable: true),
                    acrescimo = table.Column<decimal>(type: "numeric", nullable: true),
                    subtotal = table.Column<decimal>(type: "numeric", nullable: true),
                    total = table.Column<decimal>(type: "numeric", nullable: true),
                    forma_de_pagamento = table.Column<long>(type: "bigint", nullable: true),
                    data_criacao = table.Column<DateOnly>(type: "date", nullable: true),
                    situacao = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_versao_orcamento", x => x.id_versao_orcamento);
                    _ = table.ForeignKey(
                        name: "FK_versao_orcamento_orcamento_id_orcamento",
                        column: x => x.id_orcamento,
                        principalSchema: "orcamentos",
                        principalTable: "orcamento",
                        principalColumn: "id_orcamento");
                });

            _ = migrationBuilder.CreateTable(
                name: "item_pedido",
                schema: "pedidos",
                columns: table => new
                {
                    id_item_pedido = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item = table.Column<long>(type: "bigint", nullable: false),
                    id_pedido = table.Column<long>(type: "bigint", nullable: false),
                    quantidade = table.Column<long>(type: "bigint", nullable: false),
                    id_lote = table.Column<long>(type: "bigint", nullable: true),
                    preco_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_item_pedido", x => x.id_item_pedido);
                    _ = table.ForeignKey(
                        name: "FK_item_pedido_pedido_id_pedido",
                        column: x => x.id_pedido,
                        principalSchema: "pedidos",
                        principalTable: "pedido",
                        principalColumn: "id_pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "baixa_estoque",
                schema: "estoques",
                columns: table => new
                {
                    id_baixa_estoque = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_produto = table.Column<long>(type: "bigint", nullable: false),
                    id_estoque = table.Column<long>(type: "bigint", nullable: false),
                    id_pedido = table.Column<long>(type: "bigint", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    baixado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_baixa_estoque", x => x.id_baixa_estoque);
                    _ = table.ForeignKey(
                        name: "FK_baixa_estoque_estoque_id_estoque",
                        column: x => x.id_estoque,
                        principalSchema: "estoques",
                        principalTable: "estoque",
                        principalColumn: "id_estoque",
                        onDelete: ReferentialAction.Restrict);
                    _ = table.ForeignKey(
                        name: "FK_baixa_estoque_pedido_id_pedido",
                        column: x => x.id_pedido,
                        principalSchema: "pedidos",
                        principalTable: "pedido",
                        principalColumn: "id_pedido",
                        onDelete: ReferentialAction.Restrict);
                    _ = table.ForeignKey(
                        name: "FK_baixa_estoque_produto_id_produto",
                        column: x => x.id_produto,
                        principalSchema: "produtos",
                        principalTable: "produto",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Restrict);
                });

            _ = migrationBuilder.CreateTable(
                name: "produto_entrada",
                schema: "produtos",
                columns: table => new
                {
                    id_produto_entrada = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_produto = table.Column<long>(type: "bigint", nullable: false),
                    quantidade = table.Column<long>(type: "bigint", nullable: false),
                    id_lote = table.Column<long>(type: "bigint", nullable: false),
                    id_entrada = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_produto_entrada", x => x.id_produto_entrada);
                    _ = table.ForeignKey(
                        name: "FK_produto_entrada_entrada_id_entrada",
                        column: x => x.id_entrada,
                        principalSchema: "produtos",
                        principalTable: "entrada",
                        principalColumn: "id_entrada",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_produto_entrada_produto_id_produto",
                        column: x => x.id_produto,
                        principalSchema: "produtos",
                        principalTable: "produto",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "produto_estoque",
                schema: "produtos",
                columns: table => new
                {
                    id_produto_estoque = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_produto = table.Column<long>(type: "bigint", nullable: false),
                    id_estoque = table.Column<long>(type: "bigint", nullable: false),
                    quantidade = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_produto_estoque", x => x.id_produto_estoque);
                    _ = table.ForeignKey(
                        name: "FK_produto_estoque_estoque_id_estoque",
                        column: x => x.id_estoque,
                        principalSchema: "estoques",
                        principalTable: "estoque",
                        principalColumn: "id_estoque",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_produto_estoque_produto_id_produto",
                        column: x => x.id_produto,
                        principalSchema: "produtos",
                        principalTable: "produto",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "item_versao_orcamento",
                schema: "orcamentos",
                columns: table => new
                {
                    id_item_versao_orcamento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item = table.Column<long>(type: "bigint", nullable: false),
                    id_versao_orcamento = table.Column<long>(type: "bigint", nullable: false),
                    quantidade = table.Column<long>(type: "bigint", nullable: false),
                    id_lote = table.Column<long>(type: "bigint", nullable: true),
                    preco_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_item_versao_orcamento", x => x.id_item_versao_orcamento);
                    _ = table.ForeignKey(
                        name: "FK_item_versao_orcamento_versao_orcamento_id_versao_orcamento",
                        column: x => x.id_versao_orcamento,
                        principalSchema: "orcamentos",
                        principalTable: "versao_orcamento",
                        principalColumn: "id_versao_orcamento",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_baixa_estoque_id_estoque",
                schema: "estoques",
                table: "baixa_estoque",
                column: "id_estoque");

            _ = migrationBuilder.CreateIndex(
                name: "IX_baixa_estoque_id_pedido",
                schema: "estoques",
                table: "baixa_estoque",
                column: "id_pedido");

            _ = migrationBuilder.CreateIndex(
                name: "IX_baixa_estoque_id_produto",
                schema: "estoques",
                table: "baixa_estoque",
                column: "id_produto");

            _ = migrationBuilder.CreateIndex(
                name: "IX_email_id_cliente",
                schema: "cadastro",
                table: "email",
                column: "id_cliente");

            _ = migrationBuilder.CreateIndex(
                name: "IX_endereco_id_cliente",
                schema: "cadastro",
                table: "endereco",
                column: "id_cliente");

            _ = migrationBuilder.CreateIndex(
                name: "IX_item_pedido_id_pedido",
                schema: "pedidos",
                table: "item_pedido",
                column: "id_pedido");

            _ = migrationBuilder.CreateIndex(
                name: "IX_item_versao_orcamento_id_versao_orcamento",
                schema: "orcamentos",
                table: "item_versao_orcamento",
                column: "id_versao_orcamento");

            _ = migrationBuilder.CreateIndex(
                name: "IX_lote_entrada_id_entrada",
                schema: "produtos",
                table: "lote_entrada",
                column: "id_entrada");

            _ = migrationBuilder.CreateIndex(
                name: "IX_lote_estoque_id_estoque",
                schema: "produtos",
                table: "lote_estoque",
                column: "id_estoque");

            _ = migrationBuilder.CreateIndex(
                name: "IX_produto_entrada_id_entrada",
                schema: "produtos",
                table: "produto_entrada",
                column: "id_entrada");

            _ = migrationBuilder.CreateIndex(
                name: "IX_produto_entrada_id_produto",
                schema: "produtos",
                table: "produto_entrada",
                column: "id_produto",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_produto_estoque_id_estoque",
                schema: "produtos",
                table: "produto_estoque",
                column: "id_estoque");

            _ = migrationBuilder.CreateIndex(
                name: "IX_produto_estoque_id_produto",
                schema: "produtos",
                table: "produto_estoque",
                column: "id_produto");

            _ = migrationBuilder.CreateIndex(
                name: "IX_sms_id_cliente",
                schema: "cadastro",
                table: "sms",
                column: "id_cliente");

            _ = migrationBuilder.CreateIndex(
                name: "IX_telefone_id_cliente",
                schema: "cadastro",
                table: "telefone",
                column: "id_cliente");

            _ = migrationBuilder.CreateIndex(
                name: "IX_telegram_id_cliente",
                schema: "cadastro",
                table: "telegram",
                column: "id_cliente");

            _ = migrationBuilder.CreateIndex(
                name: "IX_versao_orcamento_id_orcamento",
                schema: "orcamentos",
                table: "versao_orcamento",
                column: "id_orcamento");

            _ = migrationBuilder.CreateIndex(
                name: "IX_whatsapp_id_cliente",
                schema: "cadastro",
                table: "whatsapp",
                column: "id_cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "bairro",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "baixa_estoque",
                schema: "estoques");

            _ = migrationBuilder.DropTable(
                name: "cidade",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "email",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "endereco",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "estado",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "item_pedido",
                schema: "pedidos");

            _ = migrationBuilder.DropTable(
                name: "item_versao_orcamento",
                schema: "orcamentos");

            _ = migrationBuilder.DropTable(
                name: "lote_entrada",
                schema: "produtos");

            _ = migrationBuilder.DropTable(
                name: "lote_estoque",
                schema: "produtos");

            _ = migrationBuilder.DropTable(
                name: "meio_de_conhecimento",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "produto_entrada",
                schema: "produtos");

            _ = migrationBuilder.DropTable(
                name: "produto_estoque",
                schema: "produtos");

            _ = migrationBuilder.DropTable(
                name: "situacao",
                schema: "info");

            _ = migrationBuilder.DropTable(
                name: "sms",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "telefone",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "telegram",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "whatsapp",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "pedido",
                schema: "pedidos");

            _ = migrationBuilder.DropTable(
                name: "versao_orcamento",
                schema: "orcamentos");

            _ = migrationBuilder.DropTable(
                name: "entrada",
                schema: "produtos");

            _ = migrationBuilder.DropTable(
                name: "estoque",
                schema: "estoques");

            _ = migrationBuilder.DropTable(
                name: "produto",
                schema: "produtos");

            _ = migrationBuilder.DropTable(
                name: "cliente",
                schema: "cadastro");

            _ = migrationBuilder.DropTable(
                name: "orcamento",
                schema: "orcamentos");
        }
    }
}
