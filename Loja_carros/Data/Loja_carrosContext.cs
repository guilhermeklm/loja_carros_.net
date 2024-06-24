using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja_carros.Models;

namespace Loja_carros.Data
{
    public class Loja_carrosContext : DbContext
    {
        public Loja_carrosContext (DbContextOptions<Loja_carrosContext> options)
            : base(options)
        {
        }

        public DbSet<Loja_carros.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<Loja_carros.Models.Vendedor>? Vendedor { get; set; } = default!;

        public DbSet<Loja_carros.Models.Carro>? Carro { get; set; } = default!;

        public DbSet<Loja_carros.Models.Nota>? Nota { get; set; } = default!;
    }
}
