using System;

namespace Taller4
{
    class Programa
    {
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante();
            AsciiArt asciiArt = new AsciiArt();
            bool continuar = true;

            asciiArt.ImprimirBienvenido();

            while (continuar)
            {
                Console.WriteLine("\n===== Menú del Programa =====");
                Console.WriteLine("1. Imprimir menú del restaurante");
                Console.WriteLine("2. Agregar producto a una mesa");
                Console.WriteLine("3. Eliminar producto de una mesa");
                Console.WriteLine("4. Editar producto en el menú");
                Console.WriteLine("5. Agregar producto al menú");
                Console.WriteLine("6. Imprimir cuenta de una mesa");
                Console.WriteLine("7. Agregar cliente al restaurante");
                Console.WriteLine("8. Asignar cliente a una mesa");
                Console.WriteLine("0. Salir");
                Console.WriteLine("=============================");
                Console.Write("Seleccione una opción: ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        asciiArt.ImprimirRestauranteDante();
                        restaurante.ImprimirMenu();
                        break;

                    case "2":
                        // Lógica para agregar productos a una mesa
                        break;

                    case "3":
                        // Lógica para eliminar productos de una mesa
                        break;

                    case "4":
                        // Lógica para editar productos en el menú
                        break;

                    case "5":
                        // Lógica para agregar productos al menú
                        break;

                    case "6":
                        // Lógica para imprimir la cuenta de una mesa
                        break;

                    case "7": // Agregar cliente
                        Console.Write("Ingrese ID del cliente: ");
                        int idCliente = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese nombre del cliente: ");
                        string nombreCliente = Console.ReadLine();
                        Console.Write("Ingrese correo del cliente: ");
                        string correoCliente = Console.ReadLine();
                        restaurante.AgregarCliente(idCliente, nombreCliente, correoCliente);
                        break;

                    case "8": // Asignar cliente a una mesa
                        Console.Write("Ingrese número de mesa: ");
                        int numeroMesa = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese ID del cliente: ");
                        int clienteId = int.Parse(Console.ReadLine());
                        restaurante.AsignarClienteAMesa(numeroMesa, clienteId);
                        break;

                    case "0":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                        break;
                }
            }
        }
    }
}
