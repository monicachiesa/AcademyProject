using Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AlunoController : ControllerBase
    {

        private readonly Contexto _context;

        public AlunoController(Contexto context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(long id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(long id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(long id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(long id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
