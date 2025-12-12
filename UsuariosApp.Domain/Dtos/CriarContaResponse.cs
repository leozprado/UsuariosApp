using System;
using System.Collections.Generic;
using System.Text;

namespace UsuariosApp.Domain.Dtos
{
    public record CriarContaResponse
    (
        Guid id,
        string nome,
        string email,
        DateTime dataHoraCriacao
     );
}