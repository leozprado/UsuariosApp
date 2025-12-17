using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Dtos
{
    /// <summary>
    /// Dto para a requisição de autenticação de usuário.
    /// </summary>
    public record AutenticarRequest(

        string email,
        string senha

        );
    
}
