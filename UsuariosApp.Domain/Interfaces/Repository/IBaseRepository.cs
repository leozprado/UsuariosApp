using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Interfaces.Repository
{
    /// <summary>
    /// Repositorio generico para definir as operaçoões principais de banco de dados
    /// </summary>

    public interface IBaseRepository<Tentity> where Tentity : class
    {
        void Add(Tentity entity);

        void Update(Tentity entity);

        void Delete(Tentity entity);

        List<Tentity> GetAll();

        Tentity? GetById(Guid id);




    }
}
