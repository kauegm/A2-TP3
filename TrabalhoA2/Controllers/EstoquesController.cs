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
    public class EstoquesController : ControllerBase
    {
        private readonly TrabalhoA2Context _context;

        public EstoquesController(TrabalhoA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem Estoque
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetEstoque()
        {
            return await _context.Estoque.ToListAsync();
        }

        /// <summary>
        /// Obtem Estoque
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Estoque>> GetEstoque(int id)
        {
            var estoque = await _context.Estoque.FindAsync(id);

            if (estoque == null)
            {
                return NotFound();
            }

            return estoque;
        }

        /// <summary>
        /// Atualiza Estoque
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstoque(int id, EstoqueRequest request)
        {
            if (!EstoqueExists(id))
            {
                return NotFound();
            }
            Estoque estoque = await _context.Estoque.FindAsync(id);
            estoque.Produto = await _context.Produto.FindAsync(request.ProdutoId);
            estoque.Quantidade = request.Quantidade;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post de Estoque
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Estoque>> PostEstoque(EstoqueRequest request)
        {
            Estoque estoque = new Estoque();
            estoque.Produto = await _context.Produto.FindAsync(request.ProdutoId);
            estoque.Quantidade = request.Quantidade;

            _context.Estoque.Add(estoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstoque", new { id = estoque.Id }, estoque);
        }

        /// <summary>
        /// Delete Estoque
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstoque(int id)
        {
            var estoque = await _context.Estoque.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }

            _context.Estoque.Remove(estoque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstoqueExists(int id)
        {
            return _context.Estoque.Any(e => e.Id == id);
        }
    }
}
