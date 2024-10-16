public class Producto
{
    private int id;
    private string nombre;
    private double precio;
    private int cantidad;

    // Constructor
    public Producto(int id, string nombre, double precio, int cantidad)
    {
        this.id = id;
        this.nombre = nombre;
        this.precio = precio;
        this.cantidad = cantidad;
    }

    // Getters
    public int GetId() => id;
    public string GetNombre() => nombre;
    public double GetPrecio() => precio;
    public int GetCantidad() => cantidad;

    // Setters
    public void SetNombre(string value) => nombre = value;
    public void SetPrecio(double value) => precio = value;
    public void SetCantidad(int value) => cantidad = value;
}
