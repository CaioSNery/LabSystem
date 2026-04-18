# LabSystem

Projeto criado com o objetivo de estudar e entender conceitos de arquitetura backend utilizando .NET.

A ideia não é ser um sistema completo, mas sim um laboratório para aplicar conceitos que aparecem em sistemas reais.

## 🚀 Tecnologias

- .NET 8
- ASP.NET Core Web API
- MemoryCache
- BackgroundService
- Polly (retry)

## 🧠 Conceitos aplicados

Durante o desenvolvimento do projeto foram estudados e implementados:

### ✔️ Middleware e Pipeline

- Entendimento do fluxo de requisição no ASP.NET Core
- Criação de middleware de logging para registrar:
  - método HTTP
  - endpoint
  - status code
  - tempo de execução
- Middleware de tratamento global de erros

### ✔️ Tratamento global de exceções

- Centralização de erros em um único ponto
- Retorno de respostas padronizadas para a API

### ✔️ Cache em memória

- Implementação de cache com `IMemoryCache`
- Conceitos de cache hit e cache miss
- Estratégia de invalidação de cache ao alterar dados

### ✔️ Background Service

- Processamento de tarefas em segundo plano
- Simulação de fila utilizando `ConcurrentQueue`
- Separação entre requisição HTTP e processamento

### ✔️ Resiliência (Retry)

- Simulação de falhas em serviços externos
- Implementação de retry com Polly

## 📌 Estrutura do projeto

-Controllers
-Services
-Repositories
-Middlewares
-Background
-Infrastructure
-Models
-DTOs


## 🧪 Como executar

dotnet restore
dotnet run

A API será iniciada em:
http://localhost:xxxx

📮 Testes

Os endpoints podem ser testados utilizando Postman.

Exemplo:
GET /api/produtos
POST /api/produtos

🎯 Objetivo
Esse projeto faz parte dos meus estudos em backend com .NET, com foco em entender como sistemas funcionam internamente, indo além de apenas criar endpoints.

📈 Próximos passos
Melhorar estrutura da aplicação
Adicionar logs estruturados
Evoluir para cenários mais próximos de produção

