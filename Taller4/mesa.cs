using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Mesa
    {
        private int numero;
        private List<Producto> productos;

        public Mesa(int numero)
        {
            this.numero = numero;
            this.productos = new List<Producto>();
        }

        public int GetNumero() => numero;

        // Agregar producto a la mesa
        public void AgregarProducto(Producto producto)
        {
            if (producto != null)
            {
                productos.Add(producto);
                Console.WriteLine($"Producto {producto.GetNombre()} agregado a la mesa {numero}.");
            }
            else
            {
                Console.WriteLine("El producto no puede ser nulo.");
            }
        }

        // Mostrar productos de la mesa
        public void MostrarProductos()
        {
            Console.WriteLine($"\nProductos en la mesa {numero}:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"- {producto.GetNombre()} a ${producto.GetPrecio()}");
            }
        }
    }
}
