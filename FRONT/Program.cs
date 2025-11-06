
using Bibliotecaparcial3.Modelos;
using Bibliotecaparcial3.Repositorio;

namespace FRONT
{
    internal class Program
    {
        public static List <Cliente> Clientes = ClienteRepository.ObtenerClientes();
        public static List<Producto> Productos = ProductoRepository.ObtenerProductos();
        public static List<Venta> Ventas = VentaRepository.ObtenerVentas();
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("Menú:");
                Console.WriteLine("1- Registrar Producto");
                Console.WriteLine("2- Registrar Cliente");
                Console.WriteLine("3- Registrar una nueva venta");
                Console.WriteLine("4- Reporte de ventas por clientes");
                Console.WriteLine("5- Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine().Trim();

                switch (opcion)
                {
                    case "1":
                        
                        Console.WriteLine("Ingresa el nombre del producto");
                        string nombreProducto = Console.ReadLine();
                        
                        if (string.IsNullOrWhiteSpace(nombreProducto))
                        {
                            Console.WriteLine("El nombre del producto no puede estar vacío.");
                            Console.ReadKey(true);
                            break;
                        }
                        Console.WriteLine("Agregar el precio del producto");
                        double precioProducto = double.Parse(Console.ReadLine());
                        if (precioProducto <= 0)
                        {
                            Console.WriteLine("El precio del producto no puede ser negativo ni 0");
                            Console.ReadKey(true);
                            break;
                        }
                        ProductoRepository.Agregarproducto(new Producto { Nombre = nombreProducto, Precio = precioProducto });
                        Console.WriteLine("Producto agregado con éxito.");
                        Console.ReadKey(true);
                        break;

                    case "2":
                      
                        Console.WriteLine("Ingresa el nombre del cliente");
                        string nombreCliente = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nombreCliente))
                        {
                            Console.WriteLine("El nombre del cliente no puede estar vacío.");
                            Console.ReadKey(true);
                            break;
                        }
                        Console.WriteLine("Ingresar apoellido del cliente");
                        string apellidoCliente = Console.ReadLine();
                        ClienteRepository.Agregarcliente(new Cliente { Nombre = nombreCliente, Apellido = apellidoCliente });
                        Console.WriteLine("Cliente registrado con éxito.");
                        Console.ReadKey(true);
                        break;

                    case "3":
                       
                        if (Clientes.Count == 0 || Productos.Count == 0)
                        {
                            Console.WriteLine("Debe haber al menos un cliente y un producto registrados para realizar una venta.");
                            Console.ReadKey(true);
                            break;
                        }
                        Console.WriteLine("Seleccione el cliente para la venta:");
                        var clientes = ClienteRepository.ObtenerClientes();
                        for (int i = 0; i < clientes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {clientes[i].Nombre} {clientes[i].Apellido}");
                        }
                        int indiceCliente = int.Parse(Console.ReadLine()) - 1;
                        while (indiceCliente < 0 || indiceCliente >= clientes.Count)
                        {
                            Console.WriteLine("Selección inválida. Por favor, seleccione un cliente válido:");
                            indiceCliente = int.Parse(Console.ReadLine()) - 1;
                        }

                        Console.WriteLine("Seleccione el producto para la venta:");
                        var productos = ProductoRepository.ObtenerProductos();
                        for (int i = 0; i < productos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {productos[i].Nombre} - ${productos[i].Precio}");
                        }
                        int indiceProducto = int.Parse(Console.ReadLine()) - 1;
                        while (indiceProducto < 0 || indiceProducto >= productos.Count)
                        {
                            Console.WriteLine("Selección inválida. Por favor, seleccione un producto válido:");
                            indiceProducto = int.Parse(Console.ReadLine()) - 1;
                        }
                        VentaRepository.AgregarVenta(new Venta
                        {
                            ClienteId = clientes[indiceCliente].Id,
                            ProductoId = productos[indiceProducto].Id,
                            FechaVenta = DateTime.Now
                        });
                        Console.WriteLine("Venta registrada con éxito.");
                        Console.ReadKey(true);
                        break;

                    case "4":
                        
                        if (Clientes.Count == 0 || Ventas.Count == 0)
                        {
                            Console.WriteLine("No hay clientes o ventas registradas para generar un reporte.");
                            Console.ReadKey(true);
                            break;
                        }

                        Console.WriteLine("Seleccione cliente para reporte:");
                        var clientesReporte = ClienteRepository.ObtenerClientes();
                        for (int i = 0; i < clientesReporte.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {clientesReporte[i].Nombre} {clientesReporte[i].Apellido}");
                        }
                        int indiceClienteReporte = int.Parse(Console.ReadLine()) - 1;
                        while (indiceClienteReporte < 0 || indiceClienteReporte >= clientesReporte.Count)
                        {
                            Console.WriteLine("Selección inválida. Por favor, seleccione un cliente válido:");
                            indiceClienteReporte = int.Parse(Console.ReadLine()) - 1;
                        }

                        var ventasCliente = VentaRepository.ObtenerVentasPorClienteId(clientesReporte[indiceClienteReporte].Id);
                        Console.WriteLine("Ventas para " + clientesReporte[indiceClienteReporte].Nombre + " " + clientesReporte[indiceClienteReporte].Apellido + ":");
                        for (int i = 0; i < ventasCliente.Count; i++)
                        {
                            var productoVendido = ProductoRepository.ObtenerProductos().FirstOrDefault(p => p.Id == ventasCliente[i].ProductoId);
                            Console.WriteLine($"{i + 1}. Producto: {productoVendido.Nombre}, Precio: ${productoVendido.Precio}, Fecha: {ventasCliente[i].FechaVenta}");
                        }
                        Console.ReadKey(true);
                        break;

                    case "5":
                        salir = true;
                        Console.ReadKey(true);
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
    }
}