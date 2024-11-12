using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Infra.Data.Contexts;

namespace UsuariosApp.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Add(Usuario usuario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(usuario);
                dataContext.SaveChanges();  
            }
        }

        public Usuario Find(string email, string senha)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>()
                    .Include(u => u.Perfil)
                    .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                    .FirstOrDefault();

            }
        }

        public bool Verify(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>()
                    .Any(u => u.Email.Equals(email));
            }
        }
    }
}
