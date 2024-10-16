using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Restaurante
    {
        private List<Mesa> mesas;
        private Menu menu;
        private List<Factura> facturas;
        private List<Cliente> clientes;
        public int NumeroMesa { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public MedioPago MedioPago { get; set; }  // Asocia un medio de pago a la factura

        public Restaurante(int cantidadMesas)
        {
            mesas = new List<Mesa>();
            for (int i = 0; i < cantidadMesas; i++)
            {
                mesas.Add(new Mesa(i + 1)); // Creamos mesas con IDs 1, 2, ...
            }
            menu = new Menu();
            facturas = new List<Factura>();
            clientes = new List<Cliente>();
        }

        

        public List<Mesa> GetMesas() => mesas;
        public Menu GetMenu() => menu;
        public List<Factura> GetFacturas() => facturas;
        public List<Cliente> GetClientes() => clientes;

        // Asigna un cliente a una mesa
        public void AsignarClienteAMesa(int numeroMesa, Cliente cliente)
        {
            var mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null && mesa.GetCliente() == null)
            {
                mesa.AsignarCliente(cliente);
                clientes.Add(cliente);
                Console.WriteLine($"Cliente {cliente.GetNombre()} asignado a la mesa {numeroMesa}.");
            }
            else
            {
                Console.WriteLine("La mesa ya está ocupada o no existe.");
            }
        }

        // Crear una factura para un cliente
        public Factura CrearFactura(Cliente cliente)
        {
            Factura factura = new Factura(cliente);
            facturas.Add(factura);
            return factura;
        }

        // Mostrar el menú de productos
        public void MostrarMenu()
        {
            Console.WriteLine("\n--- Menú ---");
            foreach (var producto in menu.GetProductos())
            {
                Console.WriteLine($"{producto.GetId()}. {producto.GetNombre()} - {producto.GetPrecio()}");
            }
        }

        // Buscar un producto por su ID
        public Producto BuscarProductoPorId(int id)
        {
            return menu.GetProductos().Find(p => p.GetId() == id);
        }

        // Agregar un producto a la factura
        public void AgregarProductoAFactura(Factura factura, int idProducto, int cantidad)
        {
            Producto producto = menu.GetProducto(idProducto);
            if (producto != null)
            {
                factura.AgregarProducto(producto, cantidad);
                Console.WriteLine($"Producto {producto.GetNombre()} agregado a la factura.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Mostrar todas las facturas
        public void MostrarFacturas()
        {
            Console.WriteLine("\n--- Todas las Facturas ---");
            foreach (var factura in facturas)
            {
                factura.MostrarFactura();
            }
        }
    }
}
