public class Producto
{
    private int Id { get; set; }
    private string Nombre { get; set; }
    private decimal Precio { get; set; }
    private int Cantidad { get; set; }

    // Constructor
    public Producto(int id, string nombre, decimal precio, int cantidad)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }

    // Métodos públicos para obtener los valores
    public int GetId() => Id;
    public string GetNombre() => Nombre;
    public decimal GetPrecio() => Precio;
    public int GetCantidad() => Cantidad;

    // Métodos públicos para establecer los valores
    public void SetNombre(string nombre) => Nombre = nombre;
    public void SetPrecio(decimal precio) => Precio = precio;
    public void SetCantidad(int cantidad) => Cantidad = cantidad;

    // Método ToString
    public override string ToString() => $"{Id}. {Nombre} - ${Precio} (Cantidad: {Cantidad})";
}
