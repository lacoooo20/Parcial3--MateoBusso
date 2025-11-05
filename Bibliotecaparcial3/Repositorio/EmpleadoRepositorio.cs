using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotecaparcial3.Data;
using Bibliotecaparcial3.Modelos;

namespace Bibliotecaparcial3.Repositorio
{
    public class EmpleadoRepositorio
    {
        public static void CargarEmpleado(Empleados empleado)
        {
            using var context = new ApplicationDbContext();
            context.Empleados.Add(empleado);

            context.SaveChanges();
        }
        public static List<Empleados> ObtenerEmpleados()
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.ToList();
        }
        public static void EliminarEmpleado(Empleados empleado)
        {
            using var context = new ApplicationDbContext();
            context.Empleados.Remove(empleado);

            context.SaveChanges();
        }
    }
}

