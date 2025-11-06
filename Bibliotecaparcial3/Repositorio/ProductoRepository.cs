using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotecaparcial3.Data;
using Bibliotecaparcial3.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Bibliotecaparcial3.Repositorio
{
    public class ProductoRepository
    {
        
        public static void Agregarproducto (Producto producto)
        {
            using var context = new ApplicationDbContext();
            context.Productos.Add(producto);

            context.SaveChanges();
        }

        public static List<Producto> ObtenerProductos()
        {
            using var context = new ApplicationDbContext();
            return context.Productos.ToList();
        }

        public static Producto ObtenerProductoPorId(int id)
        {
            using var context = new ApplicationDbContext();
            return context.Productos.FirstOrDefault(p => p.Id == id);

        }
    }
}
