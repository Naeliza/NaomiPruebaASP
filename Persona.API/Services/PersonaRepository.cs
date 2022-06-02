using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persona.API.DbContexts;
using Persona.API.Entities;
using Persona.API.Models;

namespace Persona.API.Services
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaContext _context;

        public PersonaRepository(PersonaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AgregarPersonaAsync(EntPersona persona)
        {
            await _context.Persona.AddAsync(persona);
        }

        public async Task<IEnumerable<EntPersona>> GetPersonasAsync()
        {
            return await _context.Persona.OrderBy(p => p.Nombre).ToListAsync();
        }

        public async Task<EntPersona?> GetPersonasAsync(int id)
        {
            return await _context.Persona.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> GuardarCambiosAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public Task ActualizarPersonaAsync(EntPersona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public void BorrarPersona(EntPersona persona)
        {
            _context.Persona.Remove(persona);
        }
    }
}
