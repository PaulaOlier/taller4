using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Taller4
{
    public class Menu
    {
        private List<Producto> productos;
        private string rutaArchivo;  // Ruta del archivo para guardar cambios

        // Constructor que carga el menú desde el archivo CSV
        public Menu(string rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;
            productos = new List<Producto>();
            CargarMenuDesdeArchivo();
        }

        // Cargar el menú desde un archivo CSV
        private void CargarMenuDesdeArchivo()
        {
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("El archivo de menú no existe.");
                return;
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            foreach (var linea in lineas)
            {
                var datos = linea.Split(',');
                if (datos.Length == 4)
                {
                    int id = int.Parse(datos[0]);
                    string nombre = datos[1];
                    double precio = double.Parse(datos[2]);
                    int cantidad = int.Parse(datos[3]);

                    var producto = new Producto(id, nombre, precio, cantidad);
                    productos.Add(producto);
                }
            }
        }

        // Mostrar todos los productos en el menú
        public void MostrarMenu()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("El menú está vacío.");
                return;
            }

            Console.WriteLine("\n--- Menú ---");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.GetId()}, Nombre: {producto.GetNombre()}, Precio: ${producto.GetPrecio()}, Cantidad: {producto.GetCantidad()}");
            }
        }

        // Obtener un producto por su ID
        public Producto ObtenerProductoPorId(int id)
        {
            return productos.FirstOrDefault(p => p.GetId() == id);
        }

        // Agregar un producto al menú
        public void AgregarProducto(Producto producto)
        {
            if (producto != null)
            {
                productos.Add(producto);
                GuardarMenuEnArchivo();
                Console.WriteLine($"Producto {producto.GetNombre()} agregado al menú.");
            }
            else
            {
                Console.WriteLine("El producto no puede ser nulo.");
            }
        }

        // Editar un producto en el menú
        public void EditarProducto(int id, string nuevoNombre, double nuevoPrecio, int nuevaCantidad)
        {
            var producto = ObtenerProductoPorId(id);
            if (producto != null)
            {
                producto.SetNombre(nuevoNombre);
                producto.SetPrecio(nuevoPrecio);
                producto.SetCantidad(nuevaCantidad);
                GuardarMenuEnArchivo();
                Console.WriteLine($"Producto {id} editado con éxito.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Guardar el menú de nuevo en el archivo CSV
        private void GuardarMenuEnArchivo()
        {
            var lineas = productos.Select(p => $"{p.GetId()},{p.GetNombre()},{p.GetPrecio()},{p.GetCantidad()}");
            File.WriteAllLines(rutaArchivo, lineas);
        }
    }
}
