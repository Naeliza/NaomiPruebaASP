using System.ComponentModel.DataAnnotations;

namespace Persona.API.Models
{
    public class NuevaPersonaDTO
    {
        [Required(ErrorMessage = "Se debe ingresar el campo nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public DateTime FechaDeNacimiento { get; set; }
    }
}
