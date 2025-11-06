using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotecaparcial3.Data;
using Bibliotecaparcial3.Modelos;

namespace Bibliotecaparcial3.Repositorio
{
    public class ClienteRepository
    {
        public static void Agregarcliente (Cliente cliente)
        {
            using var context = new ApplicationDbContext();
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }

        public static List<Cliente> ObtenerClientes()
        {
            using var context = new ApplicationDbContext();
            return context.Clientes.ToList();
        }

       
        public Cliente ObtenerClientePorId(int id)
        {
            using var context = new ApplicationDbContext();
            return context.Clientes.FirstOrDefault(c => c.Id == id);
        }





    }
}
