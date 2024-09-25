using System;
using System.IO;

namespace Taller4
{
    public class Factura
    {
        public int NumeroMesa { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public Factura(int numeroMesa, decimal total)
        {
            NumeroMesa = numeroMesa;
            Total = total;
            Fecha = DateTime.Now;
        }

        // Método para guardar la factura en un archivo CSV
        public void GuardarFactura(string ruta)
        {
            string linea = $"{NumeroMesa},{Total},{Fecha}";
            File.AppendAllText(ruta, linea + Environment.NewLine);
        }

        // Método para imprimir la factura en formato tirilla
        public void ImprimirFactura()
        {
            decimal impuestos = Total * 0.15m; // Ejemplo: 15% de impuestos
            decimal propina = Total * 0.10m; // Ejemplo: 10% de propina
            decimal totalConImpuestos = Total + impuestos + propina;

            Console.WriteLine("Factura:");
            Console.WriteLine($"Mesa: {NumeroMesa}");
            Console.WriteLine($"Subtotal: {Total:C}");
            Console.WriteLine($"Impuestos (15%): {impuestos:C}");
            Console.WriteLine($"Propina (10%): {propina:C}");
            Console.WriteLine($"Total: {totalConImpuestos:C}");
            Console.WriteLine(new string('-', 20));
        }
    }
}
