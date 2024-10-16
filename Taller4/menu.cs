using System;
using System.Collections.Generic;
using System.IO;

namespace Taller4
{
    public class Menu
    {
        private List<Producto> productos;

        // Constructor
        public Menu(string rutaArchivo)
        {
            // Inicializa la lista de productos
            productos = new List<Producto>();
            // Cargar productos desde el archivo CSV
            CargarProductosDesdeArchivo(rutaArchivo);
        }

        // Método para cargar productos desde un archivo CSV
        private void CargarProductosDesdeArchivo(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                var lineas = File.ReadAllLines(rutaArchivo);
                foreach (var linea in lineas)
                {
                    var partes = linea.Split(',');
                    if (partes.Length >= 4) // Asegúrate de que haya suficientes partes
                    {
                        int id = int.Parse(partes[0]);
                        string nombre = partes[1];
                        double precio = double.Parse(partes[2]);
                        int cantidad = int.Parse(partes[3]);

                        // Crea el producto y añádelo a la lista
                        productos.Add(new Producto(id, nombre, precio, cantidad));
                    }
                }
            }
            else
            {
                Console.WriteLine($"El archivo {rutaArchivo} no existe.");
            }
        }

        // Mostrar el menú
        public void MostrarMenu()
        {
            Console.WriteLine("\n--- Menú del Restaurante ---");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.GetId()}, Nombre: {producto.GetNombre()}, Precio: {producto.GetPrecio()}, Cantidad: {producto.GetCantidad()}");
            }
        }

        // Método para obtener un producto por ID
        public Producto? ObtenerProductoPorId(int id)
        {
            return productos.Find(p => p.GetId() == id);
        }


        // Método para agregar un nuevo producto al menú
        public void AgregarProducto(string nombre, double precio, int cantidad)
        {
            int nuevoId = productos.Count > 0 ? productos[^1].GetId() + 1 : 1; // Genera un nuevo ID
            var nuevoProducto = new Producto(nuevoId, nombre, precio, cantidad);
            productos.Add(nuevoProducto);
            GuardarMenuEnArchivo();
            Console.WriteLine($"Producto '{nombre}' agregado con éxito.");
        }

        // Método para editar un producto existente
        public void EditarProducto(int id, string nuevoNombre, double nuevoPrecio, int nuevaCantidad)
        {
            var producto = ObtenerProductoPorId(id);
            if (producto != null)
            {
                producto.SetNombre(nuevoNombre);
                producto.SetPrecio(nuevoPrecio);
                producto.SetCantidad(nuevaCantidad);
                GuardarMenuEnArchivo();
                Console.WriteLine($"Producto {id} editado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Método para guardar el menú en un archivo
        private void GuardarMenuEnArchivo()
        {
            using (StreamWriter sw = new StreamWriter("menu.csv"))
            {
                foreach (var producto in productos)
                {
                    sw.WriteLine($"{producto.GetId()},{producto.GetNombre()},{producto.GetPrecio()},{producto.GetCantidad()}");
                }
            }
        }
    }
}
