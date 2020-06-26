# Desafio Softplan

Conforme o desafio proposto, foi criado duas APIs para demostrar meu conhecimento com a stack **Asp.Net Core**.

## Recursos utilizados

- [x] .Net Core 3.1
- [x] Swagger
- [x] Docker
- [x] Docker Compose
- [x] HealthChecks
- [x] Testes unitários
- [ ] Testes de integração

## Testando as APIs

``` bash
# buildando imagens
docker-compose build

# executando serviços
ASPNETCORE_ENVIRONMENT=Staging docker-compose up -d

# testando saúde dos serviços
curl localhost:5000/health
curl localhost:5001/health
```