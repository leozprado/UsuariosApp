using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {

            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("O nome do usuário é obrigatório.")
                .MinimumLength(6)
                .WithMessage("O nome do usuário deve ter pelo menos 6 caracteres.")
                .MaximumLength(100)
                .WithMessage("O nome do usuário deve ter no máximo 100 caracteres.");
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("O email do usuário é obrigatório.")
                .EmailAddress()
                .WithMessage("O email do usuário deve ser um endereço de email válido.");
            RuleFor(u => u.Senha)
                .NotEmpty()
                .WithMessage("A senha do usuário é obrigatória.")
                .Matches("^(?=.{8,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_])(?!.*\\s).*\r\n")
                .WithMessage("A senha do usuário deve ter no mínimo 8 caracteres, incluindo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");
        }
    }
}
