using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Domain.Dtos;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("criar")]
        [ProducesResponseType(typeof(CriarUsuarioResponseDto), 201)]
        public IActionResult Criar([FromBody] CriarUsuarioRequestDto dto)
        {
            try
            {
                return StatusCode(201, _usuarioService.CriarUsuario(dto));
            }
            catch (ValidationException e)
            {
                return StatusCode(400, new { errors = e.Errors.Select(e => e.ErrorMessage) } );
            }
            catch (ApplicationException e)
            {
                return StatusCode(402 , new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPost("autenticar")]
        public IActionResult Autenticar()
        {
            return Ok();
        } 
    }
}
