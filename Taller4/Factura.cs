using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Factura
    {
        private Cliente cliente;    // El cliente asociado a esta factura
        private List<Producto> productos;  // Lista de productos en la factura
        private double total;  // Total de la factura

        // Constructor de la factura, asociado a un cliente
        public Factura(Cliente cliente)
        {
            this.cliente = cliente;
            this.productos = new List<Producto>();
            this.total = 0;
        }

        // Método para agregar un producto a la factura
        public void AgregarProducto(Producto producto)
        {
            if (producto != null)
            {
                productos.Add(producto);
                total += producto.GetPrecio();
            }
        }

        // Mostrar la factura (nombre del cliente, productos y total)
        public void MostrarFactura()
        {
            Console.WriteLine($"\nFactura de {cliente.GetNombre()}:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"Producto: {producto.GetNombre()}, Precio: {producto.GetPrecio()}");
            }

            Console.WriteLine($"Total: {total:C}");
        }

        // Método para aplicar un descuento si el cliente es cumpleañero
        public void AplicarDescuento()
        {
            if (cliente != null && cliente.EsCumpleaneroEsteMes())
            {
                double descuento = total * 0.10;  // 10% de descuento
                total -= descuento;
                Console.WriteLine($"Se aplicó un descuento de 10%: {descuento:C}");
            }
        }

        // Obtener el cliente asociado a la factura
        public Cliente GetCliente() => cliente;

        // Obtener el total de la factura
        public double GetTotal() => total;
    }
}
