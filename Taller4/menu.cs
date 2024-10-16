using System;
using System.Collections.Generic;

namespace Taller4
{
    public class Menu
    {
        private List<Producto> productos;

        public Menu()
        {
            productos = new List<Producto>
            {
                new Producto(1, "Hamburguesa", 8.99),
                new Producto(2, "Pizza", 12.99),
                new Producto(3, "Ensalada", 6.50),
                new Producto(4, "Soda", 2.00)
            };
        }

        public List<Producto> GetProductos() => productos;

        // Buscar un producto por su ID
        public Producto GetProducto(int id)
        {
            return productos.Find(p => p.GetId() == id);
        }
    }
}
