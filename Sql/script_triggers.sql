-- =====================================================================
--  FUNÇÃO: Aprovar Orçamento
-- =====================================================================
CREATE OR REPLACE FUNCTION orcamentos.p_aprovar_orcamento(idVersao bigint)
RETURNS varchar AS
$BODY$
DECLARE
    idOrcamento bigint;
BEGIN
    SELECT id_orcamento
    INTO STRICT idOrcamento
    FROM orcamentos.versao_orcamento
    WHERE id_versao_orcamento = idVersao;

    UPDATE orcamentos.orcamento
    SET situacao = 2
    WHERE id_orcamento = idOrcamento;

    UPDATE orcamentos.versao_orcamento
    SET situacao = 2
    WHERE id_versao_orcamento = idVersao;

    INSERT INTO pedidos.pedido(
        id_orcamento, id_versao_orcamento, id_cliente,
        entrega, retirada, valor_produtos, valor_entrega,
        desconto, acrescimo, subtotal, total,
        forma_de_pagamento, data_criacao, situacao
    )
    SELECT 
        orca.id_orcamento,
        idVersao,
        orca.id_cliente,
        orca.entrega,
        orca.retirada,
        ver.subtotal                              AS valor_produtos,          -- BRUTO
        ver.valor_entrega,
        ver.desconto,
        ver.acrescimo,
        (ver.subtotal - ver.desconto)             AS subtotal,                -- LÍQ PROD
        (ver.subtotal - ver.desconto 
            + COALESCE(ver.valor_entrega,0) 
            + COALESCE(ver.acrescimo,0))          AS total,                   -- FINAL
        ver.forma_de_pagamento,
        current_date,
        2
    FROM orcamentos.versao_orcamento ver
    INNER JOIN orcamentos.orcamento orca
        ON orca.id_orcamento = ver.id_orcamento
    WHERE ver.id_versao_orcamento = idVersao;

    RETURN 'success';
END;
$BODY$
LANGUAGE plpgsql VOLATILE COST 100;


-- =====================================================================
--  TRIGGER: Inserir Itens do Pedido
-- =====================================================================

CREATE OR REPLACE FUNCTION pedidos.p_inserir_itens_pedido()
RETURNS TRIGGER AS
$$
BEGIN
    INSERT INTO pedidos.item_pedido (
        id_pedido,
        item,
        quantidade,
        id_lote,
        preco_unitario,
        desconto
    )
    SELECT 
        NEW.id_pedido,
        ite.item,
        ite.quantidade,
        ite.id_lote,
        ite.preco_unitario,
        ite.desconto
    FROM orcamentos.item_versao_orcamento ite
    WHERE ite.id_versao_orcamento = NEW.id_versao_orcamento;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS t_inserir_itens_pedido ON pedidos.pedido;

CREATE TRIGGER t_inserir_itens_pedido
AFTER INSERT ON pedidos.pedido
FOR EACH ROW
EXECUTE PROCEDURE pedidos.p_inserir_itens_pedido();

-- =====================================================================
--  DATA CRIAÇÃO AUTOMÁTICA — ORÇAMENTO
-- =====================================================================

CREATE OR REPLACE FUNCTION orcamentos.p_inserir_data_criacao()
RETURNS TRIGGER AS
$$
BEGIN
    UPDATE orcamentos.orcamento 
    SET data_criacao = current_date 
    WHERE id_orcamento = NEW.id_orcamento;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS t_inserir_data_criacao ON orcamentos.orcamento;

CREATE TRIGGER t_inserir_data_criacao
AFTER INSERT ON orcamentos.orcamento
FOR EACH ROW
EXECUTE PROCEDURE orcamentos.p_inserir_data_criacao();

-- =====================================================================
--  DATA CRIAÇÃO AUTOMÁTICA — VERSÃO ORÇAMENTO
-- =====================================================================

CREATE OR REPLACE FUNCTION orcamentos.p_inserir_data_criacao_versao_orcamento()
RETURNS TRIGGER AS
$$
BEGIN
    UPDATE orcamentos.versao_orcamento 
    SET data_criacao = current_date 
    WHERE id_versao_orcamento = NEW.id_versao_orcamento;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS t_inserir_data_criacao_versao_orcamento ON orcamentos.versao_orcamento;

CREATE TRIGGER t_inserir_data_criacao_versao_orcamento
AFTER INSERT ON orcamentos.versao_orcamento
FOR EACH ROW
EXECUTE PROCEDURE orcamentos.p_inserir_data_criacao_versao_orcamento();

