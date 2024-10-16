using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Factura
    {
        private Cliente cliente;
        private List<(Producto, int)> productos;  // Lista de productos y cantidades
        private double descuento; // Descuento aplicado
        private double totalFactura;

        public Factura(Cliente cliente)
        {
            this.cliente = cliente;
            productos = new List<(Producto, int)>();
            descuento = 0;
            totalFactura = 0;
        }

        public Cliente GetCliente() => cliente;
        public List<(Producto, int)> GetProductos() => productos;
        public double GetDescuento() => descuento;
        public double GetTotalFactura() => totalFactura;

        // Añadir un producto a la factura
        public void AgregarProducto(Producto producto, int cantidad)
        {
            productos.Add((producto, cantidad));
            totalFactura += producto.GetPrecio() * cantidad;
        }

        // Aplicar el descuento por cumpleaños
        public void AplicarDescuento()
        {
            DateTime hoy = DateTime.Now;
            if (cliente.EsCumpleanos(hoy) && totalFactura <= 100)
            {
                descuento = totalFactura * 0.1; // 10% de descuento
                totalFactura -= descuento;
            }
        }

        // Mostrar la factura
        public void MostrarFactura()
        {
            Console.WriteLine("\n--- Factura ---");
            foreach (var item in productos)
            {
                Console.WriteLine($"{item.Item1.GetNombre()} x{item.Item2} = {item.Item1.GetPrecio() * item.Item2}");
            }
            Console.WriteLine($"Total: {totalFactura}");
            if (descuento > 0)
            {
                Console.WriteLine($"Descuento aplicado: {descuento}");
            }
            Console.WriteLine($"Total con descuento: {totalFactura}");
        }
    }
}
