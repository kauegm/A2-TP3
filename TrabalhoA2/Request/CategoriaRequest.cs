using System.ComponentModel.DataAnnotations;

namespace TrabalhoA2.Request
{
    public class CategoriaRequest
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

    }
}