-- =====================================================================
--  NUMERAÇÃO E NOME DA VERSÃO DO ORÇAMENTO (BEFORE INSERT)
-- =====================================================================

CREATE OR REPLACE FUNCTION orcamentos.p_inserir_nome_versao_orcamento()
RETURNS TRIGGER AS
$$
DECLARE
    numero_ultima_versao bigint;
BEGIN
    SELECT COALESCE(MAX(numero_versao_orcamento), 0) + 1
    INTO numero_ultima_versao
    FROM orcamentos.versao_orcamento
    WHERE id_orcamento = NEW.id_orcamento;

    NEW.numero_versao_orcamento := numero_ultima_versao;
    NEW.nome_versao_orcamento := 'versão ' || numero_ultima_versao;

    -- GARANTE QUE VALORES NÃO NASÇAM NULL
    NEW.subtotal := COALESCE(NEW.subtotal, 0);
    NEW.desconto := COALESCE(NEW.desconto, 0);
    NEW.total    := COALESCE(NEW.total, 0);

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS t_inserir_nome_versao_orcamento ON orcamentos.versao_orcamento;

CREATE TRIGGER t_inserir_nome_versao_orcamento
BEFORE INSERT ON orcamentos.versao_orcamento
FOR EACH ROW
EXECUTE PROCEDURE orcamentos.p_inserir_nome_versao_orcamento();

-- =====================================================================
--  SITUAÇÃO PADRÃO — ORÇAMENTO
-- =====================================================================

CREATE OR REPLACE FUNCTION orcamentos.p_inserir_situacao_orcamento()
RETURNS TRIGGER AS
$$
BEGIN
    UPDATE orcamentos.orcamento
    SET situacao = 1
    WHERE id_orcamento = NEW.id_orcamento;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS t_inserir_situacao_orcamento ON orcamentos.orcamento;

CREATE TRIGGER t_inserir_situacao_orcamento
AFTER INSERT ON orcamentos.orcamento
FOR EACH ROW
EXECUTE PROCEDURE orcamentos.p_inserir_situacao_orcamento();

-- =====================================================================
--  SITUAÇÃO PADRÃO — VERSÃO ORÇAMENTO
-- =====================================================================

CREATE OR REPLACE FUNCTION orcamentos.p_inserir_situacao_versao_orcamento()
RETURNS TRIGGER AS
$$
BEGIN
    UPDATE orcamentos.versao_orcamento
    SET situacao = 1
    WHERE id_versao_orcamento = NEW.id_versao_orcamento;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS t_inserir_situacao_versao_orcamento ON orcamentos.versao_orcamento;

CREATE TRIGGER t_inserir_situacao_versao_orcamento
AFTER INSERT ON orcamentos.versao_orcamento
FOR EACH ROW
EXECUTE PROCEDURE orcamentos.p_inserir_situacao_versao_orcamento();

-- =====================================================================
--  RECALCULAR VALORES DA VERSÃO — ITEM INSERIDO/ALTERADO/REMOVIDO
-- =====================================================================

CREATE OR REPLACE FUNCTION orcamentos.p_inserir_valores_produtos_em_versao_de_orcamento()
RETURNS TRIGGER AS
$$
DECLARE
    v_subtotal NUMERIC(10,2);
    v_desconto NUMERIC(10,2);
    v_total    NUMERIC(10,2);
    v_id_versao bigint;
BEGIN
    IF (TG_OP = 'DELETE') THEN
        v_id_versao := OLD.id_versao_orcamento;
    ELSE
        v_id_versao := NEW.id_versao_orcamento;
    END IF;

    SELECT COALESCE(SUM(quantidade * preco_unitario), 0)
    INTO v_subtotal
    FROM orcamentos.item_versao_orcamento
    WHERE id_versao_orcamento = v_id_versao;

    SELECT COALESCE(SUM(desconto), 0)
    INTO v_desconto
    FROM orcamentos.item_versao_orcamento
    WHERE id_versao_orcamento = v_id_versao;

    v_total := COALESCE(v_subtotal, 0) - COALESCE(v_desconto, 0);

    UPDATE orcamentos.versao_orcamento
    SET 
        subtotal = v_subtotal,
        desconto = v_desconto,
        total    = v_total
    WHERE id_versao_orcamento = v_id_versao;

    IF (TG_OP = 'DELETE') THEN
        RETURN OLD;
    ELSE
        RETURN NEW;
    END IF;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS t_inserir_valores_produtos_em_versao_de_orcamento ON orcamentos.item_versao_orcamento;

