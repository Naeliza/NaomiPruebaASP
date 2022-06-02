using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persona.API.Entities
{
    public class EntPersona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe llenar el parametro nombre")]
        [MaxLength(30)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe llenar el parametro fecha año-mes-dia")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        public EntPersona(string nombre)
        {
            Nombre = nombre;
        }
    }
}
