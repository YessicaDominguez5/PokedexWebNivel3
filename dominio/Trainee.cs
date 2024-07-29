using System;

namespace dominio
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; } = new DateTime(1970,1,1);
        public string ImagenPerfil { get; set; }
        public bool Admin { get; set; }

    }
}
