using System.ComponentModel.DataAnnotations;

namespace TrabalhoA2.Resquest
{
    public class PedidoRequest
    {
        [Required]
        public int ClienteId { get; set; }

        public DateTime DataPedido { get; set; }

        public decimal Total { get; set; }

    }
}
