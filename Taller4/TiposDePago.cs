namespace Taller4
{
    // Clase para pago con tarjeta de crédito
    public class PagoTarjetaCredito : MedioPago
    {
        public string NumeroTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string CVV { get; set; }

        public PagoTarjetaCredito(decimal monto, string numeroTarjeta, string nombreTitular, DateTime fechaExpiracion, string cvv)
            : base(monto)
        {
            NumeroTarjeta = numeroTarjeta;
            NombreTitular = nombreTitular;
            FechaExpiracion = fechaExpiracion;
            CVV = cvv;
        }

        public override void ProcesarPago()
        {
            // Lógica para procesar el pago con tarjeta de crédito
            Console.WriteLine($"Procesando pago de {Monto:C} con tarjeta de crédito (Titular: {NombreTitular})");
        }
    }

    // Clase para pago con tarjeta de débito
    public class PagoTarjetaDebito : MedioPago
    {
        public string NumeroTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public DateTime FechaExpiracion { get; set; }

        public PagoTarjetaDebito(decimal monto, string numeroTarjeta, string nombreTitular, DateTime fechaExpiracion)
            : base(monto)
        {
            NumeroTarjeta = numeroTarjeta;
            NombreTitular = nombreTitular;
            FechaExpiracion = fechaExpiracion;
        }

        public override void ProcesarPago()
        {
            // Lógica para procesar el pago con tarjeta de débito
            Console.WriteLine($"Procesando pago de {Monto:C} con tarjeta de débito (Titular: {NombreTitular})");
        }
    }

    // Clase para pago en efectivo
    public class PagoEfectivo : MedioPago
    {
        public PagoEfectivo(decimal monto) : base(monto)
        {
        }

        public override void ProcesarPago()
        {
            // Lógica para procesar el pago en efectivo
            Console.WriteLine($"Procesando pago en efectivo de {Monto:C}");
        }
    }
}

