using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaAutoEscola.Models;

namespace SistemaAutoEscola.Data
{
    public class SistemaAutoEscolaContext : DbContext
    {
        public SistemaAutoEscolaContext (DbContextOptions<SistemaAutoEscolaContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaAutoEscola.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<SistemaAutoEscola.Models.Carro> Carro { get; set; } = default!;
        public DbSet<SistemaAutoEscola.Models.Reserva> Reserva { get; set; } = default!;
    }
}
