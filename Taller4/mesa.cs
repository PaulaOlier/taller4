using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Mesa
    {
        private int Numero { get; set; } // Número de la mesa
        private List<Producto> Productos { get; set; } = new List<Producto>(); // Lista de productos en la mesa
        public Cliente? Cliente { get; set; } // Cliente que está usando la mesa (puede ser nulo si no está asignada)

        // Método para obtener el número de la mesa
        public int GetNumero() => Numero;

        // Método para establecer el número de la mesa
        public void SetNumero(int numero) => Numero = numero;

        // Método para obtener la lista de productos en la mesa
        public List<Producto> GetProductos() => Productos;

        // Método para agregar un producto a la mesa
        public void AgregarProducto(Producto producto) 
        {
            if (producto.GetCantidad() > 0)
            {
                Productos.Add(producto);
                producto.SetCantidad(producto.GetCantidad() - 1);
                Console.WriteLine("Producto agregado a la mesa.");
            }
            else
            {
                Console.WriteLine("No hay suficiente cantidad del producto en inventario.");
            }
        }

        // Método para eliminar un producto de la mesa por su ID
        public void EliminarProducto(int idProducto)
        {
            Producto? producto = Productos.Find(p => p.GetId() == idProducto);
            if (producto != null)
            {
                Productos.Remove(producto);
                producto.SetCantidad(producto.GetCantidad() + 1);
                Console.WriteLine("Producto eliminado de la mesa.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado en la mesa.");
            }
        }

        // Método para calcular el total de la cuenta
        public decimal ObtenerTotal()
        {
            decimal total = 0;
            foreach (var producto in Productos)
            {
                total += producto.GetPrecio();
            }
            return total;
        }

        // Método para imprimir la cuenta de la mesa
        public void ImprimirCuenta()
        {
            Console.WriteLine($"Cuenta para la mesa {Numero}:");
            foreach (var producto in Productos)
            {
                Console.WriteLine(producto.ToString());
            }
            Console.WriteLine($"Total: ${ObtenerTotal()}");
        }
    }
}
