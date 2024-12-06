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
    public class ProdutoesController : ControllerBase
    {
        private readonly TrabalhoA2Context _context;

        public ProdutoesController(TrabalhoA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem Produto
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoResponse>>> GetProduto()
        {

            return await _context.Produto.Include(p => p.Categoria).Select(p => new ProdutoResponse
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Categoria = p.Categoria!.Nome
            }).ToListAsync();
        }

        /// <summary>
        /// Obtem Produto
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoResponse>> GetProduto(int id)
        {
            var produto = await _context.Produto.Where(p => p.Id == id).Select(p => new ProdutoResponse
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Categoria = p.Categoria!.Nome
            }).FirstOrDefaultAsync();

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        /// <summary>
        /// Atualiza Produto
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, ProdutoRequest request)
        {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
            Produto produto = await _context.Produto.FindAsync(id);
            produto.Nome = request.Nome;
            produto.Preco = request.Preco;
            produto.Categoria = await _context.Categoria.FindAsync(request.CategoriaId);

            return NoContent();
        }

        /// <summary>
        /// Post de Produto
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(ProdutoRequest request)
        {
            Produto produto = new Produto();
            produto.Nome = request.Nome;
            produto.Preco = request.Preco;
            produto.Categoria = await _context.Categoria.FindAsync(request.CategoriaId);

            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        /// <summary>
        /// Deleta Produto
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
