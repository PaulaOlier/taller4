namespace Taller4
{
    public abstract class MedioPago
    {
        public decimal Monto { get; private set; }

        public MedioPago(decimal monto)
        {
            Monto = monto;
        }

        // Método abstracto que las clases hijas deben implementar
        public abstract void ProcesarPago();
    }
}
