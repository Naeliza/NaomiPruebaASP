using System.ComponentModel.DataAnnotations;

namespace Persona.API.Models
{
    public class PersonaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
    }
}
