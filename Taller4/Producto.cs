namespace Taller4
{
    public class Producto
    {
        private int id;
        private string nombre;
        private double precio;
        private int cantidad;

        // Constructor de Producto
        public Producto(int id, string nombre, double precio, int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        // Getters y Setters
        public int GetId() => id;
        public void SetId(int value) => id = value;

        public string GetNombre() => nombre;
        public void SetNombre(string value) => nombre = value;

        public double GetPrecio() => precio;
        public void SetPrecio(double value) => precio = value;

        public int GetCantidad() => cantidad;
        public void SetCantidad(int value) => cantidad = value;
    }
}
