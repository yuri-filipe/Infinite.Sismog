
INSERT INTO info.situacao (id_situacao, nome) VALUES
(1, 'Pendente'),
(2, 'Aprovado'),
(3, 'Reprovado'),
(4, 'Cancelado'),
(5, 'Concluído'),
(6, 'Em Análise'),
(7, 'Em Processamento'),
(8, 'Aguardando Pagamento'),
(9, 'Pago'),
(10, 'Faturado'),
(11, 'Separado para Entrega'),
(12, 'Em Transporte'),
(13, 'Entregue'),
(14, 'Devolvido'),
(15, 'Revisão Necessária'),
(16, 'Erro de Processamento');


INSERT INTO produtos.produto 
(nome_produto, descricao, unidades, preco_custo, preco_atacado, preco_varejo, tipo, peso, altura, observacao)
VALUES
('Óculos Solar Aviador Classic', 'Armação metálica com lentes polarizadas UV400.', 1, 45.90, 69.90, 99.90, 1, 0.120, 4.8, 'Mais vendido da loja.'),
('Lente Oftálmica Antirreflexo Blue Light', 'Lente resinada com filtro azul e tratamento UV.', 1, 18.50, 29.00, 49.90, 2, NULL, NULL, 'Ideal para uso em escritório.'),
('Armação Acetato Premium Preto Fosco', 'Armação robusta e leve com dobradiça flex.', 1, 32.00, 49.90, 89.90, 1, 0.050, 4.3, 'Modelo unissex.'),
('Lente Transitions Cinza', 'Lente fotossensível com escurecimento automático.', 1, 75.00, 110.00, 159.90, 2, NULL, NULL, 'Linha premium.'),
('Óculos Infantil Colorido', 'Armação leve em policarbonato com hastes ajustáveis.', 1, 12.00, 19.90, 34.90, 3, 0.030, 3.1, 'Acompanha case colorido.'),
('Lente Multifocal Premium', 'Lente multifocal de alta performance — corredor suave.', 1, 95.00, 140.00, 199.90, 2, NULL, NULL, 'Indicado para presbiopia.'),
('Armação Titanium UltraSlim', 'Armação super leve 100% titanium, resistente a impactos.', 1, 110.00, 170.00, 249.00, 1, 0.020, 4.0, 'Produto premium.'),
('Lente Monofocal White Clear', 'Lente monofocal branca com alta transparência.', 1, 10.00, 18.00, 29.90, 2, NULL, NULL, 'Excelente custo-benefício.'),
('Óculos Redondo Vintage', 'Modelo retro, haste metálica e lente anti-risco.', 1, 40.00, 60.00, 89.90, 1, 0.090, 4.7, 'Item com alta procura.'),
('Lente De Contato Gel Mensal', 'Lente gel silicone, oxigenação elevada.', 1, 55.00, 79.00, 109.90, 4, 0.005, NULL, 'Caixa com 2 unidades.');

