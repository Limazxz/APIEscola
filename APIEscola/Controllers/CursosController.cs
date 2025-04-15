using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEscola.Data;
using APIEscola.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace APIEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CursosController : ControllerBase
    {
        private readonly APIEscolaContext _context;
        private UserManager<IdentityUser> _userManeger;

        public CursosController(APIEscolaContext context,
           UserManager<IdentityUser> userManeger)
        {
            _context = context;
            _userManeger = userManeger;
        }

        // GET: api/Cursos
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCusos()
        {
            return await _context.Cusos.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(Guid id)
        {
            var curso = await _context.Cusos.FindAsync(id);

            if (curso == null)
            {
                return NotFound("Id não Encontrado");
            }

            return curso;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(Guid id, Curso curso)
        {
            if (id != curso.CursoId)
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
                if (!CursoExists(id))
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

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _context.Cusos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurso", new { id = curso.CursoId }, curso);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(Guid id)
        {
            var curso = await _context.Cusos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Cusos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoExists(Guid id)
        {
            return _context.Cusos.Any(e => e.CursoId == id);
        }
    }
}
