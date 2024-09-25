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

        public void GuardarFactura()
        {
            string ruta = "facturas.csv";
            string linea = $"{NumeroMesa},{Total},{Fecha}";
            File.AppendAllText(ruta, linea + Environment.NewLine);
        }
    }
}
