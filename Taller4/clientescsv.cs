using System;
using System.Collections.Generic;
using System.IO;

namespace Taller4
{
    public class ClientesCSV
    {
        private const string rutaClientes = @"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\clientes.csv"; // Ruta del archivo CSV de clientes
        private List<Cliente> clientes;

        public ClientesCSV()
        {
            clientes = new List<Cliente>();
            CargarClientesDesdeCSV(rutaClientes);
        }

        private void CargarClientesDesdeCSV(string archivo)
        {
            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllLines(archivo);
                foreach (var linea in lineas)
                {
                    var datos = linea.Split(',');
                    if (datos.Length == 3 && int.TryParse(datos[0], out int id))
                    {
                        var cliente = new Cliente(id, datos[1], datos[2]);
                        clientes.Add(cliente);
                    }
                }
            }
            else
            {
                Console.WriteLine("No se pudo cargar el archivo de clientes.");
            }
        }

        public void AgregarCliente(int id, string nombre, string correo)
        {
            Cliente nuevoCliente = new Cliente(id, nombre, correo);
            clientes.Add(nuevoCliente);
            GuardarClientesEnCSV(rutaClientes);
        }

        private void GuardarClientesEnCSV(string archivo)
        {
            using (var writer = new StreamWriter(archivo))
            {
                foreach (var cliente in clientes)
                {
                    writer.WriteLine($"{cliente.Id},{cliente.Nombre},{cliente.Correo}");
                }
            }
        }

        public void ImprimirClientes()
        {
            Console.WriteLine("===== Lista de Clientes =====");
            foreach (var cliente in clientes)
            {
                cliente.MostrarInformacion();
            }
        }
    }
}
