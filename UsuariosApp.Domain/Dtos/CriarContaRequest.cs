using System;
using System.Collections.Generic;
using System.Text;

namespace UsuariosApp.Domain.Dtos
{
    public record CriarContaRequest(
        string nome,
        string email,
        string senha
        );
}