CREATE OR REPLACE FUNCTION orcamentos.p_aprovar_orcamento(idVersao bigint)
RETURNS varchar AS
$BODY$

DECLARE
idOrcamento bigint;

BEGIN
    SELECT id_orcamento INTO idOrcamento FROM orcamentos.versao_orcamento WHERE id_versao_orcamento = idVersao;

   UPDATE orcamentos.orcamento orca SET situacao = 2 WHERE orca.id_orcamento = idOrcamento;
   UPDATE orcamentos.versao_orcamento ver SET situacao = 2 WHERE ver.id_versao_orcamento = idVersao;
    
    -- INSERIR DADOS NA TABELA PEDIDOS
    INSERT INTO pedidos.pedido(
	id_orcamento, id_versao_orcamento, id_cliente, entrega, retirada, valor_produtos, valor_entrega, desconto, acrescimo, subtotal, total,forma_de_pagamento, data_criacao, situacao)

    SELECT orca.id_orcamento, idVersao, orca.id_cliente, orca.entrega, orca.retirada, ver.subtotal, ver.valor_entrega, ver.desconto, ver.acrescimo, ver.subtotal, ver.total, ver.forma_de_pagamento, current_date, 2 
    FROM orcamentos.versao_orcamento ver 
    INNER JOIN orcamentos.orcamento orca
    ON orca.id_orcamento = ver.id_orcamento 
    WHERE ver.id_versao_orcamento = idVersao;

	RETURN 'success';
END;$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;


-- TRIGGER PARA RECUPERAR OS ITENS DA VERSAO APROVADA
CREATE TRIGGER t_inserir_itens_pedido
AFTER INSERT ON pedidos.pedido
FOR EACH ROW
EXECUTE PROCEDURE pedidos.p_inserir_itens_pedido();
 

CREATE OR REPLACE FUNCTION pedidos.p_inserir_itens_pedido()
RETURNS TRIGGER
AS
$$
DECLARE
versao_orcamento bigint;
BEGIN
    SELECT pp.id_versao_orcamento INTO versao_orcamento FROM pedidos.pedido pp WHERE id_pedido = NEW.id_pedido;

    -- INSERIR DADOS NA TABELA ITENS_PEDIDOS    
    INSERT INTO pedidos.item_pedido (id_pedido, item, quantidade, preco_unitario, desconto)

    SELECT NEW.id_pedido, ite.item, ite.quantidade, ite.preco_unitario, ite.desconto
    FROM orcamentos.item_versao_orcamento ite
    INNER JOIN orcamentos.versao_orcamento ver
    ON ite.id_versao_orcamento = ver.id_versao_orcamento
    WHERE ver.id_versao_orcamento = versao_orcamento;
	RETURN NEW;
END
$$ LANGUAGE plpgsql;

