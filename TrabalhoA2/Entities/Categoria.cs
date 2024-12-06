using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TrabalhoA2.Entities
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
