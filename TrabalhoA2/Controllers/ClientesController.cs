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
    public class ClientesController : ControllerBase
    {
        private readonly TrabalhoA2Context _context;

        public ClientesController(TrabalhoA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem Cliente
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            return await _context.Cliente.ToListAsync();
        }

        /// <summary>
        /// Obtem Cliente
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        /// <summary>
        /// Atualiza Cliente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteRequest request)
        {
            if (!ClienteExists(id))
            {
                return NotFound();
            }
            Cliente cliente = await _context.Cliente.FindAsync(id);
            cliente.Nome = request.Nome;
            cliente.Email = request.Email;
            cliente.Telefone = request.Telefone;
            cliente.Endereco = request.Endereco;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post de Cliente
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(ClienteRequest request)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = request.Nome;
            cliente.Email = request.Email;
            cliente.Telefone = request.Telefone;
            cliente.Endereco = request.Endereco;

            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        /// <summary>
        /// Deleta Cliente
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
