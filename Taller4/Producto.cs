namespace Taller4
{
    public class Producto
    {
        private int id;
        private string nombre;
        private double precio;

        public Producto(int id, string nombre, double precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
        }

        public int GetId() => id;
        public string GetNombre() => nombre;
        public double GetPrecio() => precio;
    }
}
