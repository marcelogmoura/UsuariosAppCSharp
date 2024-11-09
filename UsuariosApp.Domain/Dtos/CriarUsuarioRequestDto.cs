using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Dtos
{
    public class CriarUsuarioRequestDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
