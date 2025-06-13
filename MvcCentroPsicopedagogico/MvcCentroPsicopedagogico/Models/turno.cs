using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCentroPsicopedagogico.Models
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha del Turno")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La hora es obligatoria")]
        [DataType(DataType.Time)]
        [Display(Name = "Hora del Turno")]
        public TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "El paciente es obligatorio")]
        [Display(Name = "Paciente")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "El profesional es obligatorio")]
        [Display(Name = "Profesional")]
        public int ProfesionalId { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder los 500 caracteres")]
        public string Observaciones { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Pendiente"; // Puede ser: Pendiente, Confirmado, Cancelado, Completado

        [Display(Name = "Motivo de Consulta")]
        [StringLength(200, ErrorMessage = "El motivo no puede exceder los 200 caracteres")]
        public string MotivoConsulta { get; set; }

        // Relaciones
        [ForeignKey("PacienteId")]
        public virtual Paciente Paciente { get; set; }

        [ForeignKey("ProfesionalId")]
        public virtual Profesional Profesional { get; set; }

        // Propiedad calculada (no se mapea a la base de datos)
        [NotMapped]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora => Fecha.Add(Hora);
    }
}