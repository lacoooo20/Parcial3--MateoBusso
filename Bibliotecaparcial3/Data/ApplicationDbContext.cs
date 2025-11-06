using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bibliotecaparcial3.Modelos;

namespace Bibliotecaparcial3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=Prueba3;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }
    }
}
