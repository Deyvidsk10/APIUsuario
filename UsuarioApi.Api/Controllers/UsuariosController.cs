using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Application.DTOs;
using UsuarioApi.Domain.Interfaces;

namespace UsuarioApi.Api.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServico _servicoUsuario;

        public UsuariosController(IUsuarioServico servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioRequisicao requisicao)
        {
            try
            {
                var resultado = await _servicoUsuario.RegistrarAsync(requisicao);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequisicao requisicao)
        {
            try
            {
                var token = await _servicoUsuario.AutenticarAsync(requisicao.Email, requisicao.Senha);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { mensagem = ex.Message });
            }
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> AlterarStatus(Guid id, [FromBody] bool ativo)
        {
            try
            {
                var resultado = await _servicoUsuario.AtualizarStatusAsync(id, ativo);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var usuarios = await _servicoUsuario.ListarTodosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}