using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Restaurante
    {
        private Menu menu;
        private List<Mesa> mesas;
        private ClientesCSV clientesCSV;
        private const string rutaFacturas = @"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\facturas.csv"; // Ruta del archivo CSV para las facturas

        public Restaurante()
        {
            menu = new Menu();
            mesas = new List<Mesa>();
            clientesCSV = new ClientesCSV();

            // Crear 10 mesas
            for (int i = 1; i <= 10; i++)
            {
                Mesa mesa = new Mesa();
                mesa.SetNumero(i);
                mesas.Add(mesa);
            }
        }

        // Opción 1: Imprimir menú
        public void ImprimirMenu()
        {
            menu.ImprimirMenu();
        }

        // Opción 2: Agregar producto a una mesa
        public void AgregarProductoAMesa(int numeroMesa, int idProducto)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            Producto? producto = menu.BuscarProductoPorId(idProducto);
            if (mesa != null && producto != null)
            {
                mesa.AgregarProducto(producto);
            }
            else
            {
                Console.WriteLine("Mesa o Producto no encontrado.");
            }
        }

        // Opción 3: Eliminar producto de una mesa
        public void EliminarProducto(int numeroMesa, int idProducto)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                mesa.EliminarProducto(idProducto);
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }
        }

        // Opción 4: Imprimir cuenta de mesa
        public void ImprimirCuentaMesa(int numeroMesa)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                mesa.ImprimirCuenta();
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }
        }

        // Opción 5: Agregar cliente
        public void AgregarCliente(int id, string nombre, string correo)
        {
            clientesCSV.AgregarCliente(id, nombre, correo);
        }

        // Opción 6: Imprimir lista de clientes
        public void ImprimirClientes()
        {
            clientesCSV.ImprimirClientes();
        }
    }
}
