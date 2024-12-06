using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrabalhoA2.Entities;

namespace TrabalhoA2.Data
{
    public class TrabalhoA2Context : DbContext
    {
        public TrabalhoA2Context (DbContextOptions<TrabalhoA2Context> options)
            : base(options)
        {
        }

        public DbSet<TrabalhoA2.Entities.Categoria> Categoria { get; set; } = default!;
        public DbSet<TrabalhoA2.Entities.Cliente> Cliente { get; set; } = default!;
        public DbSet<TrabalhoA2.Entities.Estoque> Estoque { get; set; } = default!;
        public DbSet<TrabalhoA2.Entities.Fornecedor> Fornecedor { get; set; } = default!;
        public DbSet<TrabalhoA2.Entities.Pedido> Pedido { get; set; } = default!;
        public DbSet<TrabalhoA2.Entities.Produto> Produto { get; set; } = default!;
    }
}
