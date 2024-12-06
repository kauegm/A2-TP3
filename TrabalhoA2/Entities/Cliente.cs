using System.ComponentModel.DataAnnotations;

namespace TrabalhoA2.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [StringLength(200)]
        public string Endereco { get; set; }
    }
}
