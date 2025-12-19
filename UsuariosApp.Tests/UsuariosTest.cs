using Azure;
using Azure.Core;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using UsuariosApp.Domain.Dtos;

namespace UsuariosApp.Tests
{
    public class UsuariosTest
    {
        //Atributos
        private readonly HttpClient _client;
        private readonly Faker _faker;

        //Método construtor
        public UsuariosTest()
        {
            _client = new WebApplicationFactory<Program>().CreateClient();
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "Deve criar um usuário com sucesso na API.")]
        public void Deve_Criar_Usuario_Com_Sucesso()
        {
            //Arrange
            var request = new CriarContaRequest(
                    _faker.Person.FullName, //Nome do usuário
                    _faker.Internet.Email(), //Email do usuário
                    "@Teste2025" //Senha do usuário
                );

            //Act
            var response = _client.PostAsJsonAsync("api/usuarios/criar", request)?.Result;

            //Assert
            response?.StatusCode.Should().Be(HttpStatusCode.Created);

            //Ler e verificar os dados do usuário cadastrado
            var content = response?.Content.ReadFromJsonAsync<CriarContaResponse>()?.Result;

            content?.id.Should().NotBeEmpty();
            content?.nome.Should().Be(request.nome);
            content?.email.Should().Be(request.email);
        }

        [Fact(DisplayName = "Deve autenticar o usuário com sucesso na API.")]
        public void Deve_Autenticar_Usuario_Com_Sucesso()
        {
            //Arrange
            var criarContaRequest = new CriarContaRequest(
                    _faker.Person.FullName, //Nome do usuário
                    _faker.Internet.Email(), //Email do usuário
                    "@Teste2025" //Senha do usuário
            );

            //Criando um usuário na API
            var responseCriarConta = _client.PostAsJsonAsync("api/usuarios/criar", criarContaRequest)?.Result;
            responseCriarConta?.StatusCode.Should().Be(HttpStatusCode.Created);

            //Arrange
            var autenticarRequest = new AutenticarRequest(
                    criarContaRequest.email, //Email do usuário criado
                    criarContaRequest.senha //Senha do usuário criado
                );

            //Act
            var responseAutenticar = _client.PostAsJsonAsync("api/usuarios/autenticar", autenticarRequest)?.Result;

            //Assert
            responseAutenticar?.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = responseAutenticar?.Content.ReadFromJsonAsync<AutenticarResponse>()?.Result;
            content?.id.Should().NotBeEmpty();
            content?.nome.Should().Be(criarContaRequest.nome);
            content?.email.Should().Be(criarContaRequest.email);
            content?.perfil.Should().Be("OPERADOR");
            content?.token.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Não deve criar usuário com email já cadastrado na API.")]
        public void Nao_Deve_Criar_Usuario_Com_Email_Ja_Cadastrado()
        {
            //Arrange
            var request = new CriarContaRequest(
                    _faker.Person.FullName, //Nome do usuário
                    _faker.Internet.Email(), //Email do usuário
                    "@Teste2025" //Senha do usuário
                );

            //Act
            var responseSucesso = _client.PostAsJsonAsync("api/usuarios/criar", request)?.Result;
            responseSucesso?.StatusCode.Should().Be(HttpStatusCode.Created);

            var responseErro = _client.PostAsJsonAsync("api/usuarios/criar", request)?.Result;
            responseErro?.StatusCode.Should().Be(HttpStatusCode.Conflict);

            //Arrange
            var content = responseErro?.Content.ReadAsStringAsync()?.Result;
            content.Should().Contain("O email informado já está cadastrado. Tente outro.");
        }

        [Fact(DisplayName = "Não deve autenticar um usuário inválido na API.")]
        public void Nao_Deve_Autenticar_Usuario_Invalido()
        {
            //Arrange
            var autenticarRequest = new AutenticarRequest(
                    _faker.Internet.Email(), //gerando um email aleatório
                    "@Aula12345" //senha inválida
                );

            //Act
            var responseAutenticar = _client.PostAsJsonAsync("api/usuarios/autenticar", autenticarRequest)?.Result;

            //Assert
            responseAutenticar?.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

            var content = responseAutenticar?.Content.ReadAsStringAsync()?.Result;
            content.Should().Contain("Acesso negado. Usuário inválido.");
        }

        [Fact(DisplayName = "Não deve criar um usuário com senha fraca na API.")]
        public void Nao_Deve_Criar_Usuario_Com_Senha_Fraca()
        {
            //Arrange
            var request = new CriarContaRequest(
                    _faker.Person.FullName, //Nome do usuário
                    _faker.Internet.Email(), //Email do usuário
                    "12345" //Senha fraca!
                );

            //Act
            var response = _client.PostAsJsonAsync("api/usuarios/criar", request)?.Result;

            //Assert
            response?.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var content = response?.Content.ReadAsStringAsync()?.Result;
            content.Should().Contain("A senha deve ter letra maiúscula, minúscula, número, símbolo e pelo menos 8 caracteres.");
        }
    }
}
