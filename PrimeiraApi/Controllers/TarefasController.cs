using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Models;

namespace PrimeiraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaContext _context;

        public TarefasController(TarefaContext context)
        {
            _context = context;
        }

        // Pegar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefas>>> GetTarefas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        // Pegar por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefas>> GetTarefas(int id)
        {
            var tarefas = await _context.Tarefas.FindAsync(id);

            if (tarefas == null)
            {
                return NotFound();
            }

            return tarefas;
        }

        // Inserir

        [HttpPost]
        public async Task<ActionResult<Tarefas>> PostTarefas(Tarefas tarefas)
        {
            _context.Tarefas.Add(tarefas);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarefas), new { id = tarefas.Id }, tarefas);
        }

        // Alterar
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefas(int id, Tarefas tarefas)
        {
            if (id != tarefas.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefasExists(id))
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

        // Apagar
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefas(int id)
        {
            var tarefas = await _context.Tarefas.FindAsync(id);
            if (tarefas == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefasExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
