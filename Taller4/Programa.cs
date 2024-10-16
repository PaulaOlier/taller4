using System;
using System.Linq;

namespace Taller4
{
    public class Programa
    {
        private Restaurante restaurante;
        private AsciiArt asciiArt;

        public Programa()
        {
            restaurante = new Restaurante(5, "menu.csv");  // Crear un restaurante con 5 mesas
            asciiArt = new AsciiArt();
        }

        public void Ejecutar()
        {
            asciiArt.ImprimirBienvenido();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nElija una opción:");
                Console.WriteLine("0. Salir");
                Console.WriteLine("1. Ver Menú");
                Console.WriteLine("2. Asignar Cliente a Mesa");
                Console.WriteLine("3. Crear Factura");
                Console.WriteLine("4. Agregar Producto a Factura");
                Console.WriteLine("5. Mostrar Facturas");
                Console.WriteLine("6. Imprimir Factura");
                Console.WriteLine("7. Agregar Producto al Menú");
                Console.WriteLine("8. Editar Producto en el Menú");
                Console.WriteLine("9. Agregar Producto a Mesa");
                Console.WriteLine("10. Mostrar Productos en Mesa");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "0":
                        continuar = false;
                        break;

                    case "1":
                        MostrarMenu();
                        break;

                    case "2":
                        AsignarClienteAMesa();
                        break;

                    case "3":
                        CrearFactura();
                        break;

                    case "4":
                        AgregarProductoAFactura();
                        break;

                    case "5":
                        MostrarFacturas();
                        break;

                    case "6":
                        ImprimirFactura();
                        break;

                    case "7":
                        AgregarProductoAlMenu();
                        break;

                    case "8":
                        EditarProductoEnMenu();
                        break;

                    case "9":
                        AgregarProductoAMesa();
                        break;

                    case "10":
                        MostrarProductosEnMesa();
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        private void MostrarMenu() => restaurante.GetMenu().MostrarMenu();

        private void AsignarClienteAMesa()
        {
            Console.WriteLine("Ingrese el número de la mesa:");
            int numeroMesa = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del cliente:");
            string nombreCliente = Console.ReadLine();
            Cliente cliente = new Cliente(nombreCliente);
            restaurante.AsignarClienteAMesa(numeroMesa, cliente);
        }

        private void CrearFactura()
        {
            Console.WriteLine("Ingrese el nombre del cliente para la factura:");
            string nombreCliente = Console.ReadLine();
            Cliente cliente = new Cliente(nombreCliente);
            restaurante.CrearFactura(cliente);
        }

        private void AgregarProductoAFactura()
        {
            // Lógica para agregar un producto a la factura (no implementada aquí)
        }

        private void MostrarFacturas()
        {
            // Lógica para mostrar facturas (no implementada aquí)
        }

        private void ImprimirFactura()
        {
            // Lógica para imprimir la factura (no implementada aquí)
        }

        private void AgregarProductoAlMenu()
        {
            Console.WriteLine("Ingrese el ID del producto:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el precio del producto:");
            double precio = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad del producto:");
            int cantidad = int.Parse(Console.ReadLine());

            Producto nuevoProducto = new Producto(id, nombre, precio, cantidad);
            restaurante.AgregarProductoAlMenu(nuevoProducto);
        }

        private void EditarProductoEnMenu()
        {
            Console.WriteLine("Ingrese el ID del producto a editar:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo nombre del producto:");
            string nuevoNombre = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo precio del producto:");
            double nuevoPrecio = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la nueva cantidad del producto:");
            int nuevaCantidad = int.Parse(Console.ReadLine());

            restaurante.EditarProductoEnMenu(id, nuevoNombre, nuevoPrecio, nuevaCantidad);
        }

        private void AgregarProductoAMesa()
        {
            Console.WriteLine("Ingrese el número de la mesa:");
            int numeroMesa = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID del producto a agregar:");
            int idProducto = int.Parse(Console.ReadLine());

            Producto producto = restaurante.GetMenu().ObtenerProductoPorId(idProducto);
            if (producto != null)
            {
                restaurante.GetMesas()[numeroMesa - 1].AgregarProducto(producto);
            }
            else
            {
                Console.WriteLine("Producto no encontrado en el menú.");
            }
        }

        private void MostrarProductosEnMesa()
        {
            Console.WriteLine("Ingrese el número de la mesa:");
            int numeroMesa = int.Parse(Console.ReadLine());
            restaurante.GetMesas()[numeroMesa - 1].MostrarProductos();
        }
    }
}
