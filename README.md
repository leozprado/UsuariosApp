# UsuariosApp

Projeto desenvolvido em **.NET 10** com arquitetura em camadas e foco em
autenticação e gerenciamento de usuários.

## 🏗️ Arquitetura

O projeto está dividido nas seguintes camadas:

-   **API** -- Camada de apresentação (endpoints REST)
-   **Domain** -- Regras de negócio e entidades
-   **Infra.Data** -- Persistência com Entity Framework (Code First)
-   **Tests** -- Testes de integração com XUnit e Fluent Assertions

## 🔧 Funcionalidades

-   **Autenticar usuário**
-   **Criar usuário**
-   **Obter dados do usuário**

## 🔐 Segurança

-   Autenticação via **JWT (JSON Web Token)**

## 🗄️ Banco de Dados

-   **Entity Framework Core**
-   Abordagem **Code First**

## 🧪 Testes

-   Testes de integração na API
-   **XUnit**
-   **Fluent Assertions**

## ▶️ Como executar

``` bash
dotnet restore
dotnet build
dotnet run --project UsuariosApp.API
```

## 📡 Swagger

A API pode ser testada online em:

https://usuariosapp-leonardo-dhgxczbqa4bhdgh0.canadacentral-01.azurewebsites.net/swagger/index.html

## 📁 Estrutura do Projeto

    UsuariosApp
    │
    ├── UsuariosApp.API
    ├── UsuariosApp.Domain
    ├── UsuariosApp.Infra.Data
    └── UsuariosApp.Tests

------------------------------------------------------------------------

Desenvolvido por **Leonardo Prado**
