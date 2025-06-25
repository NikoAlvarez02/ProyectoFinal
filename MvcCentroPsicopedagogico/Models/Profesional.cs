using MvcCentroPsicopedagogico.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCentroPsicopedagogico.Models
{
    public class Profesional
    {
        public int Id { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }
        public string Matricula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Especialidad { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public bool Activo { get; set; } = true;


        // Propiedad de solo lectura para nombre completo
        [NotMapped]
        public string NombreCompleto => $"{Apellido}, {Nombre} ({Especialidad})";
    }
}