CREATE TRIGGER t_inserir_valores_produtos_em_versao_de_orcamento
AFTER INSERT OR UPDATE OR DELETE ON orcamentos.item_versao_orcamento
FOR EACH ROW
EXECUTE PROCEDURE orcamentos.p_inserir_valores_produtos_em_versao_de_orcamento();

-- =====================================================================
--  FUNÇÃO: Concluir Pedido (corrigida)
-- =====================================================================

CREATE OR REPLACE FUNCTION pedidos.p_concluir_pedido(idPedido bigint)
RETURNS varchar
AS
$$
DECLARE
    estoque_id bigint;
    quantidade_em_estoque bigint;
    quantidade_total_pedido bigint;
BEGIN
    -- Obtém o estoque ativo (mantendo sua lógica original)
    SELECT MAX(id_estoque)
    INTO estoque_id
    FROM estoques.estoque;

    IF estoque_id IS NULL THEN
        RETURN 'Nenhum estoque encontrado';
    END IF;

    -- Quantidade disponível no estoque
    SELECT COALESCE(qtd_atual, 0)
    INTO quantidade_em_estoque
    FROM estoques.estoque
    WHERE id_estoque = estoque_id;

    -- Quantidade total do pedido
    SELECT COALESCE(SUM(ite.quantidade * COALESCE(prod.unidades, 1)), 0)
    INTO quantidade_total_pedido
    FROM pedidos.item_pedido ite
    LEFT JOIN produtos.produto prod ON prod.id_produto = ite.item
    WHERE ite.id_pedido = idPedido;

    -- Verifica estoque suficiente
    IF quantidade_total_pedido > quantidade_em_estoque THEN
        RETURN 'A quantidade do pedido é maior que a quantidade em estoque';
    END IF;

    -- Insere baixa
    INSERT INTO estoques.baixa_estoque (
        id_produto,
        id_estoque,
        id_pedido,
        quantidade,
        baixado
    )
    SELECT 
        ite.item,
        estoque_id,
        idPedido,
        ite.quantidade,
        true
    FROM pedidos.item_pedido ite
    WHERE ite.id_pedido = idPedido;

    -- Atualiza situação do pedido
    UPDATE pedidos.pedido
    SET situacao = 5
    WHERE id_pedido = idPedido;

    -- Atualiza situação do orçamento
    UPDATE orcamentos.orcamento
    SET situacao = 5
    WHERE id_orcamento = (
        SELECT id_orcamento
        FROM pedidos.pedido ped
        WHERE ped.id_pedido = idPedido
    );

    -- Atualiza situação da versão
    UPDATE orcamentos.versao_orcamento
    SET situacao = 5
    WHERE id_versao_orcamento = (
        SELECT id_versao_orcamento
        FROM pedidos.pedido ped
        WHERE ped.id_pedido = idPedido
    );

    RETURN 'success';
END;
$$ LANGUAGE plpgsql;

-- =====================================================================
--  FUNÇÃO: Baixar Estoque Após Inserção na Tabela baixa_estoque
-- =====================================================================

CREATE OR REPLACE FUNCTION estoques.p_baixar_estoque()
RETURNS TRIGGER
AS
$$
DECLARE
    estoque_id bigint;
    unidades_produto bigint;
    quantidade_final bigint;
BEGIN
    -- Estoque ativo (mantém sua regra original)
    SELECT MAX(id_estoque)
    INTO estoque_id
    FROM estoques.estoque;

    IF estoque_id IS NULL THEN
        RAISE EXCEPTION 'Nenhum estoque encontrado para baixa';
    END IF;

    -- Unidades por produto
    SELECT COALESCE(unidades, 1)
    INTO unidades_produto
    FROM produtos.produto
    WHERE id_produto = NEW.id_produto;

    quantidade_final := NEW.quantidade * unidades_produto;

    UPDATE estoques.estoque
    SET qtd_atual = qtd_atual - quantidade_final
    WHERE id_estoque = estoque_id;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- =====================================================================
--  TRIGGER: Baixar Estoque Depois da Inserção
-- =====================================================================

DROP TRIGGER IF EXISTS t_baixar_estoque ON estoques.baixa_estoque;

CREATE TRIGGER t_baixar_estoque
AFTER INSERT ON estoques.baixa_estoque
FOR EACH ROW
EXECUTE PROCEDURE estoques.p_baixar_estoque();
