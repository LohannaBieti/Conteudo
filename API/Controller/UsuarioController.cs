using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario novoUsuario)
        {
            if (novoUsuario == null)
            {
                return BadRequest("Os dados do usuário são inválidos.");
            }

            // Verifica se o e-mail já está cadastrado
            var usuarioExistente = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == novoUsuario.Email);
            if (usuarioExistente != null)
            {
                return Conflict("Já existe um usuário com este e-mail.");
            }

            // Adiciona o novo usuário
            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CadastrarUsuario), new { id = novoUsuario.Id }, novoUsuario);
        }
    }
}