using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Factura
    {
        private Cliente cliente;
        private List<Producto> productos;

        public Factura(Cliente cliente)
        {
            this.cliente = cliente;
            productos = new List<Producto>();
        }

        public Cliente GetCliente() => cliente;

        public void AgregarProducto(Producto producto)
        {
            if (producto != null)
            {
                productos.Add(producto);
                Console.WriteLine($"Producto {producto.GetNombre()} agregado a la factura.");
            }
            else
            {
                Console.WriteLine("El producto no puede ser nulo.");
            }
        }

        public void MostrarFactura()
        {
            Console.WriteLine($"Factura para: {cliente.GetNombre()}");
            foreach (var producto in productos)
            {
                Console.WriteLine($"- {producto.GetNombre()} a ${producto.GetPrecio()}");
            }
        }

        public void ImprimirFactura()
        {
            Console.WriteLine("\nImprimiendo factura...");
            MostrarFactura();
        }
    }
}
