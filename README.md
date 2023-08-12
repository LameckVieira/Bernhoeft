# Bernhoeft

# A Introdução e os requisitos para realizar a criação:

Instruções
Desenvolver uma API utilizando C# para gerenciamento de produtos. Fica a critério do
candidato (a) escolher o banco de dados, arquitetura, bibliotecas e frameworks que serão
utilizados no desenvolvimento. Deverá haver um arquivo README com instruções para a
execução da API.
API
A API desenvolvida em C# deverá realizar as seguintes ações:
Cadastrar categoria
Alterar categoria
Listar categorias (Deve haver a possibilidade de filtrar por nome da categoria e situação
da categoria)
Cadastrar produto
Alterar produto
Listar produtos (Deve haver a possibilidade de filtrar por categoria do produto, descrição
do produto e situação do produto)
Estrutura do banco de dados
A estrutura descrita aqui dispõe apenas das informações básicas de cada tabela sendo
necessária a inclusão de outros campos caso ache necessário.
Categoria
Id
Nome
Situação (Ativo ou inativo)
Produto
Id
Nome
Descrição
Preço
Situação (Ativo ou inativo)

# Minha API

Bem-vindo à documentação da Minha API! Esta API oferece recursos para realizar operações CRUD de usuários, tipos de usuário, produtos, categorias e autenticação.

## Endpoints

A seguir estão os principais endpoints disponíveis na API:

### Usuários

- **GET /api/usuarios**: Obter todos os usuários.
- **GET /api/usuarios/{id}**: Obter um usuário específico.
- **POST /api/usuarios**: Criar um novo usuário.
- **PUT /api/usuarios/{id}**: Atualizar um usuário existente.
- **DELETE /api/usuarios/{id}**: Excluir um usuário.
- **GET /api/usuarios/byname/{nome}**: Obter um usuário específico pornome.

### Tipos de Usuário

- **GET /api/tipousuarios**: Obter todos os usuários.
- **GET /api/tipousuarios/{id}**: Obter um usuário específico por id.
- **POST /api/tipousuarios**: Criar um novo usuário.
- **PUT /api/tipousuarios/{id}**: Atualizar um usuário existente.
- **DELETE /api/tipousuarios/{id}**: Excluir um usuário.
- **GET /api/usuarios/byname/{tipo}**: Obter um usuário específico por tipo.

### Produtos

- **GET /api/produto**: Obter todos os produto.
- **GET /api/produto/buscarporid/{id}**: Obter um produto específico por id.
- **GET /api/produto/buscarporcategoriaid/{id}**: Obter um produto específico pela categoriaid.
- **GET /api/produto/buscarpordescricao/{id}**: Obter um produto específico pela descricao.
- **GET /api/produto/buscarporsitucao/{id}**: Obter um produto específico pela situacao.
- **POST /api/produto/**: Criar um novo produto.
- **PUT /api/produto/atualizarproduto{id}**: Atualizar um produto existente.
- **DELETE /api/produto/deletarproduto{id}**: Excluir um produto.

### Categorias

- **GET /api/categoria**: Obter todos as categorias.
- **GET /api/categoria/buscarporid{id}**: Obter uma categoria específico.
- **GET /api/categoria/buscarpordescricao/{id}**: Obter uma categoria específico pela descricao.
- **GET /api/categoria/buscarporsitucao/{id}**: Obter uma categoria específico pela situacao.
- **POST /api/categoria**: Criar uma categoria.
- **PUT /api/categoria/{id}**: Atualizar uma categoria existente.
- **DELETE /api/categoria/{id}**: Excluir uma categoria.

### Login

- **POST /api/login**: Autenticar um usuário e pegar o Token

## Como Usar

1. Clone este repositório.
2. Instale as dependências (se aplicável).
3. Pegue o arquivo de criação do banco na pasta script e rode em um banco de dados SQLSERVER
5. Execute a API.
6. Acesse a documentação interativa em `[http://localhost:porta/swagger](http://localhost:5000/index.html)`.

## Contato
4. Instale o [Sql Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
5. instale o [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/)
   
## Contato

- Celular: (11) 9 9378-5259
- Email: lameck.v.barbosa@gmail.com
