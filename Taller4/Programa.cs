using System;
using System.Collections.Generic;
using System.IO;

namespace Taller4
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante();

            while (true)
            {
                // Menú principal del restaurante
                Console.WriteLine("===== Menú Restaurante =====");
                Console.WriteLine("1. Imprimir menú");
                Console.WriteLine("2. Agregar producto a mesa");
                Console.WriteLine("3. Eliminar producto de mesa");
                Console.WriteLine("4. Imprimir cuenta de mesa");
                Console.WriteLine("5. Agregar cliente");
                Console.WriteLine("6. Imprimir clientes");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                // Manejo de las opciones del menú
                switch (opcion)
                {
                    case "1":
                        // Imprimir menú de productos
                        restaurante.ImprimirMenu();
                        break;

                    case "2":
                        // Agregar producto a mesa
                        Console.Write("Número de mesa: ");
                        int numeroMesa = int.Parse(Console.ReadLine());

                        Console.Write("ID del producto: ");
                        int idProducto = int.Parse(Console.ReadLine());

                        restaurante.AgregarProductoAMesa(numeroMesa, idProducto);
                        break;

                    case "3":
                        // Eliminar producto de mesa
                        Console.Write("Número de mesa: ");
                        numeroMesa = int.Parse(Console.ReadLine());

                        Console.Write("ID del producto a eliminar: ");
                        idProducto = int.Parse(Console.ReadLine());

                        restaurante.EliminarProducto(numeroMesa, idProducto);
                        break;

                    case "4":
                        // Imprimir cuenta de mesa
                        Console.Write("Número de mesa: ");
                        numeroMesa = int.Parse(Console.ReadLine());

                        restaurante.ImprimirCuentaMesa(numeroMesa);
                        break;

                    case "5":
                        // Agregar cliente
                        Console.Write("ID del cliente: ");
                        int idCliente = int.Parse(Console.ReadLine());

                        Console.Write("Nombre del cliente: ");
                        string nombreCliente = Console.ReadLine();

                        Console.Write("Correo del cliente: ");
                        string correoCliente = Console.ReadLine();

                        restaurante.AgregarCliente(idCliente, nombreCliente, correoCliente);
                        break;

                    case "6":
                        // Imprimir lista de clientes
                        restaurante.ImprimirClientes();
                        break;

                    case "0":
                        // Salir del programa
                        Console.WriteLine("¡Hasta luego!");
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
