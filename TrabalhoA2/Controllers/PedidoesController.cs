using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoA2.Data;
using TrabalhoA2.Entities;
using TrabalhoA2.Resquest;

namespace TrabalhoA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoesController : ControllerBase
    {
        private readonly TrabalhoA2Context _context;

        public PedidoesController(TrabalhoA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem Pedido
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
        {
            return await _context.Pedido.ToListAsync();
        }

        /// <summary>
        /// Obtem Pedido
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        /// <summary>
        /// Atualiza Pedido
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, PedidoRequest request)
        {
            
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                Pedido pedido = await _context.Pedido.FindAsync(id);
                pedido.Cliente = await _context.Cliente.FindAsync(request.ClienteId);
                pedido.DataPedido = request.DataPedido;
                pedido.Total = request.Total;

            return NoContent();
        }

        /// <summary>
        /// Post de Pedido
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(PedidoRequest request)
        {
            Pedido pedido = new Pedido();
            pedido.Cliente = await _context.Cliente.FindAsync(request.ClienteId);
            pedido.DataPedido = request.DataPedido;
            pedido.Total = request.Total;

            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        /// <summary>
        /// Deleta Pedido
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.Id == id);
        }
    }
}
