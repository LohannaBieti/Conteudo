using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody] Usuario usuario)
    {
         private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario novoUsuario)
        {
            if (novoUsuario == null)
            {
                return BadRequest("Os dados do usuário são inválidos.");
            }

            // Verifica se o e-mail já está cadastrado (validação simples)
            var usuarioExistente = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == novoUsuario.Email);
            if (usuarioExistente != null)
            {
                return Conflict("Já existe um usuário com este e-mail.");
            }

            // Adiciona o novo usuário no contexto
            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            // Retorna o status 201 (Created) com os dados do usuário
            return CreatedAtAction(nameof(CadastrarUsuario), new { id = novoUsuario.Id }, novoUsuario);
        }
    }
    }
}