INSERT INTO cadastro.cliente
(nome, cpf, rg, tipo, nascimento, idade, sexo, cliente_desde, observacao_cliente)
VALUES
('Ana Beatriz Ferreira', '431.228.910-04', '22.114.889-7', 1, '1989-03-12', 35, 'F', '2021-02-10', ''),
('Marcos Vinicius Duarte', '038.229.660-80', '12.998.772-3', 1, '1992-09-18', 32, 'M', '2020-11-25', ''),
('Fernanda Cristina Alves', '529.667.480-91', '44.991.231-1', 1, '1995-04-22', 29, 'F', '2022-06-03', ''),
('João Pedro Ribeiro', '149.882.120-52', '08.223.118-0', 1, '1987-08-10', 37, 'M', '2019-12-17', ''),
('Camila Souza Moreira', '628.440.590-06', '33.882.112-9', 1, '1990-07-30', 34, 'F', '2021-01-05', ''),
('Ricardo Augusto Silva', '272.880.800-64', '18.663.511-9', 1, '1986-02-14', 38, 'M', '2018-05-22', ''),
('Priscila Mendes Rocha', '817.778.390-72', '19.882.311-0', 1, '1994-06-19', 30, 'F', '2020-03-20', ''),
('Carlos Henrique Porto', '917.520.610-20', '16.331.882-7', 1, '1980-01-10', 44, 'M', '2017-08-11', ''),
('Letícia Moura Vasconcelos', '009.117.760-32', '33.882.991-1', 1, '2000-10-08', 24, 'F', '2023-07-14', ''),
('Gustavo Tavares Gomes', '838.661.790-65', '22.552.118-9', 1, '1998-11-25', 26, 'M', '2022-01-30', ''),
('Maria Eduarda Castro', '961.440.250-61', '44.119.882-4', 1, '1993-03-21', 31, 'F', '2019-09-16', ''),
('Diego Lima Torres', '440.551.980-99', '15.782.119-0', 1, '1985-09-03', 39, 'M', '2016-04-08', ''),
('Isabela Monteiro Santos', '339.778.540-77', '33.448.229-8', 1, '1996-05-27', 28, 'F', '2021-09-11', ''),
('Paulo Roberto Cardoso', '732.115.030-44', '11.226.337-4', 1, '1979-12-19', 45, 'M', '2015-06-29', ''),
('Helena Guimarães Peixoto', '268.772.560-30', '55.772.889-9', 1, '1997-01-11', 27, 'F', '2022-02-05', ''),
('Rodrigo Falcão Mendes', '116.449.810-09', '10.288.112-1', 1, '1991-06-08', 33, 'M', '2020-01-12', ''),
('Juliana Pires Azevedo', '727.558.900-67', '18.662.221-5', 1, '1994-09-14', 30, 'F', '2021-03-22', ''),
('Felipe Camargo Dutra', '115.990.780-32', '15.872.991-0', 1, '1990-04-30', 34, 'M', '2019-05-18', ''),
('Larissa Moraes Andrade', '338.217.660-02', '22.118.334-9', 1, '1988-07-25', 36, 'F', '2020-10-01', ''),
('Thiago Ferreira Lopes', '557.991.200-31', '55.992.118-6', 1, '1977-11-03', 47, 'M', '2014-09-15', ''),
('Clara Regina Bastos', '881.114.990-50', '29.772.882-0', 1, '1999-09-27', 25, 'F', '2023-04-10', ''),
('Vinícius de Araújo Costa', '779.227.530-21', '11.773.992-3', 1, '1992-02-09', 32, 'M', '2020-12-19', ''),
('Bianca Nogueira Ramos', '661.229.780-35', '33.991.123-0', 1, '1995-10-06', 29, 'F', '2021-11-02', ''),
('Rafael Matias Ribeiro', '339.552.440-07', '44.662.118-9', 1, '1986-08-21', 38, 'M', '2018-06-08', ''),
('Patrícia Franco Dias', '115.662.330-77', '11.662.881-0', 1, '1984-04-17', 40, 'F', '2017-03-13', ''),
('Douglas Santana Pinho', '774.118.050-15', '15.118.992-6', 1, '1983-01-26', 41, 'M', '2016-07-07', ''),
('Amanda Queiroz Farias', '991.332.660-00', '55.331.882-1', 1, '1991-09-22', 33, 'F', '2020-11-09', ''),
('Sérgio Albuquerque Lima', '886.119.990-22', '44.882.551-4', 1, '1989-12-31', 35, 'M', '2022-08-01', ''),
('Jéssica de Moura Paiva', '771.110.440-68', '17.772.665-9', 1, '1998-03-05', 26, 'F', '2023-01-14', ''),
('Guilherme Rocha Duarte', '550.882.730-49', '11.882.557-8', 1, '1994-05-17', 30, 'M', '2019-03-07', ''),
('Elaine Ferreira Correia', '225.663.780-00', '25.772.991-0', 1, '1987-11-12', 37, 'F', '2018-02-28', ''),
('Vitor Braga Teles', '772.114.990-43', '40.881.992-0', 1, '1999-06-23', 25, 'M', '2022-10-19', ''),
('Sabrina Oliveira Silva', '468.550.720-79', '26.445.118-2', 1, '1993-08-10', 31, 'F', '2021-04-22', ''),
('Hugo Freitas Ramos', '662.229.110-50', '55.228.112-6', 1, '1990-01-08', 34, 'M', '2020-02-17', ''),
('Mariana Duarte Pires', '889.552.330-92', '44.552.883-8', 1, '1994-12-01', 30, 'F', '2022-09-28', ''),
('Lucas Tavares Alves', '110.552.990-75', '18.110.552-1', 1, '1988-10-14', 36, 'M', '2017-08-16', ''),
('Renata Carvalho Mendes', '339.884.770-92', '33.661.118-4', 1, '1985-03-09', 39, 'F', '2020-06-05', ''),
('André Luiz Campos', '662.345.110-26', '55.772.446-1', 1, '1991-07-11', 33, 'M', '2019-09-20', ''),
('Juliana Oliveira Cunha', '771.220.998-43', '21.883.772-5', 1, '1996-02-17', 28, 'F', '2023-02-27', ''),
('Marcelo Alves Correa', '552.228.110-29', '18.662.992-0', 1, '1984-06-22', 40, 'M', '2017-05-10', ''),
('Isadora Linhares Souza', '337.556.990-81', '33.221.118-2', 1, '1997-03-25', 27, 'F', '2021-03-02', ''),
('Cristiano Vieira Torres', '227.661.980-09', '55.551.882-3', 1, '1993-09-01', 31, 'M', '2022-05-29', ''),
('Larissa Gomes Pinto', '883.441.220-90', '33.671.119-0', 1, '1999-05-12', 25, 'F', '2023-04-02', ''),
('Eduardo Carvalho Matos', '662.998.440-11', '55.772.441-0', 1, '1980-12-30', 44, 'M', '2016-06-19', ''),
('Maíra Ramos Figueiredo', '554.881.990-02', '11.881.550-4', 1, '1988-08-22', 36, 'F', '2019-03-25', ''),
('Renan Augusto Lopes', '771.887.770-50', '77.221.118-7', 1, '1991-05-07', 33, 'M', '2020-07-11', ''),
('Aline Santos Prado', '338.119.660-18', '21.773.552-0', 1, '1993-02-15', 31, 'F', '2021-05-08', '');

