using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Dtos;

namespace UsuariosApp.Domain.Interfaces.Services
{
    public interface IUsuarioService 
    {
        CriarUsuarioResponseDto CriarUsuario(CriarUsuarioRequestDto dto);

        AutenticarUsuarioResponseDto AutenticarUsuario(AutenticarUsuarioRequestDto dto);
    }
}
