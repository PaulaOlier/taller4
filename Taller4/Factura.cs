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
        public bool EstaPagada { get; set; } // Nuevo atributo para indicar el estado de la factura
         
       

        public Factura(int numeroMesa, decimal total)
        {
            NumeroMesa = numeroMesa;
            Total = total;
            Fecha = DateTime.Now;
            EstaPagada=false;
        }

        // Método para guardar la factura en un archivo CSV
        public void GuardarFactura(string ruta)
        {
            string estadoPago = EstaPagada ? "Pagada" : "Pendiente"; // Convierte el estado a texto
            string linea = $"{NumeroMesa},{Total},{Fecha}";
            File.AppendAllText(ruta, linea + Environment.NewLine);
        }

          // Método para marcar la factura como pagada
        public void MarcarComoPagado()
        {
            EstaPagada = true; // Cambia el estado a pagado
        }

        // Método para imprimir la factura en formato tirilla
        public void ImprimirFactura()
        {    
               

            decimal impuestos = Total * 0.15m; // Ejemplo: 15% de impuestos
            decimal propina = Total * 0.10m; // Ejemplo: 10% de propina
            decimal totalConImpuestos = Total + impuestos + propina;

            Console.WriteLine("_______________________________________"); 
            AsciiArt.ImprimirFacturaASCII();
            
            Console.WriteLine($"|\t   Mesa:               \t{NumeroMesa}      |");
            Console.WriteLine($"|\t   Subtotal:        \t{Total:C}  |");
            Console.WriteLine($"|\t   Impuestos (15%):  \t{impuestos:C}  |");
            Console.WriteLine($"|\t   Propina (10%):  \t{propina:C}  |");
            Console.WriteLine($"|\t   Total:        \t{totalConImpuestos:C}  |");
            Console.WriteLine($"|{new string('-', 20)}                  |");    
            // Imprime el estado de pago
            string estadoPago = EstaPagada ? "Pagada" : "Pendiente por pagar";
            Console.WriteLine($"|   Estado de pago:  {estadoPago}  |");       
        }
    }
}
