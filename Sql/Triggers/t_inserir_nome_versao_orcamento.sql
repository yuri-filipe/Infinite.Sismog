CREATE TRIGGER t_inserir_nome_versao_orcamento
AFTER INSERT ON orcamentos.versao_orcamento
FOR EACH ROW
EXECUTE PROCEDURE orcamentos.p_inserir_nome_versao_orcamento();
 
 
 
CREATE OR REPLACE FUNCTION orcamentos.p_inserir_nome_versao_orcamento()
RETURNS TRIGGER
AS
$$
DECLARE
    numero_ultima_versao bigint;
BEGIN
    SELECT COALESCE(MAX(numero_versao_orcamento),0) + 1 INTO numero_ultima_versao FROM orcamentos.versao_orcamento WHERE id_orcamento = NEW.id_orcamento;
    
    UPDATE orcamentos.versao_orcamento SET numero_versao_orcamento = numero_ultima_versao, 
    nome_versao_orcamento = 'versão ' || numero_ultima_versao 
    WHERE id_versao_orcamento = NEW.id_versao_orcamento;

    RETURN NEW;
END
$$ LANGUAGE plpgsql;


