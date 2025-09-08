# AuroraTrace API

API para o Challenge de 2025, focada em rastreamento e gerenciamento de motos, funcionários e pátios. O projeto usa Clean Architecture, DDD e Boas Práticas de Clean Code em .NET 8.

---

## Estrutura do Projeto

```plaintext
📦 src
 ┣ 📂 Api             -> controllers
 ┣ 📂 Application     -> DTOs, services
 ┣ 📂 Domain          -> entidades, exceptions
 ┗ 📂 Infrastructure  -> mappings, migrations, conexão com banco de dados
```

---

- Entidades ricas: Moto e Patio com métodos e lógica de negócio.

- Value Object: Localizacao incorporado às entidades.

- Enum e exceção personalizada: StatusMoto e DomainException.

- Classes base BaseService e BaseController para evitar repetição de código.

- CRUD completo para motos, funcionários e pátios.

- Migrations aplicadas usando variável de ambiente ORACLE_CONN.

- Swagger configurado com todos os endpoints.

---

## Tecnologias utilizadas

- .NET 8
- ASP.NET Core
- Entity Framework Core
- Oracle Database
- Swagger
- AutoMapper

---

## Como executar

1. Clonar o projeto:

   ```
   git clone https://github.com/samueldamasceno/challenge-2025-cs.git
   ```

2. Configurar a variável de ambiente ORACLE_CONN com a string de conexão:

   ```
   Data Source=oracle.fiap.com.br:1521/orcl;User ID=usuario;Password=senha
   ```

3. Aplicar migrations:

   ```
   cd src/Infrastructure
   dotnet ef database update
   ```

4. Executar API:
   ```
   cd ../Api
   dotnet run
   ```

5. Testar endpoints no Swagger:
   ```
   http://localhost:5002/swagger
   ```

> Obs: o projeto está configurado para buscar a string de conexão com a variável de ambiente ORACLE_CONN, em vez de armazená-la no appsettings.json, por segurança.

---

## Integrantes

- 2TDSPM - RM555174 - Felipe Menezes
- 2TDSPZ - RM558976 - Maria Eduarda
- 2TDSPM - RM558876 - Samuel Damasceno


