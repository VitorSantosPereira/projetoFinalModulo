# API DeskFlow

## RF02 — Cadastrar Categoria

Cadastrar uma nova categoria.

**POST** `http://localhost:5284/api/categorias`

```json
{
  "nome": "Hardware e Computadores"
}
```

---

## RF03 — Listar e Buscar Categorias

Listar todas ou buscar uma categoria específica.

**GET** `http://localhost:5284/api/categorias`

**GET** `http://localhost:5284/api/categorias/{id}`

Exemplo:

**GET** `http://localhost:5284/api/categorias/1`

---

## RF04 — Atualizar e Deletar Categoria

Alterar ou excluir uma categoria, impedindo exclusão se houver chamados vinculados.

**PUT** `http://localhost:5284/api/categorias/{id}`

Exemplo:

**PUT** `http://localhost:5284/api/categorias/1`

```json
{
  "nome": "Software e Sistemas"
}
```

**DELETE** `http://localhost:5284/api/categorias/{id}`

Exemplo:

**DELETE** `http://localhost:5284/api/categorias/1`

---

## RF06 — Abrir Novo Chamado

Criar um novo chamado.

**POST** `http://localhost:5284/api/chamados`

```json
{
  "titulo": "Computador não liga",
  "descricao": "O computador do setor não está ligando.",
  "prioridade": "Alta",
  "solicitanteNome": "João",
  "categoriaId": 1
}
```

---

## RF07 — Iniciar Atendimento

Alterar o chamado de `Aberto` para `EmAndamento`.

**POST** `http://localhost:5284/api/chamados/{id}/iniciar`

Exemplo:

**POST** `http://localhost:5284/api/chamados/1/iniciar`

---

## RF08 — Encerrar Chamado

Encerrar o chamado informando a solução.

**POST** `http://localhost:5284/api/chamados/{id}/encerrar`

Exemplo:

**POST** `http://localhost:5284/api/chamados/1/encerrar`

```json
{
  "solucao": "Foi identificado um problema na fonte de alimentação. A fonte foi substituída."
}
```

---

## RF10 — Adicionar Interação

Adicionar uma interação a um chamado que não esteja fechado.

**POST** `http://localhost:5284/api/chamados/{id}/interacoes`

Exemplo:

**POST** `http://localhost:5284/api/chamados/1/interacoes`

```json
{
  "autor": "Técnico",
  "mensagem": "Vou iniciar o diagnóstico do computador."
}
```

---

## RF11 — Obter Detalhes do Chamado

Buscar o chamado com categoria e interações.

**GET** `http://localhost:5284/api/chamados/{id}`

Exemplo:

**GET** `http://localhost:5284/api/chamados/1`

---

## RF12 — Listagem com Filtros

Listar chamados utilizando filtros combinados.

**GET** `http://localhost:5284/api/chamados`

### Filtros

**Status:**

`http://localhost:5284/api/chamados?status=Fechado`

**Prioridade:**

`http://localhost:5284/api/chamados?prioridade=Alta`

**Categoria:**

`http://localhost:5284/api/chamados?categoriaId=1`

**Filtros combinados:**

`http://localhost:5284/api/chamados?status=Fechado&prioridade=Alta&categoriaId=1`

---

Gerado por IA para facilitar os testes.