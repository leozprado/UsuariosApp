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

            //verificar se já existe um usuário com o email cadastrado
            if (usuarioRepository.Get(usuario.Email) != null)
            {
                throw new ApplicationException("Já existe um usuário cadastrado com o email informado.");
            }


            //Criptografar a senha do usuário
            usuario.Senha = CryptoHelper.ToSha256(request.senha);

            //consultando o perfil "OPERADOR" no banco de dados
            var perfil = perfilRepository.Get("OPERADOR");

            //caso o perfil não exista, iremos cria-lo
            if (perfil == null)
            {
                perfil = new Perfil() {Nome = "OPERADOR"};
                perfilRepository.Add(perfil);                
            }

            //Associar o usuario ao perfil de operador
            usuario.PerfilId = perfil.Id;


            //Salvar o usuário no banco de dados
            usuarioRepository.Add(usuario);

            //RETORNAR OS DADOS DE RESPOSTA (response)
            return new CriarContaResponse(
                usuario.Id,
                usuario.Nome,
                usuario.Email,
                usuario.DataHoraCriacao
          );

        }
    }
}
