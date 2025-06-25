using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCentroPsicopedagogico.Models

{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        public string DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        
        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        [Display(Name = "Obra Social")]
        public string ObraSocial { get; set; }

        [Display(Name = "Número de Afiliado")]
        public string NumeroAfiliado { get; set; }

        public bool Activo { get; set; }

       

        // Propiedad de solo lectura para nombre completo
        [NotMapped]
        public string NombreCompleto => $"{Apellido}, {Nombre}";
    }
}