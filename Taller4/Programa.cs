using System;

namespace Taller4
{
    class Programa
    {
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante(); // Crea una instancia de la clase Restaurante
            AsciiArt asciiArt = new AsciiArt(); // Crea una instancia de la clase AsciiArt para mostrar arte en ASCII
            bool continuar = true; // Variable para controlar el bucle del menú

            // Imprime el arte ASCII de "BIENVENIDOS"
            asciiArt.ImprimirBienvenido();

            // Bucle principal del programa
            while (continuar)
            {
                // Muestra el menú de opciones
                Console.WriteLine("\n===== Menú del Programa =====");
                Console.WriteLine("1. Imprimir menú del restaurante");
                Console.WriteLine("2. Agregar producto a una mesa");
                Console.WriteLine("3. Eliminar producto de una mesa");
                Console.WriteLine("4. Editar producto en el menú");
                Console.WriteLine("5. Agregar producto al menú");
                Console.WriteLine("6. Imprimir cuenta de una mesa");
                Console.WriteLine("0. Salir");
                Console.WriteLine("=============================");
                Console.Write("Seleccione una opción: ");

                // Lee la opción seleccionada por el usuario
                string? opcion = Console.ReadLine();

                // Evalúa la opción seleccionada
                switch (opcion)
                {
                    case "1": // Opción para imprimir el menú del restaurante
                        restaurante.ImprimirMenu();
                        break;

                    case "2": // Opción para agregar producto a una mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        if (int.TryParse(Console.ReadLine(), out int numMesaAgregar))
                        {
                            Console.Write("Ingrese el ID del producto que desea agregar: ");
                            if (int.TryParse(Console.ReadLine(), out int idProductoAgregar))
                            {
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

                    case "3": // Opción para eliminar producto de una mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        if (int.TryParse(Console.ReadLine(), out int numMesaEliminar))
                        {
                            Console.Write("Ingrese el ID del producto que desea eliminar: ");
                            if (int.TryParse(Console.ReadLine(), out int idProductoEliminar))
                            {
                                restaurante.EliminarProducto(numMesaEliminar, idProductoEliminar);
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

                    case "4": // Opción para editar un producto en el menú
                        Console.Write("Ingrese el ID del producto a editar: ");
                        if (int.TryParse(Console.ReadLine(), out int idProductoEditar))
                        {
                            Console.Write("Ingrese el nuevo nombre del producto: ");
                            string? nuevoNombre = Console.ReadLine();
                            Console.Write("Ingrese el nuevo precio del producto: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
                            {
                                Console.Write("Ingrese la nueva cantidad en inventario: ");
                                if (int.TryParse(Console.ReadLine(), out int nuevaCantidad))
                                {
                                    restaurante.EditarProductoEnMenu(idProductoEditar, nuevoNombre, nuevoPrecio, nuevaCantidad);
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad inválida. Inténtelo de nuevo.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Precio inválido. Inténtelo de nuevo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido. Inténtelo de nuevo.");
                        }
                        break;

                    case "5": // Opción para agregar un nuevo producto al menú
                        Console.Write("Ingrese el ID del nuevo producto: ");
                        if (int.TryParse(Console.ReadLine(), out int nuevoId))
                        {
                            Console.Write("Ingrese el nombre del nuevo producto: ");
                            string? nuevoNombre = Console.ReadLine();
                            Console.Write("Ingrese el precio del nuevo producto: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
                            {
                                Console.Write("Ingrese la cantidad en inventario: ");
                                if (int.TryParse(Console.ReadLine(), out int nuevaCantidad))
                                {
                                    restaurante.AgregarProductoAlMenu(nuevoId, nuevoNombre, nuevoPrecio, nuevaCantidad);
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad inválida. Inténtelo de nuevo.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Precio inválido. Inténtelo de nuevo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido. Inténtelo de nuevo.");
                        }
                        break;

                    case "6": // Opción para imprimir la cuenta de una mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        if (int.TryParse(Console.ReadLine(), out int numMesaCuenta))
                        {
                            restaurante.ImprimirCuentaMesa(numMesaCuenta);
                        }
                        else
                        {
                            Console.WriteLine("Número de mesa inválido. Inténtelo de nuevo.");
                        }
                        break;

                    case "0": // Opción para salir del programa
                        continuar = false;
                        break;

                    default: // Manejo de opciones inválidas
                        Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                        break;
                }
            }
        }
    }
}
