using System;

namespace Taller4
{
    public class Cliente
    {
        private string nombre;
        private DateTime fechaNacimiento;

        // Constructor
        public Cliente(string nombre, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
        }

        // Getter para el nombre
        public string GetNombre()
        {
            return nombre;
        }

        // Getter para la fecha de nacimiento
        public DateTime GetFechaNacimiento()
        {
            return fechaNacimiento;
        }

        // Método para verificar si es el cumpleaños del cliente este mes
        public bool EsCumpleaneroEsteMes()
        {
            DateTime hoy = DateTime.Now;

            // Compara solo el mes y el día de la fecha de nacimiento con la fecha actual
            return fechaNacimiento.Month == hoy.Month && fechaNacimiento.Day == hoy.Day;
        }
    }
}
