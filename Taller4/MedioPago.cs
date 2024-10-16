namespace Taller4
{
    // Clase abstracta MedioPago
    public abstract class MedioPago
    {
        public decimal Monto { get; set; }

        public MedioPago(decimal monto)
        {
            Monto = monto;
        }

        // Método abstracto que las clases hijas deben implementar
        public abstract void ProcesarPago();
    }
}
