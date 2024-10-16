namespace Taller4
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Cliente(int id, string nombre, string correo)
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            FechaRegistro = DateTime.Now;
        }

        // Método para mostrar información del cliente
        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id} - Nombre: {Nombre} - Correo: {Correo} - Fecha de Registro: {FechaRegistro}");
        }
    }
}
