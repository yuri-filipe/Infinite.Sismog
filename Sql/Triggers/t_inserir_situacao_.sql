CREATE TRIGGER t_inserir_situacao_orcamento
AFTER INSERT ON orcamentos.orcamento
FOR EACH ROW
EXECUTE PROCEDURE orcamentos.p_inserir_situacao_orcamento();
 
 
 
CREATE OR REPLACE FUNCTION orcamentos.p_inserir_situacao_orcamento()
RETURNS TRIGGER
AS
$$
DECLARE
BEGIN
    UPDATE orcamentos.orcamento SET situacao = 1 WHERE id_orcamento = NEW.id_orcamento;
    RETURN NEW;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER t_inserir_situacao_versao_orcamento
AFTER INSERT ON orcamentos.versao_orcamento
FOR EACH ROW
EXECUTE PROCEDURE orcamentos.p_inserir_situacao_versao_orcamento();
 
 
 
CREATE OR REPLACE FUNCTION orcamentos.p_inserir_situacao_versao_orcamento()
RETURNS TRIGGER
AS
$$
DECLARE
BEGIN
    UPDATE orcamentos.versao_orcamento SET situacao = 1 WHERE id_versao_orcamento = NEW.id_versao_orcamento;
    RETURN NEW;
END
$$ LANGUAGE plpgsql;