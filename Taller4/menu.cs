using System;
using System.Collections.Generic;
using System.IO;

namespace Taller4
{
    public class Menu
    {
        private List<Producto> productos;

        public Menu()
        {
            productos = new List<Producto>();
            // Usa la ruta correcta, utilizando una @ para evitar problemas de escape
            CargarMenuDesdeCSV(@"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\menu.csv"); 
        }

        private void CargarMenuDesdeCSV(string archivo)
        {
            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllLines(archivo);
                foreach (var linea in lineas)
                {
                    var datos = linea.Split(',');
                    if (datos.Length == 4 && 
                        int.TryParse(datos[0], out int id) && 
                        decimal.TryParse(datos[2], out decimal precio) && 
                        int.TryParse(datos[3], out int cantidad))
                    {
                        var producto = new Producto(id, datos[1], precio, cantidad);
                        productos.Add(producto);
                    }
                }
            }
            else
            {
                Console.WriteLine("El archivo de menú no existe en la ruta especificada.");
            }
        }

        public void ImprimirMenu()
        {
            Console.WriteLine("\n===== Menú del Restaurante =====");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.ToString());
            }
            Console.WriteLine("=============================");
        }

        public Producto? BuscarProductoPorId(int id) => productos.Find(p => p.GetId() == id);

        public void AgregarProducto(Producto nuevoProducto)
        {
            productos.Add(nuevoProducto);
            Console.WriteLine("Producto agregado al menú.");
        }

        public void EditarProducto(int id, string nombre, decimal precio, int cantidad)
        {
            Producto? producto = productos.Find(p => p.GetId() == id);
            if (producto != null)
            {
                producto.SetCantidad(cantidad); // Actualiza la cantidad
                Console.WriteLine("Producto actualizado.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
    }
}
