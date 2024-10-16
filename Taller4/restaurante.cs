using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Restaurante
    {
        private List<Factura> facturas;
        private List<Cliente> clientes;
        private Menu menu;
        private List<Mesa> mesas;

        // Constructor
        public Restaurante(int numeroDeMesas, string rutaArchivoMenu)
        {
            this.facturas = new List<Factura>();
            this.clientes = new List<Cliente>();
            this.menu = new Menu(rutaArchivoMenu);
            this.mesas = new List<Mesa>();

            for (int i = 1; i <= numeroDeMesas; i++)
            {
                mesas.Add(new Mesa(i));
            }
        }

        // Asignar cliente a una mesa
        public void AsignarClienteAMesa(int numeroMesa, Cliente cliente)
        {
            if (numeroMesa < 1 || numeroMesa > mesas.Count)
            {
                Console.WriteLine("Número de mesa no válido.");
                return;
            }

            var mesa = mesas[numeroMesa - 1];
            mesa.AgregarProducto(cliente);  // Cambiar a la función que agregará un producto
            clientes.Add(cliente);
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
            Console.WriteLine("Factura creada con éxito.");
            return factura;
        }

        // Obtener las facturas
        public List<Factura> GetFacturas() => facturas;
        public Menu GetMenu() => menu;
        public List<Cliente> GetClientes() => clientes;
        public List<Mesa> GetMesas() => mesas;  // Para acceder a las mesas
    }
}
