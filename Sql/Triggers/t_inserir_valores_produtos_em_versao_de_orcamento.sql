CREATE TRIGGER t_inserir_valores_produtos_em_versao_de_orcamento
AFTER INSERT ON orcamentos.item_versao_orcamento
FOR EACH ROW
EXECUTE PROCEDURE orcamentos.p_inserir_valores_produtos_em_versao_de_orcamento();
 
 
 
CREATE OR REPLACE FUNCTION orcamentos.p_inserir_valores_produtos_em_versao_de_orcamento()
RETURNS TRIGGER
AS
$$
DECLARE
 valor_total_item NUMERIC(10,2);
desconto_item NUMERIC(10,2);
subtotal_versao NUMERIC(10,2);
desconto_versao NUMERIC(10,2);
BEGIN
    SELECT ROUND((quantidade * preco_unitario) - desconto, 2) INTO valor_total_item 
	FROM orcamentos.item_versao_orcamento
    WHERE id_versao_orcamento = NEW.id_versao_orcamento;
    
    SELECT COALESCE(desconto, 0.00) INTO desconto_item 
	FROM orcamentos.item_versao_orcamento
    WHERE id_versao_orcamento = NEW.id_versao_orcamento;

    SELECT COALESCE(subtotal, 0.00) INTO subtotal_versao 
    FROM orcamentos.versao_orcamento
    WHERE id_versao_orcamento = NEW.id_versao_orcamento;

    SELECT COALESCE(desconto, 0.00) INTO desconto_versao
    FROM orcamentos.versao_orcamento
    WHERE id_versao_orcamento = NEW.id_versao_orcamento;

    UPDATE orcamentos.versao_orcamento SET subtotal = ROUND(subtotal_versao + valor_total_item, 2),
    desconto = ROUND(desconto_versao + desconto_item, 2),
    total = ROUND(subtotal_versao + valor_total_item - desconto_versao, 2)
    WHERE id_versao_orcamento = NEW.id_versao_orcamento;

    RETURN NEW;
END
$$ LANGUAGE plpgsql;


