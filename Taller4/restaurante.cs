using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Restaurante
    {
        private List<Factura> facturas;
        private List<Cliente> clientes;
        private Menu menu;
        private int numeroDeMesas;
        private List<Mesa> mesas;

        public Restaurante(int numeroDeMesas, string rutaArchivoMenu)
        {
            this.numeroDeMesas = numeroDeMesas;
            this.facturas = new List<Factura>();
            this.clientes = new List<Cliente>();
            this.menu = new Menu(rutaArchivoMenu);
            this.mesas = new List<Mesa>();

            for (int i = 0; i < numeroDeMesas; i++)
            {
                mesas.Add(new Mesa());
            }
        }

        public List<Mesa> GetMesas() => mesas;
        public Menu GetMenu() => menu;
        public List<Factura> GetFacturas() => facturas;
        public List<Cliente> GetClientes() => clientes;

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
                mesas[numeroMesa - 1].AsignarCliente(cliente);
                Console.WriteLine($"Cliente {cliente.GetNombre()} asignado a la mesa {numeroMesa}.");
            }
            else
            {
                Console.WriteLine("Cliente ya está asignado o es nulo.");
            }
        }

        public Factura CrearFactura(Cliente cliente)
        {
            if (cliente == null)
            {
                Console.WriteLine("Cliente inválido.");
                return null;
            }

            var factura = new Factura(cliente);
            facturas.Add(factura);
            Console.WriteLine($"Factura creada para el cliente {cliente.GetNombre()}.");
            return factura;
        }
    }
}
