using System.ComponentModel.DataAnnotations;

namespace CrudPersona.Models
{
    public class PersonaViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }
    }
}
