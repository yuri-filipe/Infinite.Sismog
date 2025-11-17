--PEGA TODOS OS ITENS DO PEDIDO E SALVA EM BAIXA DE ESTOQUE

  
CREATE OR REPLACE FUNCTION pedidos.p_concluir_pedido(idPedido bigint)
RETURNS varchar
AS
$$
DECLARE
    situacao_id bigint;
    estoque_id bigint;
    quantidade_estoque bigint;
    quantidade_pedido bigint;
BEGIN
    SELECT MAX(id_estoque) INTO estoque_id FROM estoques.estoque;

    SELECT situacao INTO situacao_id FROM pedidos.pedido WHERE id_pedido = idPedido;

    SELECT qtd_atual INTO quantidade_estoque FROM estoques.estoque WHERE id_estoque = estoque_id;

    SELECT SUM(quantidade * unidades) INTO quantidade_pedido FROM pedidos.item_pedido
    LEFT JOIN produtos.produto ON id_produto = item
    WHERE id_pedido = idPedido;
    
-- verifica se a quantidade do pedido é maior que a quantidade em estoque
    IF quantidade_pedido > quantidade_estoque THEN
        RETURN 'A quantidade do pedido é maior que a quantidade em estoque';
    ELSE
        INSERT INTO estoques.baixa_estoque ( id_produto, id_estoque, id_pedido, quantidade, baixado)

        SELECT item, estoque_id, idPedido, quantidade, true
        FROM pedidos.item_pedido 
        WHERE id_pedido = idPedido;

        UPDATE pedidos.pedido SET situacao = 5 WHERE id_pedido = idPedido;

        UPDATE orcamentos.orcamento orca SET situacao = 5 WHERE orca.id_orcamento = 
        (SELECT id_orcamento FROM pedidos.pedido ped WHERE ped.id_pedido = idPedido);

        UPDATE orcamentos.versao_orcamento versao SET situacao = 5 WHERE versao.id_versao_orcamento =
        (SELECT id_versao_orcamento FROM pedidos.pedido ped WHERE ped.id_pedido = idPedido);

        RETURN 'success';
    END IF;

END
$$ LANGUAGE plpgsql;


-- PEGA TODOS OS ITENS DA BAIXA E SUBTRAI DA QUANTIDADE ATUAL DO ESTOQUE



CREATE TRIGGER t_baixar_estoque
AFTER INSERT ON estoques.baixa_estoque
FOR EACH ROW
EXECUTE PROCEDURE estoques.p_baixar_estoque();
 
 
 
CREATE OR REPLACE FUNCTION estoques.p_baixar_estoque()
RETURNS TRIGGER
AS
$$
DECLARE
    estoque_id bigint;
    quantidade_estoque bigint;
    unidades_produto bigint;
    quantidade_a_ser_baixada bigint;
BEGIN
    SELECT MAX(id_estoque) INTO estoque_id FROM estoques.estoque;

    SELECT qtd_atual INTO quantidade_estoque FROM estoques.estoque WHERE id_estoque = estoque_id;
    
    -- pega a quantidade individual do produto e multiplica pela quantidade do item
    SELECT unidades INTO unidades_produto FROM produtos.produto WHERE id_produto = NEW.id_produto;

    quantidade_a_ser_baixada = NEW.quantidade * unidades_produto;

    UPDATE estoques.estoque SET qtd_atual = quantidade_estoque - quantidade_a_ser_baixada WHERE id_estoque = estoque_id;
    
    RETURN NEW;
END
$$ LANGUAGE plpgsql;
