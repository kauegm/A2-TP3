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
    public class FornecedorsController : ControllerBase
    {
        private readonly TrabalhoA2Context _context;

        public FornecedorsController(TrabalhoA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem Fornecedor
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedor()
        {
            return await _context.Fornecedor.ToListAsync();
        }

        /// <summary>
        /// Obtem Fornecedor
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return fornecedor;
        }

        /// <summary>
        /// Atualiza Fornecedor
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, FornecedorRequest request)
        {
           
                if (!FornecedorExists(id))
                {
                    return NotFound();
                }
            Fornecedor fornecedor = await _context.Fornecedor.FindAsync(id);
            fornecedor.Nome = request.Nome;
            fornecedor.Email = request.Email;
            fornecedor.Telefone = request.Telefone;
            fornecedor.Endereco = request.Endereco;

            return NoContent();
        }

        /// <summary>
        /// Post de Fornecedor
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(FornecedorRequest request)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Endereco = request.Endereco;
            fornecedor.Nome = request.Nome;
            fornecedor.Telefone = request.Telefone;
            fornecedor.Email = request.Email;

            _context.Fornecedor.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.Id }, fornecedor);
        }

        /// <summary>
        /// Deleta Fornecedor
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedor.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedor.Any(e => e.Id == id);
        }
    }
}
