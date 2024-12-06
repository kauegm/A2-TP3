using System.ComponentModel.DataAnnotations;

namespace TrabalhoA2.Request
{
    public class EstoqueRequest
    {
        [Required]
        public int ProdutoId { get; set; }

        public int Quantidade { get; set; } // Quantidade disponível no estoque
    }
}
