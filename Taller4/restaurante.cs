using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Restaurante
    {
        private Menu menu;
        private List<Mesa> mesas;

        public Restaurante()
        {
            menu = new Menu();
            mesas = new List<Mesa>();

            for (int i = 1; i <= 10; i++)
            {
                Mesa mesa = new Mesa();
                mesa.SetNumero(i);
                mesas.Add(mesa);
            }
        }

        public void ImprimirMenu() => menu.ImprimirMenu();

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
                Console.WriteLine(mesa == null ? "Mesa no encontrada." : "Producto no encontrado.");
            }
        }

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

        public void ImprimirCuentaMesa(int numeroMesa)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                mesa.ImprimirCuenta();
                Factura factura = new Factura(numeroMesa, mesa.ObtenerTotal());
                factura.GuardarFactura();
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }
        }

        public void EditarProductoEnMenu(int id, string nombre, decimal precio, int cantidad)
        {
            menu.EditarProducto(id, nombre, precio, cantidad);
        }

        public void AgregarProductoAlMenu(int id, string nombre, decimal precio, int cantidad)
        {
            Producto nuevoProducto = new Producto(id, nombre, precio, cantidad);
            menu.AgregarProducto(nuevoProducto);
        }
    }
}