INSERT INTO estoques.estoque 
(nome_estoque, qtd_minima, qtd_atual, qtd_maxima, observacao)
VALUES
('Estoque Central', 50, 1500, 5000, 'Estoque principal da loja.');
INSERT INTO estoques.produto_estoque 
(id_produto, id_estoque, quantidade)
VALUES
(1, 1, 120),   -- Óculos Solar Aviador
(2, 1, 200),   -- Lente Blue Light
(3, 1, 150),   -- Armação Premium
(4, 1, 80),    -- Lente Transitions
(5, 1, 180),   -- Óculos Infantil
(6, 1, 60),    -- Lente Multifocal Premium
(7, 1, 40),    -- Armação Titanium UltraSlim
(8, 1, 220),   -- Lente Monofocal White Clear
(9, 1, 130),   -- Óculos Redondo Vintage
(10, 1, 90);   -- Lente de Contato Gel

INSERT INTO estoques.lote_estoque 
(id_produto, id_estoque, numero_lote, quantidade, validade)
VALUES
(1, 1, 'LOT-A01', 60, '2027-12-31'),
(1, 1, 'LOT-A02', 60, '2028-06-30'),

(2, 1, 'LOT-B01', 200, '2026-05-15'),

(3, 1, 'LOT-C01', 150, NULL),

(4, 1, 'LOT-D01', 80, '2027-02-20'),

(5, 1, 'LOT-E01', 180, '2027-11-01'),

(6, 1, 'LOT-F01', 60, NULL),

(7, 1, 'LOT-G01', 40, NULL),

(8, 1, 'LOT-H01', 220, NULL),

(9, 1, 'LOT-I01', 130, NULL),

(10, 1, 'LOT-J01', 90, '2026-04-01');


UPDATE estoques.estoque
SET qtd_atual = (
    SELECT SUM(quantidade)
    FROM estoques.produto_estoque
    WHERE id_estoque = 1
)
WHERE id_estoque = 1;

UPDATE estoques.estoque
SET qtd_atual = 1270
WHERE id_estoque = 1;
