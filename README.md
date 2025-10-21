# AuroraTrace - Challenge FIAP 2025

---

## Visão Geral da Solução

Nossa solução é uma aplicação completa para gerenciar as motos dentro dos pátios da Mottu, controlando em que setor elas estão, seus status (Disponível, Manutenção, Ocupada) e seus eventos de entrada/saída.

A solução é composta por três repositórios principais:

| Repositório | Tecnologia | URL                                                                                   |
| :--- | :--- |:--------------------------------------------------------------------------------------|
| **Mobile App** | React Native/Expo | [Mobile](https://github.com/Challenge2025-Aurora/aurora-mobile) |
| **API Java** | Spring Boot | [Java](https://github.com/Challenge2025-Aurora/challenge2025-java) |
| **API C#** | .NET Core | [C#](https://github.com/Challenge2025-Aurora/aurora-cs) |

---

## Integrantes do Grupo

- **Felipe Prometti** - RM555174 - 2TDSPM  
- **Maria Eduarda Pires** - RM558976 - 2TDSPZ  
- **Samuel Damasceno** - RM558876 - 2TDSPM  

---

## Arquitetura e Estrutura do Código

O projeto segue os princípios de **Clean Architecture** e **Domain Driven Design (DDD)**, garantindo alta manutenibilidade e clareza na separação de responsabilidades entre as camadas.

```plaintext
📦 src
 ┣ 📂 Api             -> Controllers e configuração de rotas (incluindo endpoint de health check)
 ┣ 📂 Application     -> DTOs, serviços e lógica de aplicação
 ┣ 📂 Domain          -> Entidades, enums e value objects
 ┗ 📂 Infrastructure  -> Repositórios e conexão com o banco MongoDB
```

---

## Detalhes da Arquitetura

- **Entidades Ricas (no Domain)**: Entidades como `Moto` e `Pátio` encapsulam lógica de negócio (ex: `AtualizarStatus`), com `private setters` para preservar a integridade dos dados.
- **Enums e Value Objects**: Mostram conceitos imutáveis e padronizados (`StatusMoto` e `Placa`)
- **MongoDB**: A aplicação agora usa **MongoDB** como banco de dados principal, substituindo o Oracle. Foram adicionados **dados iniciais automáticos (seed)** que populam o banco ao iniciar a API para testes locais
- **Health Endpoint**: Implementado o endpoint `/api/health` para verificar a saúde da aplicação e a conexão com o banco.

---

## Tecnologias Usadas (.NET)

| Categoria | Tecnologia |
| :--- |:----------------------------|
| **Linguagem** | C# / .NET 9 |
| **Banco de Dados** | MongoDB |
| **Mapeamento / ORM** | MongoDB.Driver |
| **Arquitetura** | Clean Architecture + DDD |
| **Documentação** | Swagger |

---

## Como Rodar o Projeto

### Pré-requisitos

- .NET SDK 9.0 instalado.  
- Docker instalado (para executar o MongoDB localmente).

---

### 1. Clonar o projeto

```bash
git clone https://github.com/Challenge2025-Aurora/aurora-cs.git
```

---

### 2. Rodar o MongoDB localmente

Com Docker instalado, execute:

```bash
docker run -d -p 27017:27017 --name aurora-mongo mongo:latest
```

Isso iniciará um container com o MongoDB disponível em `mongodb://localhost:27017`.

---

### 3. Configurar a conexão no `appsettings.json`

```json
"ConnectionStrings": {
  "MongoDb": "mongodb://localhost:27017"
}
```

---

### 4. Executar a API

```bash
cd src/Api
dotnet run
```

A API iniciará e criará automaticamente os dados iniciais no banco MongoDB.

---

### 5. Acessar o Swagger

```bash
http://localhost:5002/swagger
```

---

### 6. Verificar o Health Check

```bash
http://localhost:5002/api/health
```

Se tudo estiver configurado corretamente, o endpoint retornará o status de funcionamento da API e da conexão com o banco.

---

**AuroraTrace - Challenge FIAP 2025 | Sprint 4**
