using System;

namespace Taller4
{
    public class Producto
    {
        private int Id { get; set; } // Identificador único del producto
        private string Nombre { get; set; } // Nombre del producto
        private decimal Precio { get; set; } // Precio del producto
        private int Cantidad { get; set; } // Cantidad disponible en inventario

        public Producto(int id, string nombre, decimal precio, int cantidad)
        {
            Id = id; 
            Nombre = nombre; 
            Precio = precio; 
            Cantidad = cantidad; 
        }

        // Getters y Setters
        public int GetId() => Id;
        public string GetNombre() => Nombre;
        public decimal GetPrecio() => Precio;
        public int GetCantidad() => Cantidad;

        public void SetCantidad(int cantidad) => Cantidad = cantidad;

        public override string ToString() => $"{Id}. {Nombre} - ${Precio} (Cantidad: {Cantidad})";
    }
}
