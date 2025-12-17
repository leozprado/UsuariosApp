using Microsoft.EntityFrameworkCore;
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
    /// Classe de repositório para a entidade Usuário.
    /// </summary>

    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public Usuario? Get(string email)
        {
            //LINQ - Language Integrated Query
            //using (var dataContext = new DataContext())
            //{
            //    var query = from u in dataContext.Set<Usuario>()
            //                join p in dataContext.Set<Perfil>() on u.PerfilId equals p.Id
            //                where u.Email.Equals(email)
            //                select u;
            //    return query.SingleOrDefault();
            //}

            //LAMBDA
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>()
                    .Include(u => u.Perfil)
                    .Where(u => u.Email.Equals(email))
                    .SingleOrDefault();
            }


        }

        public Usuario? Get(string email, string senha)
        {
            //LINQ - Language Integrated Query
            //using (var dataContext = new DataContext())
            //{
            //    var query = from u in dataContext.Set<Usuario>()
            //                join p in dataContext.Set<Perfil>() on u.PerfilId equals p.Id
            //                where u.Email.Equals(email) && u.Senha.Equals(senha)
            //                select u;
            //    return query.SingleOrDefault();
            //}

            //LAMBDA
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>()
                    .Include(u => u.Perfil)
                    .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                    .SingleOrDefault();
            }
        }
    }
}