using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Repository;
using UsuariosApp.Infra.Data.Contexts;

namespace UsuariosApp.Infra.Data.Repositories
{
    /// <summary>
    /// Classe de repositório para a entidade Perfil.
    /// </summary>
    public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
    {
        public Perfil? Get(string nome)
        {
            //LINQ - Language Integrated Query
            //using (var dataContext = new DataContext())
            //{
            //    var query = from p in dataContext.Set<Perfil>()
            //                where p.Nome.Equals(nome)
            //                select p;

            //    return query.SingleOrDefault();
            //}

            //LAMBDA 
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Perfil>()
                    .Where(p => p.Nome.Equals(nome))
                    .SingleOrDefault();
            }

        }
    }
}
