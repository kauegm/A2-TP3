using System.ComponentModel.DataAnnotations;

namespace TrabalhoA2.Request
{
    public class ProdutoResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public string Categoria { get; set; }
    }
}
