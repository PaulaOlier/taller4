using System;

namespace Taller4
{
    public class Programa
    {
        private Restaurante restaurante;
        private AsciiArt asciiArt;

        public Programa()
        {
            restaurante = new Restaurante(5, "menu.csv"); // Crear un restaurante con 5 mesas
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
                Console.WriteLine("7. Editar Producto en Menú");

                string? opcion = Console.ReadLine();

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
                        EditarProductoEnMenu();
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        private void MostrarMenu()
        {
            restaurante.GetMenu().MostrarMenu();
        }

        private void AsignarClienteAMesa()
        {
            Console.WriteLine("\nIngrese el nombre del cliente:");
            string? nombre = Console.ReadLine();

            // Verifica que el nombre no sea nulo o vacío
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }

            Console.WriteLine("Ingrese la fecha de nacimiento (YYYY-MM-DD):");
            DateTime fechaNacimiento;

            // Manejo de errores en la fecha
            while (!DateTime.TryParse(Console.ReadLine(), out fechaNacimiento))
            {
                Console.WriteLine("Fecha inválida. Intente de nuevo (YYYY-MM-DD):");
            }

            Cliente cliente = new Cliente(nombre, fechaNacimiento);

            Console.WriteLine("Ingrese el número de mesa (1-5):");
            int numeroMesa;

            // Manejo de errores en el número de mesa
            while (!int.TryParse(Console.ReadLine(), out numeroMesa) || numeroMesa < 1 || numeroMesa > 5)
            {
                Console.WriteLine("Número de mesa inválido. Intente de nuevo (1-5):");
            }

            restaurante.AsignarClienteAMesa(numeroMesa, cliente);
        }

        private void CrearFactura()
        {
            Console.WriteLine("Ingrese el número de mesa para crear una factura:");
            int numeroMesa;

            // Manejo de errores en el número de mesa
            while (!int.TryParse(Console.ReadLine(), out numeroMesa) || numeroMesa < 1 || numeroMesa > 5)
            {
                Console.WriteLine("Número de mesa inválido. Intente de nuevo (1-5):");
            }

            var mesa = restaurante.GetMesas()[numeroMesa - 1];

            if (mesa != null)
            {
                Console.WriteLine("Ingrese el nombre del cliente:");
                string? nombre = Console.ReadLine();

                // Verifica que el nombre no sea nulo o vacío
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                    return;
                }

                Console.WriteLine("Ingrese la fecha de nacimiento (YYYY-MM-DD):");
                DateTime fechaNacimiento;

                // Manejo de errores en la fecha
                while (!DateTime.TryParse(Console.ReadLine(), out fechaNacimiento))
                {
                    Console.WriteLine("Fecha inválida. Intente de nuevo (YYYY-MM-DD):");
                }

                Cliente cliente = new Cliente(nombre, fechaNacimiento);
                restaurante.CrearFactura(cliente);
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }
        }

        private void AgregarProductoAFactura()
        {
            Console.WriteLine("Ingrese el ID del producto:");
            int idProducto;

            // Manejo de errores en el ID del producto
            while (!int.TryParse(Console.ReadLine(), out idProducto))
            {
                Console.WriteLine("ID inválido. Intente de nuevo:");
            }

            var producto = restaurante.GetMenu().ObtenerProductoPorId(idProducto);

            if (producto != null)
            {
                Console.WriteLine("Ingrese el número de mesa para agregar el producto a la factura:");
                int numeroMesa;

                // Manejo de errores en el número de mesa
                while (!int.TryParse(Console.ReadLine(), out numeroMesa) || numeroMesa < 1 || numeroMesa > 5)
                {
                    Console.WriteLine("Número de mesa inválido. Intente de nuevo (1-5):");
                }

                var mesa = restaurante.GetMesas()[numeroMesa - 1];
                mesa.AgregarProducto(producto);
                Console.WriteLine($"Producto {producto.GetNombre()} agregado a la mesa {numeroMesa}.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        private void MostrarFacturas()
        {
            Console.WriteLine("Facturas:");
            foreach (var factura in restaurante.GetFacturas())
            {
                factura.MostrarFactura();
            }
        }

        private void ImprimirFactura()
        {
            Console.WriteLine("Ingrese el ID de la factura a imprimir:");
            // Aquí se debe implementar la lógica para imprimir la factura seleccionada.
        }

        private void EditarProductoEnMenu()
        {
            Console.WriteLine("Ingrese el ID del producto a editar:");
            int idProducto;

            // Manejo de errores en el ID del producto
            while (!int.TryParse(Console.ReadLine(), out idProducto))
            {
                Console.WriteLine("ID inválido. Intente de nuevo:");
            }

            Console.WriteLine("Ingrese el nuevo nombre del producto:");
            string? nuevoNombre = Console.ReadLine();

            // Verificar que nuevoNombre no sea nulo o vacío
            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                Console.WriteLine("El nombre del producto no puede estar vacío.");
                return;
            }

            Console.WriteLine("Ingrese el nuevo precio del producto:");
            double nuevoPrecio;

            // Manejo de errores en el precio
            while (!double.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio < 0)
            {
                Console.WriteLine("Precio inválido. Intente de nuevo:");
            }

            Console.WriteLine("Ingrese la nueva cantidad del producto:");
            int nuevaCantidad;

            // Manejo de errores en la cantidad
            while (!int.TryParse(Console.ReadLine(), out nuevaCantidad) || nuevaCantidad < 0)
            {
                Console.WriteLine("Cantidad inválida. Intente de nuevo:");
            }

            restaurante.GetMenu().EditarProducto(idProducto, nuevoNombre, nuevoPrecio, nuevaCantidad);
        }
    }
}
