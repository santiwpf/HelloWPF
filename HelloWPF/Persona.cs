using System;

namespace HelloWPF
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Apellido2 { get; set; }
        public string NombreCompleto { get { return Nombre + " " + Apellido + " " + Apellido2; } }
    }
}