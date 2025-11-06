using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotecaparcial3.Data;
using Bibliotecaparcial3.Modelos;

namespace Bibliotecaparcial3.Repositorio
{
    public class VentaRepository
    {
        public static void AgregarVenta(Venta venta)
        {
            using var context = new ApplicationDbContext();
            context.Ventas.Add(venta);
            context.SaveChanges();
        }

        public static List<Venta> ObtenerVentas()
        {
            using var context = new ApplicationDbContext();
            return context.Ventas.ToList();
        }

        public static List<Venta> ObtenerVentasPorClienteId(int clienteId)
        {
            using var context = new ApplicationDbContext();
            return context.Ventas.Where(v => v.ClienteId == clienteId).ToList();
        }
    }
}
