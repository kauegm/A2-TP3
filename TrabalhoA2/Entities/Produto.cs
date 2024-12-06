using System.ComponentModel.DataAnnotations;

namespace TrabalhoA2.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }
    }
}
