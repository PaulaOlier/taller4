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
            this.productos = new List<Producto>();
        }

        public Cliente GetCliente() => cliente;

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public void MostrarFactura()
        {
            Console.WriteLine($"Cliente: {cliente.GetNombre()}");
            Console.WriteLine("Productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"- {producto.GetNombre()} (ID: {producto.GetId()}, Precio: {producto.GetPrecio()}, Cantidad: {producto.GetCantidad()})");
            }
        }

        public void ImprimirFactura()
        {
            Console.WriteLine("Imprimiendo factura...");
            MostrarFactura();
        }
    }
}
