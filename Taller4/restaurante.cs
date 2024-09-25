using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Restaurante
    {
        private Menu menu; // Instancia de la clase Menu para manejar los productos
        private List<Mesa> mesas; // Lista que contiene las mesas del restaurante
        private const string rutaFacturas = @"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\facturas.csv"; // Ruta del archivo CSV para almacenar las facturas

        // Constructor de la clase Restaurante
        public Restaurante()
        {
            menu = new Menu(); // Inicializa el menú
            mesas = new List<Mesa>(); // Inicializa la lista de mesas

            // Crea 10 mesas y las añade a la lista
            for (int i = 1; i <= 10; i++)
            {
                Mesa mesa = new Mesa();
                mesa.SetNumero(i); // Asigna un número a cada mesa
                mesas.Add(mesa); // Agrega la mesa a la lista de mesas
            }
        }

        // Método para imprimir el menú del restaurante
        public void ImprimirMenu() => menu.ImprimirMenu();

        // Método para agregar un producto a una mesa específica
        public void AgregarProductoAMesa(int numeroMesa, int idProducto)
        {
            // Busca la mesa por su número
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            // Busca el producto por su ID en el menú
            Producto? producto = menu.BuscarProductoPorId(idProducto);

            // Verifica que ambos, la mesa y el producto, existan antes de agregarlos
            if (mesa != null && producto != null)
            {
                mesa.AgregarProducto(producto); // Agrega el producto a la mesa
            }
            else
            {
                // Imprime un mensaje si no se encuentra la mesa o el producto
                Console.WriteLine(mesa == null ? "Mesa no encontrada." : "Producto no encontrado.");
            }
        }

        // Método para eliminar un producto de una mesa específica
        public void EliminarProducto(int numeroMesa, int idProducto)
        {
            // Busca la mesa por su número
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                mesa.EliminarProducto(idProducto); // Llama al método para eliminar el producto de la mesa
            }
            else
            {
                Console.WriteLine("Mesa no encontrada."); // Mensaje de error si la mesa no existe
            }
        }

        // Método para imprimir la cuenta de una mesa y generar la factura
        public void ImprimirCuentaMesa(int numeroMesa)
        {
            // Busca la mesa por su número
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                mesa.ImprimirCuenta(); // Imprime la cuenta de la mesa

                // Crea y guarda la factura
                Factura factura = new Factura(numeroMesa, mesa.ObtenerTotal()); // Crea una nueva factura con el total de la mesa
                factura.ImprimirFactura(); // Imprime la factura en formato tirilla
                factura.GuardarFactura(rutaFacturas); // Guarda la factura en el archivo CSV
            }
            else
            {
                Console.WriteLine("Mesa no encontrada."); // Mensaje de error si la mesa no existe
            }
        }

        // Método para editar un producto en el menú
        public void EditarProductoEnMenu(int id, string nombre, decimal precio, int cantidad)
        {
            menu.EditarProducto(id, nombre, precio, cantidad); // Llama al método para editar el producto en el menú
        }

        // Método para agregar un nuevo producto al menú
        public void AgregarProductoAlMenu(int id, string nombre, decimal precio, int cantidad)
        {
            Producto nuevoProducto = new Producto(id, nombre, precio, cantidad); // Crea una nueva instancia de Producto
            menu.AgregarProducto(nuevoProducto); // Agrega el nuevo producto al menú
        }
    }
}
