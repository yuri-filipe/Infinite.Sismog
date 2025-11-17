CREATE TRIGGER t_alterar_value
AFTER INSERT ON public.teste
FOR EACH ROW
EXECUTE PROCEDURE public.p_alterar_value();
 
 
 
CREATE OR REPLACE FUNCTION public.p_alterar_value()
RETURNS TRIGGER
AS
$$
DECLARE
BEGIN
    UPDATE public.teste SET valor = 'yuri filipe valentim de almeida' WHERE id = NEW.id;
    RETURN NEW;
END
$$ LANGUAGE plpgsql;


