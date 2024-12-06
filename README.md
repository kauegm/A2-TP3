# README - API para Sistema de Distribuidora de Bebidas

## Sobre a API
Essa API foi desenvolvida em **.NET** para atender as operações de um sistema para uma distribuidora de bebidas.  
O principal objetivo é gerenciar as informações de **categorias**, **clientes**, **estoques**, **fornecedores**, **pedidos** e **produtos**.

O sistema segue o modelo de relacionamento **1:N** entre suas entidades, permitindo uma integração consistente e eficiente.  
Todas as operações (**CRUD - Create, Read, Update, Delete**) são acessíveis exclusivamente através do **Swagger**, oferecendo uma interface amigável para a documentação e execução das rotas.

---

## Recursos Implementados

A API contém 6 módulos principais:

### 1. **Categoria**
- **Objetivo**: Gerenciar as categorias dos produtos.
- **Operações CRUD**:
  - Criar uma nova categoria.
  - Listar todas as categorias.
  - Consultar uma categoria específica.
  - Atualizar uma categoria existente.
  - Excluir uma categoria.

### 2. **Cliente**
- **Objetivo**: Gerenciar as informações dos clientes.
- **Operações CRUD**:
  - Criar um novo cliente.
  - Listar todos os clientes.
  - Consultar um cliente específico.
  - Atualizar informações do cliente.
  - Excluir um cliente.

### 3. **Estoque**
- **Objetivo**: Controlar a entrada, saída e disponibilidade dos produtos no estoque.
- **Operações CRUD**:
  - Adicionar itens ao estoque.
  - Listar o estoque.
  - Consultar um item específico no estoque.
  - Atualizar dados de um item.
  - Remover itens do estoque.

### 4. **Fornecedores**
- **Objetivo**: Gerenciar os fornecedores que abastecem a distribuidora.
- **Operações CRUD**:
  - Cadastrar um novo fornecedor.
  - Listar todos os fornecedores.
  - Consultar informações de um fornecedor específico.
  - Atualizar dados do fornecedor.
  - Excluir um fornecedor.

### 5. **Pedidos**
- **Objetivo**: Gerenciar os pedidos realizados.
- **Operações CRUD**:
  - Criar um novo pedido.
  - Listar todos os pedidos.
  - Consultar um pedido específico.
  - Atualizar informações de um pedido.
  - Excluir um pedido.

### 6. **Produtos**
- **Objetivo**: Gerenciar os produtos comercializados pela distribuidora.
- **Operações CRUD**:
  - Cadastrar um novo produto.
  - Listar todos os produtos.
  - Consultar um produto específico.
  - Atualizar informações de um produto.
  - Excluir um produto.

---

## Tecnologias Utilizadas

- **.NET**: Framework principal para o desenvolvimento da API.
- **Swagger**: Ferramenta para documentação e execução interativa das rotas.
- **Entity Framework**: Para gerenciar o banco de dados e realizar as operações CRUD.

---

## Configuração do Ambiente

### Pré-requisitos
- Visual Studio Community ou superior.
- SDK do .NET instalado (versão compatível com o projeto).

### Passos para Configuração

1. Clone o repositório em sua máquina:
   ```bash
   git clone <URL_DO_REPOSITORIO>
