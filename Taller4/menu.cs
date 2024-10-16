using System;
using System.Collections.Generic;
using System.IO;

namespace Taller4
{
    public class Menu
    {
        private List<Producto> productos;
        private string rutaArchivo;

        public Menu(string rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;
            CargarMenuDesdeArchivo();
        }

        private void CargarMenuDesdeArchivo()
        {
            productos = new List<Producto>();
            try
            {
                foreach (var linea in File.ReadAllLines(rutaArchivo))
                {
                    var partes = linea.Split(',');
                    if (partes.Length == 3)
                    {
                        var producto = new Producto(int.Parse(partes[0]), partes[1], double.Parse(partes[2]), 0);
                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar el menú: {ex.Message}");
            }
        }

        public void MostrarMenu()
        {
            Console.WriteLine("Menú del Restaurante:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.GetId()}, Nombre: {producto.GetNombre()}, Precio: {producto.GetPrecio()}");
            }
        }

        public Producto ObtenerProductoPorId(int id)
        {
            var producto = productos.Find(p => p.GetId() == id);
            if (producto == null)
            {
                Console.WriteLine($"Producto con ID {id} no encontrado.");
            }
            return producto;  // Puede devolver null si no se encuentra.
        }

        public void EditarProducto(int id, string nuevoNombre, double nuevoPrecio, int nuevaCantidad)
        {
            var producto = ObtenerProductoPorId(id);
            if (producto != null) // Solo procede si el producto no es null
            {
                producto.SetNombre(nuevoNombre);
                producto.SetPrecio(nuevoPrecio);
                producto.SetCantidad(nuevaCantidad);
                GuardarMenuEnArchivo();
                Console.WriteLine($"Producto {id} editado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se pudo editar el producto porque no se encontró.");
            }
        }


        private void GuardarMenuEnArchivo()
        {
            try
            {
                using (var writer = new StreamWriter(rutaArchivo, false))
                {
                    foreach (var producto in productos)
                    {
                        writer.WriteLine($"{producto.GetId()},{producto.GetNombre()},{producto.GetPrecio()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el menú: {ex.Message}");
            }
        }
    }
}
