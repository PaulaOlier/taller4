using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Mesa
    {
        private int Numero { get; set; } // Número de la mesa
        private List<Producto> Productos { get; set; } = new List<Producto>(); // Lista de productos en la mesa

        public int GetNumero() => Numero;
        public void SetNumero(int numero) => Numero = numero;
        public List<Producto> GetProductos() => Productos;


        public void AgregarProducto(Producto producto) 
        {
            if (producto.GetCantidad() > 0)
            {
                Productos.Add(producto);
                producto.SetCantidad(producto.GetCantidad() - 1); // Reduce la cantidad en inventario
                Console.WriteLine("Producto agregado a la mesa.");
            }
            else
            {
                Console.WriteLine("No hay suficiente cantidad del producto en inventario.");
            }
        }

        public void EliminarProducto(int idProducto)
        {
            Producto? producto = Productos.Find(p => p.GetId() == idProducto);
            if (producto != null)
            {
                Productos.Remove(producto);
                producto.SetCantidad(producto.GetCantidad() + 1); // Aumenta la cantidad en inventario
                Console.WriteLine("Producto eliminado de la mesa.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado en la mesa.");
            }
        }

        public decimal ObtenerTotal()
        {
            decimal total = 0; 
            foreach (var producto in Productos)
            {
                total += producto.GetPrecio();
            }
            return total;
        }

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
