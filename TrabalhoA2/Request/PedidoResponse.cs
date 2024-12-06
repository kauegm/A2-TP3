using TrabalhoA2.Entities;

namespace TrabalhoA2.Request
{
    public class PedidoResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal Total { get; set; }
        public virtual object Produtos { get; set; } = new List<Produto>();
    }
}
