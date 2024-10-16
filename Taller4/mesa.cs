using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Mesa
    {
        private Cliente? cliente;
        private List<Producto> productos;

        public Mesa()
        {
            productos = new List<Producto>();
        }

        public void AsignarCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public void AgregarProducto(Producto producto)
        {
            if (producto != null)
            {
                productos.Add(producto);
                Console.WriteLine($"Producto {producto.GetNombre()} agregado a la mesa.");
            }
            else
            {
                Console.WriteLine("Producto nulo no se puede agregar.");
            }
        }

        public void MostrarProductos()
        {
            Console.WriteLine($"Productos en la mesa de {cliente?.GetNombre() ?? "Sin cliente asignado"}:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"- {producto.GetNombre()}");
            }
        }
    }
}
