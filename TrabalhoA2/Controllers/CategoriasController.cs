using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoA2.Data;
using TrabalhoA2.Entities;
using TrabalhoA2.Request;

namespace TrabalhoA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly TrabalhoA2Context _context;

        public CategoriasController(TrabalhoA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem Categoria
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            return await _context.Categoria.ToListAsync();
        }

        /// <summary>
        /// Obtem Categoria
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        /// <summary>
        /// Atualiza Categoria
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaRequest request)
        {
            if (!CategoriaExists(id))
            {
                return NotFound();
            }

            Categoria categoria = await _context.Categoria.FindAsync(id);
            categoria.Nome = request.Nome;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post de Categoria
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(CategoriaRequest request)
        {
            Categoria categoria = new Categoria();
            categoria.Nome = request.Nome;

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        /// <summary>
        /// Deleta Categoria
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.Id == id);
        }
    }
}
