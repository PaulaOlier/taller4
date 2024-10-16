using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Restaurante
    {
        private Menu menu; // Instancia de la clase Menu para manejar los productos
        private List<Mesa> mesas; // Lista de mesas del restaurante
        private List<Cliente> clientes; // Lista de clientes del restaurante
        private const string rutaFacturas = @"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\facturas.csv"; // Ruta de archivo CSV

        public Restaurante()
        {
            menu = new Menu();
            mesas = new List<Mesa>();
            clientes = new List<Cliente>();

            // Crear 10 mesas
            for (int i = 1; i <= 10; i++)
            {
                Mesa mesa = new Mesa();
                mesa.SetNumero(i);
                mesas.Add(mesa);
            }
        }

        // Método para imprimir el menú del restaurante
        public void ImprimirMenu() => menu.ImprimirMenu();

        // Método para agregar un cliente al restaurante
        public void AgregarCliente(int id, string nombre, string correo)
        {
            Cliente cliente = new Cliente(id, nombre, correo);
            clientes.Add(cliente);
            Console.WriteLine("Cliente agregado al restaurante.");
        }

        // Método para asignar un cliente a una mesa
        public void AsignarClienteAMesa(int numeroMesa, int idCliente)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            Cliente? cliente = clientes.Find(c => c.Id == idCliente);

            if (mesa != null && cliente != null)
            {
                mesa.Cliente = cliente; // Asigna el cliente a la mesa
                Console.WriteLine($"Cliente {cliente.Nombre} asignado a la mesa {mesa.GetNumero()}.");
            }
            else
            {
                Console.WriteLine("Mesa o cliente no encontrados.");
            }
        }

        // Método para imprimir la cuenta de una mesa y generar la factura
        public void ImprimirCuentaMesa(int numeroMesa)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                mesa.ImprimirCuenta();
                Factura factura = new Factura(numeroMesa, mesa.ObtenerTotal());
                factura.ImprimirFactura();
                factura.GuardarFactura(rutaFacturas);
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }
        }
    }
}
