using System.ComponentModel.DataAnnotations;

namespace TrabalhoA2.Request
{
    public class ProdutoRequest
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required]
        public int CategoriaId { get; set; }

    }
}
