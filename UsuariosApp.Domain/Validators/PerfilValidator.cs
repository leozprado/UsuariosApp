using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validators
{
    public class PerfilValidador : AbstractValidator<Perfil>
    {
        public PerfilValidador()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O nome do perfil é obrigatório.")
                .MinimumLength(4)
                .WithErrorCode("O nome do perfil deve ter pelo menos 4 caracteres.");
        }
    }
}
