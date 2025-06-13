using MvcCentroPsicopedagogico.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCentroPsicopedagogico.Models
{
    public class Profesional
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La matrícula es obligatoria")]
        [StringLength(20, ErrorMessage = "La matrícula no puede exceder los 20 caracteres")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        public string Especialidad { get; set; }

        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        public string Telefono { get; set; }

        public bool Activo { get; set; } = true;

        // Relación con Turnos
        public virtual ICollection<Turno> Turnos { get; set; }

        // Propiedad de solo lectura para nombre completo
        [NotMapped]
        public string NombreCompleto => $"{Apellido}, {Nombre} ({Especialidad})";
    }
}