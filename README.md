# Sismog - Sistema Modular de Gerenciamento de Orçamentos e Pedidos

Sistema em construção para gerenciar clientes, orçamentos, pedidos, entregas e retiradas
de produtos e serviços.

Seu principal foco, ser construído de tal forma que a exibição dos dados possa ser totalmente 
personalizada pelo usuário com a criação e aplicação de filtros de forma direta e em tempo real.

## Funcionalidades e Tecnologias utilizadas

- Backend construído em ASP NET + C#
- Banco de dados em Relacional PostgreSQL + Entity Framework Core
- Frontend construído em cshtml + Bootstrap
- Multiplataforma


## ⚠️ Importante

Realizar build:
docker build -t sismog:latest .

Gerar arquivo de imagem:
docker save -o sismog.tar sismog:latest

docker run --rm -it  -p 5000:5000/tcp  -e ASPNETCORE_ENVIRONMENT=Development --name sismog sismog:latest
docker run --rm -it  -p 5000:5000/tcp  -e ASPNETCORE_ENVIRONMENT=Production --name sismog sismog:latest
docker build --pull --rm -f "Dockerfile" -t sismog:latest "." 

## Feedback

Se você tiver algum feedback, por favor nos deixe saber por meio de yurifelipe64@hotmail.com


## Licença

[MIT](https://choosealicense.com/licenses/mit/)