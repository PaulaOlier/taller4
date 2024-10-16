namespace Taller4
{
    public class Restaurante
    {
        private Menu menu;
        private List<Mesa> mesas;
        private List<Cliente> clientes;
        private const string rutaFacturas = @"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\facturas.csv"; 
        private const string rutaClientes = @"D:\Downloads\Pau\Pau\Semestre 2\taller4\Taller4\clientes.csv"; // Archivo CSV para clientes

        public Restaurante()
        {
            menu = new Menu();
            mesas = new List<Mesa>();
            clientes = new List<Cliente>();

            // Cargar clientes desde archivo CSV
            CargarClientesDesdeCSV(rutaClientes);

            // Crear 10 mesas
            for (int i = 1; i <= 10; i++)
            {
                Mesa mesa = new Mesa();
                mesa.SetNumero(i);
                mesas.Add(mesa);
            }
        }

        // Cargar los clientes desde un archivo CSV
        private void CargarClientesDesdeCSV(string archivo)
        {
            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllLines(archivo);
                foreach (var linea in lineas)
                {
                    var datos = linea.Split(',');
                    if (datos.Length == 3 && int.TryParse(datos[0], out int id))
                    {
                        var cliente = new Cliente(id, datos[1], datos[2]);
                        clientes.Add(cliente);
                    }
                }
            }
            else
            {
                Console.WriteLine("No se pudo cargar el archivo de clientes.");
            }
        }

        // Guardar los clientes en un archivo CSV
        private void GuardarClientesEnCSV(string archivo)
        {
            using (var writer = new StreamWriter(archivo))
            {
                foreach (var cliente in clientes)
                {
                    writer.WriteLine($"{cliente.Id},{cliente.Nombre},{cliente.Correo}");
                }
            }
        }

        // Agregar un cliente
        public void AgregarCliente(int id, string nombre, string correo)
        {
            Cliente nuevoCliente = new Cliente(id, nombre, correo);
            clientes.Add(nuevoCliente);
            Console.WriteLine("Cliente agregado correctamente.");
            GuardarClientesEnCSV(rutaClientes); // Guardar en CSV después de agregar
        }

        // Imprimir la lista de clientes
        public void ImprimirClientes()
        {
            Console.WriteLine("\n===== Lista de Clientes =====");
            foreach (var cliente in clientes)
            {
                cliente.MostrarInformacion();
            }
        }

        // Métodos para las opciones de agregar, eliminar, y editar productos, etc. (ya los tienes, pero los repito aquí para ser completos)
        public void AgregarProductoAMesa(int numeroMesa, int idProducto)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            Producto? producto = menu.BuscarProductoPorId(idProducto);
            if (mesa != null && producto != null)
            {
                mesa.AgregarProducto(producto);
            }
            else
            {
                Console.WriteLine(mesa == null ? "Mesa no encontrada." : "Producto no encontrado.");
            }
        }

        public void EliminarProducto(int numeroMesa, int idProducto)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                mesa.EliminarProducto(idProducto);
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }
        }

        public void ImprimirCuentaMesa(int numeroMesa)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                mesa.ImprimirCuenta();
                Factura factura = new Factura(numeroMesa, mesa.ObtenerTotal());
                factura.ImprimirFactura();
                factura.GuardarFactura(rutaFacturas);
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }
        }

        public void EditarProductoEnMenu(int id, string nombre, decimal precio, int cantidad)
        {
            menu.EditarProducto(id, nombre, precio, cantidad);
        }

        public void AgregarProductoAlMenu(int id, string nombre, decimal precio, int cantidad)
        {
            Producto nuevoProducto = new Producto(id, nombre, precio, cantidad);
            menu.AgregarProducto(nuevoProducto);
        }
    }
}
