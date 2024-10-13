using System;
using System.IO;
using Taller4;

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

            AsciiArt.ImprimirFacturaASCII();
            
            Console.WriteLine($"\n\t   Mesa: \n\t \t{NumeroMesa}");
            Console.WriteLine($"\t   Subtotal: \n\t \t{Total:C}");
            Console.WriteLine($"\t   Impuestos (15%):  \n\t\t{impuestos:C}");
            Console.WriteLine($"\t   Propina (10%):  \n\t\t{propina:C}");
            Console.WriteLine($"\t   Total:  \n\t\t{totalConImpuestos:C}");
            Console.WriteLine(new string('-', 20));
        }
    }
}
