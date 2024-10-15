using System;

namespace Taller4
{
    public class Producto
    {
        private int Id { get; set; } // Identificador único del producto
        private string Nombre { get; set; } // Nombre del producto
        private decimal Precio { get; set; } // Precio del producto
        private int Cantidad { get; set; } // Cantidad disponible en inventario

        // Constructor para inicializar un producto
        public Producto(int id, string nombre, decimal precio, int cantidad)
        {
            Id = id; 
            Nombre = nombre; 
            Precio = precio; 
            Cantidad = cantidad; 
        }

        // Getters y Setters
        public int GetId() => Id; // Retorna el ID del producto
        public string GetNombre() => Nombre; // Retorna el nombre del producto
        public decimal GetPrecio() => Precio; // Retorna el precio del producto
        public int GetCantidad() => Cantidad; // Retorna la cantidad disponible

        // Establece la cantidad del producto
        public void SetCantidad(int cantidad) => Cantidad = cantidad;

        // Verificar si el producto está agotado
        public bool EstaAgotado() => Cantidad == 0;

        // Verificar si el stock es bajo (puede definir el umbral)
       public bool StockBajo() => Cantidad > 0 && Cantidad < 3;

        // Método para representar el producto como una cadena
        public override string ToString() => $"{Id}. {Nombre} - ${Precio} (Cantidad: {Cantidad})";
    }
}
