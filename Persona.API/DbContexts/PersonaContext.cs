using Microsoft.EntityFrameworkCore;
using Persona.API.Entities;

namespace Persona.API.DbContexts
{
    public class PersonaContext : DbContext
    {
        public DbSet<EntPersona> Persona { get; set; } = null!;

        public PersonaContext(DbContextOptions<PersonaContext> options) : base(options)
        {

        }
    }
}
