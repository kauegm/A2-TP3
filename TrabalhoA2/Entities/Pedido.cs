using System.ComponentModel.DataAnnotations;

namespace TrabalhoA2.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public DateTime DataPedido { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
