using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Mesa
    {
        private int Numero { get; set; } // Número de la mesa
        private List<Producto> Productos { get; set; } = new List<Producto>(); // Lista de productos en la mesa

        // Método para obtener el número de la mesa
        public int GetNumero() => Numero;

        // Método para establecer el número de la mesa
        public void SetNumero(int numero) => Numero = numero;

        // Método para obtener la lista de productos en la mesa
        public List<Producto> GetProductos() => Productos;

        // Método para agregar un producto a la mesa
        public void AgregarProducto(Producto producto) 
        {
            // Verifica que haya cantidad disponible del producto
            if (producto.GetCantidad() > 0)
            {
                // Agrega el producto a la lista de la mesa
                Productos.Add(producto);
                // Reduce la cantidad disponible en el inventario
                producto.SetCantidad(producto.GetCantidad() - 1); 
                Console.WriteLine("Producto agregado a la mesa.");
            }
            else
            {
                // Mensaje de error si no hay suficiente cantidad
                Console.WriteLine("No hay suficiente cantidad del producto en inventario.");
            }
        }

        // Método para eliminar un producto de la mesa por su ID
        public void EliminarProducto(int idProducto)
        {
            // Busca el producto en la lista de la mesa
            Producto? producto = Productos.Find(p => p.GetId() == idProducto);
            if (producto != null)
            {
                // Elimina el producto de la lista
                Productos.Remove(producto);
                // Aumenta la cantidad del producto en inventario
                producto.SetCantidad(producto.GetCantidad() + 1); 
                Console.WriteLine("Producto eliminado de la mesa.");
            }
            else
            {
                // Mensaje de error si el producto no se encuentra
                Console.WriteLine("Producto no encontrado en la mesa.");
            }
        }

        // Método para calcular el total de la cuenta
        public decimal ObtenerTotal()
        {
            decimal total = 0; // Inicializa el total en 0
            // Suma el precio de cada producto en la lista
            foreach (var producto in Productos)
            {
                total += producto.GetPrecio();
            }
            return total; // Devuelve el total calculado
        }

        // Método para imprimir la cuenta de la mesa
        public void ImprimirCuenta()
        {
            Console.WriteLine($"Cuenta para la mesa {Numero}:");
            // Imprime cada producto de la mesa
            foreach (var producto in Productos)
            {
                Console.WriteLine(producto.ToString());
            }
            // Imprime el total de la cuenta
            Console.WriteLine($"Total: ${ObtenerTotal()}");
        }
    }
}
