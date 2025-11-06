using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecaparcial3.Modelos
{
    public class Venta
    {
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public DateTime FechaVenta { get; set; } = DateTime.Now;
    }
}
