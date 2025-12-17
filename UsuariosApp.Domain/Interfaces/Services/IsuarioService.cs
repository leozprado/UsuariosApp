using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Dtos;

namespace UsuariosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para abstração dos métodos 
    /// da camada de serviço de usuários
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Método para autenticação do usuário.
        /// </summary>
        AutenticarResponse Autenticar(AutenticarRequest request);

        /// <summary>
        /// Método para criação de conta de usuário
        /// </summary>
        CriarContaResponse CriarConta(CriarContaRequest request);
    }
}
