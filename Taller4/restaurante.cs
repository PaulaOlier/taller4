using System;
using System.Collections.Generic;
using System.Linq;

namespace Taller4
{
    public class Restaurante
    {
        private List<Factura> facturas;
        private List<Cliente> clientes;
        private Menu menu;
        private int numeroDeMesas;

        // Constructor
        public Restaurante(int numeroDeMesas, string rutaArchivoMenu)
        {
            this.numeroDeMesas = numeroDeMesas;
            this.facturas = new List<Factura>();
            this.clientes = new List<Cliente>();
            this.menu = new Menu(rutaArchivoMenu);
        }

        // Asignar cliente a una mesa
        public void AsignarClienteAMesa(int numeroMesa, Cliente cliente)
        {
            if (numeroMesa < 1 || numeroMesa > numeroDeMesas)
            {
                Console.WriteLine("Número de mesa no válido.");
                return;
            }

            if (cliente != null && !clientes.Contains(cliente))
            {
                clientes.Add(cliente);
                Console.WriteLine($"Cliente {cliente.GetNombre()} asignado a la mesa {numeroMesa}");
            }
            else
            {
                Console.WriteLine("Cliente ya está asignado.");
            }
        }

        // Crear una factura para un cliente
        public Factura CrearFactura(Cliente cliente)
        {
            if (cliente == null)
            {
                Console.WriteLine("Cliente inválido.");
                return null;
            }

            var factura = new Factura(cliente);
            facturas.Add(factura);
            return factura;
        }

        // Obtener las facturas
        public List<Factura> GetFacturas() => facturas;

        // Obtener el menú
        public Menu GetMenu() => menu;

        // Obtener la lista de clientes
        public List<Cliente> GetClientes() => clientes;
    }
}
