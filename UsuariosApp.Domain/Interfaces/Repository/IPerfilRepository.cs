using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces.Repository
{

    /// <summary>
    /// Interface para definir os métodos do repositório de perfil.
    /// </summary>
    public interface IPerfilRepository : IBaseRepository<Perfil>
    {
        Perfil? Get(string nome);
    }
}
