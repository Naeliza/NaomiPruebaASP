using Persona.API.Entities;
using Persona.API.Models;

namespace Persona.API.Services
{
    public interface IPersonaRepository
    {
        Task <IEnumerable<EntPersona>> GetPersonasAsync();

        Task<EntPersona?> GetPersonasAsync(int id);

        Task AgregarPersonaAsync(EntPersona persona);

        Task ActualizarPersonaAsync(EntPersona persona);

        void BorrarPersona(EntPersona persona);

        Task<bool> GuardarCambiosAsync();
    }
}
