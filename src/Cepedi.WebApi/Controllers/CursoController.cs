using Cepedi.Data; // Certifique-se de que o namespace do seu contexto de banco de dados está correto
using Cepedi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ILogger<CursoController> _logger;
        private readonly ApplicationDbContext _context;

        public CursoController(ILogger<CursoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{idCurso}")]
        public async Task<ActionResult<CursoEntity>> GetCursoAsync(int idCurso)
        {
            var curso = await _context.Curso.FindAsync(idCurso);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        [HttpPost]
        public async Task PostCursoAsync(CursoEntity curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();

        }

        [HttpPut("{idCurso}")]
        public async Task<IActionResult> PutCursoAsync(int idCurso, CursoEntity curso)
        {
            if (idCurso != curso.Id)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(idCurso))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{idCurso}")]
        public async Task<IActionResult> DeleteCursoAsync(int idCurso)
        {
            var curso = await _context.Curso.FindAsync(idCurso);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoExists(int idCurso)
        {
            return _context.Curso.Any(e => e.Id == idCurso);
        }
    }
}
