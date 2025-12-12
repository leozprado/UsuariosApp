using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Interfaces.Repository;
using UsuariosApp.Infra.Data.Contexts;

namespace UsuariosApp.Infra.Data.Repositories
{
    /// <summary>
    /// Classe de repositorio generico para o banco de dados.
    /// </summary>
    public class BaseRepository<Tentity> : IBaseRepository<Tentity>
        where Tentity : class
    {
        public void Add(Tentity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(entity); // inserindo o registro no banco de dados
                dataContext.SaveChanges(); //executando a gravação no banco de dados

            }
        }

        public void Delete(Tentity entity)
        {
           using (var dataContext = new DataContext())               
            {
                dataContext.Remove(entity); // removendo o registro no banco de dados
                dataContext.SaveChanges(); //executando a gravação no banco de dados
            }
        }

        public List<Tentity> GetAll()
        {
            using (var dataContext = new DataContext())               
            {
                return dataContext.Set<Tentity>().ToList(); // retornando todos os registros do banco de dados
            }
        }

        public Tentity? GetById(Guid id)
        {
            using (var dataContext = new DataContext())               
            {
                return dataContext.Set<Tentity>().Find(id); // retornando o registro pelo id do banco de dados
            }
        }

        public void Update(Tentity entity)
        {
            using (var dataContext = new DataContext())               
            {
                dataContext.Update(entity); // atualizando o registro no banco de dados
                dataContext.SaveChanges(); //executando a gravação no banco de dados
            }
        }
    }
}
