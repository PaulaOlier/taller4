using System;
using System.Collections.Generic;
using System.IO;

namespace Taller4
{
    public class Menu
    {
        private List<Producto> productos; // Lista que almacena los productos del menú

        public Menu()
        {
            productos = new List<Producto>(); // Inicializa la lista de productos
            // Carga los productos desde un archivo CSV usando la ruta especificada
            CargarMenuDesdeCSV(@"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\menu.csv"); 
        }

        // Método privado para cargar el menú desde un archivo CSV
        private void CargarMenuDesdeCSV(string archivo)
        {
            // Verifica si el archivo existe en la ruta especificada
            if (File.Exists(archivo))
            {
                // Lee todas las líneas del archivo CSV
                string[] lineas = File.ReadAllLines(archivo);
                // Itera sobre cada línea del archivo
                foreach (var linea in lineas)
                {
                    // Divide la línea en datos utilizando la coma como separador
                    var datos = linea.Split(',');
                    // Verifica que la línea tenga 4 elementos y que sean del tipo adecuado
                    if (datos.Length == 4 && 
                        int.TryParse(datos[0], out int id) && 
                        decimal.TryParse(datos[2], out decimal precio) && 
                        int.TryParse(datos[3], out int cantidad))
                    {
                        // Crea un nuevo producto y lo agrega a la lista
                        var producto = new Producto(id, datos[1], precio, cantidad);
                        productos.Add(producto);
                    }
                }
            }
            else
            {
                // Mensaje de error si el archivo no existe
                Console.WriteLine("El archivo de menú no existe en la ruta especificada.");
            }
        }

        // Método para imprimir el menú en la consola
        public void ImprimirMenu()
        {
            Console.WriteLine("\n===== Menú del Restaurante =====");
            // Itera sobre cada producto y lo imprime
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.ToString());
            }
            Console.WriteLine("=============================");
        }

        // Método para buscar un producto por su ID
        public Producto? BuscarProductoPorId(int id) => productos.Find(p => p.GetId() == id);

        // Método para agregar un nuevo producto al menú
        public void AgregarProducto(Producto nuevoProducto)
        {
            productos.Add(nuevoProducto); // Agrega el nuevo producto a la lista
            Console.WriteLine("Producto agregado al menú.");
        }

        // Método para editar un producto existente
        public void EditarProducto(int id, string nombre, decimal precio, int cantidad)
        {
            // Busca el producto por su ID
            Producto? producto = productos.Find(p => p.GetId() == id);
            if (producto != null)
            {
                // Actualiza la cantidad del producto
                producto.SetCantidad(cantidad); 
                Console.WriteLine("Producto actualizado.");
            }
            else
            {
                // Mensaje de error si no se encuentra el producto
                Console.WriteLine("Producto no encontrado.");
            }
        }
    }
}
