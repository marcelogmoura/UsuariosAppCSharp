using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Dtos;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Validations;

namespace UsuariosApp.Domain.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public UsuarioService(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository, IJwtTokenService jwtTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
            _jwtTokenService = jwtTokenService;
        }

        public AutenticarUsuarioResponseDto AutenticarUsuario(AutenticarUsuarioRequestDto dto)
        {
            var usuario = _usuarioRepository.Find(dto.Email, SHA256Helper.Encrypt(dto.Senha));

            if (usuario == null)
                throw new ApplicationException("usuario/email invalido");

            return new AutenticarUsuarioResponseDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nome = usuario.Nome,
                DataHoraAcesso = DateTime.Now,
                DataHoraExpiracao = _jwtTokenService.GenerateExpirationDate(),
                AccessToken = _jwtTokenService.GenerateToken(usuario),
                Perfil = new PerfilResponseDto
                {
                    Id = usuario.Perfil.Id,
                    Name = usuario.Perfil.Nome
                }

            };
        }

        public CriarUsuarioResponseDto CriarUsuario(CriarUsuarioRequestDto dto)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };

            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (_usuarioRepository.Verify(usuario.Email))
                throw new ApplicationException("email atualmente em uso");

            usuario.Senha = SHA256Helper.Encrypt(usuario.Senha);

            var perfil = _perfilRepository.ObterPorNome("OPERADOR");
            usuario.PerfilId = perfil.Id;

            _usuarioRepository.Add(usuario);

            return new CriarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCadastro = DateTime.Now,
                Perfil = new PerfilResponseDto
                {
                    Id = perfil.Id,
                    Name = perfil.Nome
                }
            };
        }
    }
}
