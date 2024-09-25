using System;

namespace Taller4
{
    // Clase principal del programa
    class Programa
    {
        static void Main(string[] args)
        {
            // Crea una nueva instancia de la clase Restaurante
            Restaurante restaurante = new Restaurante();
            bool continuar = true;

            // Ciclo que mantiene el programa en ejecución hasta que el usuario decida salir
            while (continuar)
            {
                // Muestra el menú principal con las opciones disponibles para el usuario
                Console.WriteLine("\n===== Menú del Programa =====");
                Console.WriteLine("1. Imprimir menú del restaurante");
                Console.WriteLine("2. Agregar nuevo producto al menú del restaurante");
                Console.WriteLine("3. Agregar producto a una mesa");
                Console.WriteLine("4. Editar productos de una mesa");
                Console.WriteLine("5. Imprimir cuenta de una mesa");
                Console.WriteLine("6. Buscar producto por ID");
                Console.WriteLine("0. Salir");
                Console.WriteLine("=============================");
                Console.Write("Seleccione una opción: ");

                // Lee la opción ingresada por el usuario
                string? opcion = Console.ReadLine();

                // Estructura switch que ejecuta la lógica según la opción seleccionada
                switch (opcion)
                {
                    case "1":
                        // Imprime el menú del restaurante
                        restaurante.ImprimirMenu();
                        break;

                    case "2":
                        // Solicita al usuario los datos del nuevo producto y lo agrega al menú
                        Console.Write("Ingrese el ID del producto: ");
                        if (int.TryParse(Console.ReadLine(), out int nuevoId))
                        {
                            Console.Write("Ingrese el nombre del producto: ");
                            string? nuevoNombre = Console.ReadLine(); // Leer nombre del producto
                            if (!string.IsNullOrWhiteSpace(nuevoNombre))
                            {
                                Console.Write("Ingrese el precio del producto: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
                                {
                                    // Agregar producto al menú del restaurante
                                    restaurante.EditarMenu(nuevoId, nuevoNombre, nuevoPrecio, true);
                                }
                                else
                                {
                                    Console.WriteLine("Precio inválido. Inténtelo de nuevo.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nombre inválido. Inténtelo de nuevo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido. Inténtelo de nuevo.");
                        }
                        break;

                    case "3":
                        // Solicita el número de mesa y el ID del producto para agregarlo a la mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        if (int.TryParse(Console.ReadLine(), out int numMesaAgregar))
                        {
                            Console.Write("Ingrese el ID del producto que desea agregar: ");
                            if (int.TryParse(Console.ReadLine(), out int idProductoAgregar))
                            {
                                // Agregar producto a la mesa especificada
                                restaurante.AgregarProductoAMesa(numMesaAgregar, idProductoAgregar);
                            }
                            else
                            {
                                Console.WriteLine("ID del producto inválido. Inténtelo de nuevo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Número de mesa inválido. Inténtelo de nuevo.");
                        }
                        break;

                    case "4":
                        // Solicita la mesa y el producto para agregar o eliminar en dicha mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        if (int.TryParse(Console.ReadLine(), out int numMesaEditar))
                        {
                            Console.Write("¿Qué desea hacer? (1-Agregar, 2-Eliminar): ");
                            if (int.TryParse(Console.ReadLine(), out int opcionEdicion))
                            {
                                if (opcionEdicion == 1 || opcionEdicion == 2)
                                {
                                    Console.Write("Ingrese el ID del producto: ");
                                    if (int.TryParse(Console.ReadLine(), out int idProductoEditar))
                                    {
                                        // Editar productos de la mesa (agregar o eliminar)
                                        restaurante.EditarProductosMesa(numMesaEditar, opcionEdicion, idProductoEditar);
                                    }
                                    else
                                    {
                                        Console.WriteLine("ID del producto inválido. Inténtelo de nuevo.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Opción de edición inválida. Debe ser 1 (Agregar) o 2 (Eliminar).");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opción de edición inválida. Inténtelo de nuevo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Número de mesa inválido. Inténtelo de nuevo.");
                        }
                        break;

                    case "5":
                        // Solicita el número de mesa e imprime la cuenta de dicha mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        if (int.TryParse(Console.ReadLine(), out int numMesaCuenta))
                        {
                            restaurante.ImprimirCuentaMesa(numMesaCuenta); // Imprimir cuenta
                        }
                        else
                        {
                            Console.WriteLine("Número de mesa inválido. Inténtelo de nuevo.");
                        }
                        break;

                    case "6":
                        // Solicita el ID del producto y busca dicho producto en el menú
                        Console.Write("Ingrese el ID del producto: ");
                        if (int.TryParse(Console.ReadLine(), out int idProductoBuscar))
                        {
                            // Buscar el producto por ID
                            Producto? producto = restaurante.BuscarProductoPorId(idProductoBuscar);
                            if (producto != null)
                            {
                                // Si el producto existe, se imprime su información
                                Console.WriteLine(producto.ToString());
                            }
                            else
                            {
                                // Si el producto no se encuentra, se informa al usuario
                                Console.WriteLine("Producto no encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido. Inténtelo de nuevo.");
                        }
                        break;

                    case "0":
                        // Si se elige la opción de salir, se termina el ciclo
                        continuar = false;
                        break;

                    default:
                        // Manejo de opción inválida
                        Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                        break;
                }
            }
        }
    }
}
