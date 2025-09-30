# AuroraTrace - Challenge FIAP 2025

---

## Visão Geral da Solução

Nossa solução é uma aplicação completa para gerenciar as motos dentro dos pátios da Mottu, controlando em que setor elas estão, seus status (Disponível, Manutenção, Ocupada) e seus eventos de entrada/saída.

A solução é composta por três repositórios principais:

| Repositório | Tecnologia | URL                                                                                   |
| :--- | :--- |:--------------------------------------------------------------------------------------|
| **Mobile App** | React Native/Expo | [Mobile](https://github.com/Challenge2025-Aurora/aurora-mobile)                       |
| **API Java** | Spring Boot | [Java](https://github.com/Challenge2025-Aurora/challenge2025-java) (Este Repositório) |
| **API C#** | .NET Core | [C#](https://github.com/Challenge2025-Aurora/aurora-cs)                               |

## Integrantes do Grupo

- **Felipe Prometti** - RM555174 - 2TDSPM
- **Maria Eduarda Pires** - RM558976 - 2TDSPZ
- **Samuel Damasceno** - RM558876 - 2TDSPM

## Arquitetura e Estrutura do Código

O projeto segue Clean Architecture e Domain Driven Design), separando as responsabilidades em quatro projetos principais para garantir a manutenibilidade, testabilidade e escalabilidade:

```plaintext
📦 src
 ┣ 📂 Api             -> controllers
 ┣ 📂 Application     -> DTOs, services
 ┣ 📂 Domain          -> entidades, exceptions
 ┗ 📂 Infrastructure  -> mappings, migrations, conexão com banco de dados
```

## Detalhes da Arquitetura:

- Entidades Ricas (no Domain): Entidades como Moto possuem lógica de negócio (AtualizarStatus) protegida por private setters

- DRY: Utilização de classes genéricas (controller e service) para evitar repetição de código

- Retornos de API padronizados com códigos HTTP corretos (201 Created, 204 No Content).

- HATEOAS: Geração automática de links de navegação (self, update, delete) nas respostas da API.


## Tecnologias Usadas (.NET)

| Categoria | Tecnologia                  |
| :--- |:----------------------------|
| **Linguagem** | C# / .NET 9                     |
| **ORM** | Entity Framework Core 7               |
| **Banco de Dados** | Oracle DB                 |
| **Mapeamento** | AutoMapper                   |
| **Documentação** | Swagger                     |

## Como Rodar o Projeto

### Pré-requisitos:
- .NET SDK 9.0 instalado.
- Variável de ambiente ORACLE_CONN ou connection string no appsettings.json configurada para o seu banco Oracle.

1. Clonar o projeto:

   ```bash
   git clone https://github.com/samueldamasceno/challenge-2025-cs.git
   ```

2. Aplicar migrations (Obrigatório para Criar/Atualizar as Tabelas):

   ```bash
	# Navegue até o projeto de infraestrutura
	cd aurora-cs/src/Infrastructure 
	dotnet ef database update
   ```

4. Executar API:
   ```bash
	# Navegue até o projeto da API
	cd ../Api
	dotnet run
   ```

5. Testar endpoints no Swagger:
   ```bash
   http://localhost:5002/swagger
   ```

---
