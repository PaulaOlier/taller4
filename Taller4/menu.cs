using System;
using System.Collections.Generic;
using System.IO;

namespace Taller4
{
    public class Menu
    {
        private List<Producto> productos; // Lista de productos en el menú

        // Constructor que carga los productos desde el archivo CSV
        public Menu()
        {
            productos = new List<Producto>();
            CargarProductosDesdeCSV(@"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\menu.csv");
        }

        // Método para cargar productos desde un archivo CSV
        public void CargarProductosDesdeCSV(string rutaArchivo)
        {
            try
            {
                using (var lector = new StreamReader(rutaArchivo))
                {
                    while (!lector.EndOfStream)
                    {
                        var linea = lector.ReadLine();
                        var datos = linea.Split(',');

                        // Asegúrate de que el archivo tenga el formato correcto
                        if (datos.Length == 4)
                        {
                            int id = int.Parse(datos[0]);
                            string nombre = datos[1];
                            decimal precio = decimal.Parse(datos[2]);
                            int cantidad = int.Parse(datos[3]);

                            Producto producto = new Producto(id, nombre, precio, cantidad);
                            productos.Add(producto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar productos desde el CSV: " + ex.Message);
            }
        }

        // Método para imprimir el menú completo
        public void ImprimirMenu()
        {
            Console.WriteLine("Menú del Restaurante:");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.ToString()); // Llama al ToString de Producto para mostrar la información
            }
        }

        // Método para buscar un producto por su ID
        public Producto BuscarProductoPorId(int id)
        {
            return productos.Find(p => p.GetId() == id);
        }

        // Método para editar un producto en el menú
        public void EditarProducto(int id, string nuevoNombre, decimal nuevoPrecio, int nuevaCantidad)
        {
            Producto producto = BuscarProductoPorId(id);
            if (producto != null)
            {
                producto.SetNombre(nuevoNombre);
                producto.SetPrecio(nuevoPrecio);
                producto.SetCantidad(nuevaCantidad);

                // Actualiza el archivo CSV después de editar el producto
                GuardarProductosEnCSV(@"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\menu.csv");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Método para agregar un producto al menú
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
            // Guarda el nuevo producto en el archivo CSV
            GuardarProductosEnCSV(@"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\menu.csv");
        }

        // Método para guardar todos los productos en el archivo CSV
        private void GuardarProductosEnCSV(string rutaArchivo)
        {
            try
            {
                using (var escritor = new StreamWriter(rutaArchivo))
                {
                    foreach (var producto in productos)
                    {
                        // Escribe cada producto en el formato correcto
                        escritor.WriteLine($"{producto.GetId()},{producto.GetNombre()},{producto.GetPrecio()},{producto.GetCantidad()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar productos en el CSV: " + ex.Message);
            }
        }
    }
}
