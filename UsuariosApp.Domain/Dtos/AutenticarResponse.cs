using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Dtos
{
    /// <summary>
    /// DTO para a resposta de autenticação de usuário.
    /// </summary>
    public record AutenticarResponse(
            Guid id, //Id do usuário
            string nome, //Nome do usuário
            string email, //Email do usuário
            string perfil, //Nome do perfil do usuário
            DateTime dataHoraAcesso, //Data e hora de acesso
            DateTime dataHoraExpiracao, //Data e hora de expiração
            string token //TOKEN JWT
        );
}