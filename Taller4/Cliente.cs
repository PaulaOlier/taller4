using System;

namespace Taller4
{
    public class Cliente
    {
        private string nombre;
        private DateTime fechaNacimiento;

        public Cliente(string nombre, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
        }

        public string GetNombre() => nombre;

        public DateTime GetFechaNacimiento() => fechaNacimiento;
    }
}
