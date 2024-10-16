namespace Taller4
{
    public class Mesa
    {
        private int numero;
        private Cliente cliente;

        public Mesa(int numero)
        {
            this.numero = numero;
            cliente = null;
        }

        public int GetNumero() => numero;
        public Cliente GetCliente() => cliente;

        // Asigna un cliente a la mesa
        public void AsignarCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }
    }
}
