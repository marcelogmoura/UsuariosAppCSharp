using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Entities
{
    public class Permissao
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public ICollection<PerfilPermissao>? Perfis { get; set; }
    }
}
