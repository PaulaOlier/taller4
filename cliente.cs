using System;

namespace Taller4
{
    public class Cliente
    {
        public int Id { get; set; } // Identificador único del cliente
        public string Nombre { get; set; } // Nombre del cliente
        public string Correo { get; set; } // Correo electrónico del cliente
        public DateTime FechaRegistro { get; set; } // Fecha de registro del cliente

        // Constructor para inicializar un cliente
        public Cliente(int id, string nombre, string correo)
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            FechaRegistro = DateTime.Now; // Asigna la fecha de registro automáticamente
        }


