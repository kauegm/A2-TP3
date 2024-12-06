using System.ComponentModel.DataAnnotations;

namespace TrabalhoA2.Entities
{
    public class Estoque
    {
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public Produto? Produto { get; set; }

        public int Quantidade { get; set; } // Quantidade disponível no estoque
    }
}
