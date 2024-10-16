using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Factura
    {
        private Cliente cliente;
        private List<(Producto, int)> productos;  // Lista de productos y cantidades
        private double descuento; // Descuento aplicado
        private double totalFactura;
        public int NumeroMesa { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public MedioPago MedioPago { get; set; }  // Asocia un medio de pago a la factura
         public bool EstaPagada { get; set; } // Atributo bool para el estado de pago

         decimal totalConImpuestos { get; set; }


     public Factura(Cliente cliente, int numeroMesa, decimal total, MedioPago medioPago)
        {
            this.cliente = cliente;
            productos = new List<(Producto, int)>();
            descuento = 0;
            totalFactura = 0;
            NumeroMesa = numeroMesa;
            Total = total;
            Fecha = DateTime.Now;
            MedioPago = medioPago;
             EstaPagada = false; // Por defecto, la factura está pendiente de pago
        
        }

        public Cliente GetCliente() => cliente;
        public List<(Producto, int)> GetProductos() => productos;
        public double GetDescuento() => descuento;
        public double GetTotalFactura() => totalFactura;

        // Añadir un producto a la factura
        public void AgregarProducto(Producto producto, int cantidad)
        {
            productos.Add((producto, cantidad));
            totalFactura += producto.GetPrecio() * cantidad;
        }

        // Aplicar el descuento por cumpleaños
        public void AplicarDescuento()
        {
            DateTime hoy = DateTime.Now;
            if (cliente.EsCumpleanos(hoy) && totalFactura <= 100)
            {
                descuento = totalFactura * 0.1; // 10% de descuento
                totalFactura -= descuento;
            }
        }

         public void GuardarFactura(string ruta)
        {
            string estadoPago = EstaPagada ? "Pagada" : "Pendiente"; // Convierte el estado a texto
            string linea = $"{NumeroMesa},{Total},{Fecha},{estadoPago}";
            File.AppendAllText(ruta, linea + Environment.NewLine);
        }

        // Método para marcar la factura como pagada
        public void MarcarComoPagado()
        {
            EstaPagada = true; // Cambia el estado a pagado
        }

        // Mostrar la factura
        public void MostrarFactura()
        {
            Console.WriteLine("\n--- Factura ---");
            foreach (var item in productos)
            {
                Console.WriteLine($"{item.Item1.GetNombre()} x{item.Item2} = {item.Item1.GetPrecio() * item.Item2}");
            }
            Console.WriteLine($"Total: {totalFactura}");
           
            if (descuento > 0)
            {
                Console.WriteLine($"Descuento aplicado: {descuento}");
            }
            Console.WriteLine($"Total con descuento: {totalFactura}");
        }

         // Método para imprimir la factura y luego preguntar cómo desea pagar
        public void ImprimirFactura()
        {
            decimal impuestos = Total * 0.15m; // 15% de impuestos
            decimal propina = Total * 0.10m;   // 10% de propina
            decimal totalConImpuestos = Total + impuestos + propina;

            // Imprime la factura
            Console.WriteLine("_______________________________________");
            AsciiArt.ImprimirFacturaASCII();
            Console.WriteLine($"|\t   Mesa:               \t{NumeroMesa}     |");
            Console.WriteLine($"|\t   Subtotal:        \t{Total:C} |");
            Console.WriteLine($"|\t   Impuestos (15%):  \t{impuestos:C} |");
            Console.WriteLine($"|\t   Propina (10%):  \t{propina:C} |");
            Console.WriteLine($"|\t   Total:        \t{totalConImpuestos:C} |");
            Console.WriteLine($"|{new string('-', 20)}                 |");
            
            // Preguntar cómo desea pagar
            PreguntarMetodoPago(totalConImpuestos);
        }

        // Método que pregunta el medio de pago al usuario
        public void PreguntarMetodoPago(decimal totalConImpuestos)
        {
            Console.WriteLine("\n¿Cómo desea pagar?");
            Console.WriteLine("1. Tarjeta de Crédito");
            Console.WriteLine("2. Tarjeta de Débito");
            Console.WriteLine("3. Efectivo");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            MedioPago medioPago = null;

            switch (opcion)
            {
                case "1":
                    medioPago = ObtenerDatosTarjetaCredito(totalConImpuestos);
                    break;
                case "2":
                    medioPago = ObtenerDatosTarjetaDebito(totalConImpuestos);
                    break;
                case "3":
                    medioPago = new PagoEfectivo(totalConImpuestos);
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
                    PreguntarMetodoPago(totalConImpuestos); // Repite la pregunta si la opción no es válida
                    return;
            }

            // Procesar el pago
            medioPago.ProcesarPago();

            // Cambiar el estado de la factura a pagada
            EstaPagada = true;
            Console.WriteLine("\n¡Pago realizado con éxito! La factura ha sido marcada como pagada.");
        }

        // Obtener los datos para el pago con tarjeta de crédito
        private MedioPago ObtenerDatosTarjetaCredito(decimal monto)
        {
            Console.Write("Ingrese el número de la tarjeta de crédito: ");
            string numeroTarjeta = Console.ReadLine();
            Console.Write("Ingrese el nombre del titular: ");
            string nombreTitular = Console.ReadLine();
            Console.Write("Ingrese la fecha de expiración (MM/AA): ");
            DateTime fechaExpiracion = DateTime.Parse(Console.ReadLine());
            Console.Write("Ingrese el CVV: ");
            string cvv = Console.ReadLine();

            return new PagoTarjetaCredito(monto, numeroTarjeta, nombreTitular, fechaExpiracion, cvv);
        }

        // Obtener los datos para el pago con tarjeta de débito
        private MedioPago ObtenerDatosTarjetaDebito(decimal monto)
        {
            Console.Write("Ingrese el número de la tarjeta de débito: ");
            string numeroTarjeta = Console.ReadLine();
            Console.Write("Ingrese el nombre del titular: ");
            string nombreTitular = Console.ReadLine();
            Console.Write("Ingrese la fecha de expiración (MM/AA): ");
            DateTime fechaExpiracion = DateTime.Parse(Console.ReadLine());

            return new PagoTarjetaDebito(monto, numeroTarjeta, nombreTitular, fechaExpiracion);
        }

        internal void PreguntarMetodoPago()
        {
            throw new NotImplementedException();
        }
    }
}
