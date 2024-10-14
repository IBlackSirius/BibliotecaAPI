# Biblioteca Digital - README

## Visão Geral

Este é um projeto de Biblioteca Digital, desenvolvido como parte de uma avaliação técnica para demonstrar habilidades no desenvolvimento de APIs RESTful com ASP.NET Core, utilização de Blazor para o front-end e padrões de projeto como MVC e Repository Pattern.

A aplicação possui funcionalidades para gerenciar livros, autores e gêneros. O back-end utiliza o Entity Framework Core com um banco de dados em memória, enquanto o front-end permite que o usuário visualize, adicione, edite e remova registros.

## Estrutura do Projeto

- **Backend (API)**:

  - Desenvolvido em ASP.NET Core, seguindo o padrão MVC e utilizando o Entity Framework Core para persistência de dados.
  - API RESTful com endpoints CRUD para as entidades Livro, Autor e Gênero.
  - Repository Pattern é utilizado para promover a separação de responsabilidades e manutenção do código.

- **Frontend (Blazor)**:

  - Desenvolvido em Blazor, permitindo interação com a API para gerenciar os registros de livros, autores e gêneros.
  - A interface é responsiva e intuitiva, garantindo uma boa experiência do usuário.

## Instruções para Executar a Aplicação

### Requisitos

- .NET 6 SDK ou superior.
- Visual Studio 2022 ou Visual Studio Code.

### Passos para Executar

1. **Clone o Repositório**:

   ```bash
   git clone <URL_DO_REPOSITORIO>
   ```

2. **Navegue até a Pasta do Projeto**:

   ```bash
   cd BibliotecaDigital
   ```

3. **Restaure as Dependências**:
   No terminal, execute o comando para restaurar todas as dependências do projeto:

   ```bash
   dotnet restore
   ```

4. **Execute o Backend (API)**:
   Navegue até a pasta `BibliotecaAPI` e execute o comando:

   ```bash
   dotnet run
   ```

5. **Execute o Frontend (Blazor)**:
   Em outra janela do terminal, navegue até a pasta `BibliotecaBlazor` e execute:

   ```bash
   dotnet run
   ```

6. **Acesse a Aplicação**:
   Abra o navegador e acesse a aplicação no seguinte endereço:

   ```
   https://localhost:7005/
   ```



```

## Dependências

- **Microsoft.EntityFrameworkCore.InMemory**: Para persistência de dados em um banco de dados em memória.
- **Microsoft.EntityFrameworkCore**: Framework de acesso a dados.
- **FluentValidation**: Usado para validação das entidades Autor, Gênero e Livro.
- **Blazor**: Framework para o desenvolvimento de interfaces responsivas.

## Arquitetura do Projeto

- **Camada de Aplicação**: Composta pela aplicação Blazor, que consome a API para fornecer uma interface amigável para o usuário.
- **Camada de API**: Desenvolvida em ASP.NET Core, seguindo padrões de design MVC e Repository Pattern, garantindo uma boa separação de responsabilidades.
- **Entity Framework Core**: Utilizado para persistência dos dados. O banco de dados em memória é utilizado para fins de demonstração e desenvolvimento.

```
