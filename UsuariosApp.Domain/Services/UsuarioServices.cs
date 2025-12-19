using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Dtos;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces.Repository;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Validators;

namespace UsuariosApp.Domain.Services
{
    /// <summary>
    /// Classe de serviço para regras de negócio de usuário.
    /// </summary>
    public class UsuarioService(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository) : IUsuarioService
    {
        public CriarContaResponse CriarConta(CriarContaRequest request)
        {
            //Capturar os dados recebidos (request)
            var usuario = new Usuario
            {
                Nome = request.nome, //capturando o nome do usuário
                Email = request.email, //capturando o email do usuário
                Senha = request.senha //capturando a senha do usuário
            };

            //Criando um objeto da classe de validação (Fluent Validator)
            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            //Verificar se existe algum erro de validação no usuário
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            //Verificar se já existe outro usuário com o email cadastrado
            if (usuarioRepository.Get(usuario.Email) != null)
            {
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");
            }

            //Criptografar a senha do usuário
            usuario.Senha = CryptoHelper.ToSha256(usuario.Senha);

            //Consultando o perfil 'OPERADOR' no banco de dados
            var perfil = perfilRepository.Get("OPERADOR");

            //Caso o perfil não existe, iremos cria-lo
            if (perfil == null)
            {
                perfil = new Perfil() { Nome = "OPERADOR" };
                perfilRepository.Add(perfil);
            }

            //Associar o usuário ao perfil de operador
            usuario.PerfilId = perfil.Id; //chave estrangeira

            //Salvar no banco de dados
            usuarioRepository.Add(usuario);

            //Retornar os dados do usuário criado
            return new CriarContaResponse(
                    usuario.Id, //Id do usuário
                    usuario.Nome, //Nome do usuário
                    usuario.Email, //Email do usuário
                    usuario.DataHoraCriacao //Data e hora de criação
                );
        }

        public AutenticarResponse Autenticar(AutenticarRequest request)
        {
            //Buscar o usuário no banco de dados baseado no email e na senha.
            var usuario = usuarioRepository.Get(request.email, CryptoHelper.ToSha256(request.senha));

            //verificar se o usuário não foi encontrado
            if (usuario == null)
            {
                throw new ApplicationException("Acesso negado. Usuário inválido.");
            }

            //gerar o token JWT
            var token = JwtHelper.GenerateToken(usuario.Email, usuario.Perfil?.Nome ?? string.Empty);


            //retornar os dados do usuário autenticado
            return new AutenticarResponse(
                    usuario.Id, //Id do usuário
                    usuario.Nome, //Nome do usuario
                    usuario.Email, //Email do usuário
                    usuario.Perfil?.Nome, //Nome do perfil do usuário
                    DateTime.Now, //Data e hora de acesso
                    DateTime.Now.AddHours(2), //Data e hora de expiração
                    token // Token JWT
                );
        }
    }
}
