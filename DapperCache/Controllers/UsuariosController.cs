namespace DapperCache.Controllers;

using DapperCache.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuariosController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuario(int id)
    {
        var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }
}

