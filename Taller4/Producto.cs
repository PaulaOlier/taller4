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
        public string GetNombre() => nombre;
        public double GetPrecio() => precio;
        public int GetCantidad() => cantidad;

        public void SetNombre(string value) => nombre = value;
        public void SetPrecio(double value) => precio = value;
        public void SetCantidad(int value) => cantidad = value;
    }
}
