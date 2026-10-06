# DeskFlow API — Gestão de Chamados

## Sobre o Projeto

A **DeskFlow API** é uma Web API RESTful desenvolvida em **.NET 10**, utilizando **Entity Framework Core** e **SQL Server**.

O sistema permite cadastrar categorias, abrir e acompanhar chamados, adicionar interações e controlar o status dos atendimentos.

## Tecnologias

* .NET 10 / Web API
* Entity Framework Core 10
* SQL Server
* OpenAPI

## Membros

* Vitor Santos

## Como Executar

### Pré-requisitos

* .NET SDK 10
* SQL Server

### Passos

1. Clone o repositório:

```bash
git clone https://github.com/VitorSantosPereira/projetoFinalModulo.git
```

2. Acesse a pasta do projeto:

```bash
cd DeskflowAPI
```

3. Configure a conexão com o SQL Server no `appsettings.json`.

4. Execute as migrations:

```bash
dotnet ef database update
```

5. Execute a API:

```bash
dotnet run
```

A API estará disponível em:

```text
http://localhost:5284
```

## Status do Chamado

* **Aberto** — Chamado registrado.
* **EmAndamento** — Chamado em atendimento.
* **Fechado** — Chamado encerrado com solução.

## Arquitetura

* **Controllers** — Endpoints e requisições HTTP.
* **Services** — Regras de negócio e validações.
* **Repositories** — Acesso ao banco de dados.
* **Models** — Entidades do sistema.
* **Data** — Configuração do Entity Framework e banco.
* **Middlewares** — Tratamento global de erros.

## Principais Funcionalidades

* Cadastro e gerenciamento de categorias.
* Abertura e acompanhamento de chamados.
* Alteração de status dos chamados.
* Registro de interações.
* Encerramento com solução.
* Filtros por status, prioridade e categoria.
* Tratamento global de erros.

## Vídeo de Apresentação

[Link para o vídeo de demonstração](https://youtu.be/CYZQZyRUbI8)