# AuroraTrace API

API para o Challenge de 2025, focando numa solução para rastreamento e monitoramento de motos, com informações de localização, pátio, status e funcionário responsável.

## Rotas disponíveis

### Motos
- `GET /api/moto`
- `GET /api/moto/{id}`
- `GET /api/moto/porplaca?placa=ABC1234`
- `POST /api/moto`
- `PUT /api/moto/{id}`
- `DELETE /api/moto/{id}`

### Funcionários
- `GET /api/funcionario`
- `GET /api/funcionario/{id}`
- `POST /api/funcionario`
- `PUT /api/funcionario/{id}`
- `DELETE /api/funcionario/{id}`

### Apenas leitura
- `GET /api/patio`
- `GET /api/localizacao`
- `GET /api/camera`
- `GET /api/imagem`

## Tecnologias utilizadas

- .NET 8
- ASP.NET Core
- Entity Framework Core
- Oracle Database
- Swagger

## Instruções de execução

1. Configurar a connection string no arquivo `appsettings.json`
2. Aplicar as migrations com o comando: `dotnet ef database update`
3. Executar a aplicação: `dotnet run`
4. Acessar a documentação via Swagger:  
`https://localhost:5001/swagger`

## Integrantes

- 2TDSPM - RM558876 - Samuel Damasceno
- 2TDSPM - RM555174 - Felipe Menezes
- 2TDSPZ - RM558976 - Maria Eduarda


