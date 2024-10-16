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
            restaurante = new Restaurante(5);  // Crear un restaurante con 5 mesas
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

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        private void MostrarMenu()
        {
            restaurante.MostrarMenu();
        }

        private void AsignarClienteAMesa()
        {
            Console.WriteLine("\nIngrese el número de la mesa (1-5):");
            int numeroMesa;
            while (!int.TryParse(Console.ReadLine(), out numeroMesa) || numeroMesa < 1 || numeroMesa > 5)
            {
                Console.WriteLine("Número de mesa inválido. Ingrese un número entre 1 y 5:");
            }

            Console.WriteLine("Ingrese el nombre del cliente:");
            string nombreCliente = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento del cliente (dd/MM/yyyy):");
            DateTime fechaNacimiento;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaNacimiento))
            {
                Console.WriteLine("Fecha inválida. Intente nuevamente (dd/MM/yyyy):");
            }

            Cliente cliente = new Cliente(nombreCliente, fechaNacimiento);
            restaurante.AsignarClienteAMesa(numeroMesa, cliente);  // Aquí no guardamos el resultado en un bool

            Console.WriteLine($"Cliente {cliente.GetNombre()} asignado a la mesa {numeroMesa}.");
        }

        private void CrearFactura()
        {
            Console.WriteLine("\nIngrese el nombre del cliente para crear la factura:");
            string nombreCliente = Console.ReadLine();

            Cliente cliente = restaurante.GetClientes().FirstOrDefault(c => c.GetNombre() == nombreCliente);

            if (cliente != null)
            {
                Factura factura = restaurante.CrearFactura(cliente);
                Console.WriteLine("Factura creada con éxito.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        private void AgregarProductoAFactura()
        {
            Console.WriteLine("\nIngrese el nombre del cliente:");
            string nombreCliente = Console.ReadLine();

            Cliente cliente = restaurante.GetClientes().FirstOrDefault(c => c.GetNombre() == nombreCliente);

            if (cliente != null)
            {
                Console.WriteLine("Ingrese el ID del producto:");
                int idProducto;
                while (!int.TryParse(Console.ReadLine(), out idProducto))
                {
                    Console.WriteLine("ID de producto inválido. Intente nuevamente:");
                }

                Console.WriteLine("Ingrese la cantidad:");
                int cantidad;
                while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Cantidad inválida. Intente nuevamente:");
                }

                Factura factura = restaurante.GetFacturas().FirstOrDefault(f => f.GetCliente() == cliente);
                if (factura != null)
                {
                    restaurante.AgregarProductoAFactura(factura, idProducto, cantidad);
                    Console.WriteLine("Producto agregado a la factura.");
                }
                else
                {
                    Console.WriteLine("Factura no encontrada para el cliente.");
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        private void MostrarFacturas()
        {
            if (restaurante.GetFacturas().Any())
            {
                restaurante.MostrarFacturas();
            }
            else
            {
                Console.WriteLine("No hay facturas registradas.");
            }
        }

        private void ImprimirFactura()
        {
            Console.WriteLine("\nIngrese el nombre del cliente para imprimir la factura:");
            string nombreCliente = Console.ReadLine();

            Cliente cliente = restaurante.GetClientes().FirstOrDefault(c => c.GetNombre() == nombreCliente);

            if (cliente != null)
            {
                Factura factura = restaurante.GetFacturas().FirstOrDefault(f => f.GetCliente() == cliente);
                if (factura != null)
                {
                    factura.AplicarDescuento();
                    factura.MostrarFactura();
                }
                else
                {
                    Console.WriteLine("Factura no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
}
