using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Persona.API.DbContexts;
using Persona.API.Entities;
using Persona.API.Models;
using Persona.API.Services;

namespace Persona.API.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly PersonaContext _context;

        public PersonaController(IPersonaRepository personaRepository, PersonaContext context)
        {
            _personaRepository = personaRepository ?? throw new ArgumentNullException(nameof(personaRepository));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> getPersonas()
        {
            var personaEntities = await _personaRepository.GetPersonasAsync();
            return Ok(personaEntities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getPersonas(int id)
        {
            var persona = await _personaRepository.GetPersonasAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);

        }


        [HttpPost]
        public async Task<ActionResult<EntPersona>> CrearPersona(NuevaPersonaDTO persona)
        {

            EntPersona nuevaPersona = new EntPersona(persona.Nombre)
            {
                Nombre = persona.Nombre,
                FechaDeNacimiento = persona.FechaDeNacimiento
            };

            await _personaRepository.AgregarPersonaAsync(nuevaPersona);

            await _personaRepository.GuardarCambiosAsync();

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarPersona(int id, ActualizarPersonaDTO persona)
        {

            var existePersona = _context.Persona.FirstOrDefault(p => p.Id == id);

            if (existePersona == null)
            {
                return NotFound();
            }

            existePersona.Nombre = persona.Nombre;
            existePersona.FechaDeNacimiento = Convert.ToDateTime(persona.FechaNacimiento);

           await  _personaRepository.ActualizarPersonaAsync(existePersona);

            await _personaRepository.GuardarCambiosAsync();

            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarPersona(int id)
        {

            var persona = await _personaRepository.GetPersonasAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

             _personaRepository.BorrarPersona(persona);
            await _personaRepository.GuardarCambiosAsync();

            return NoContent();

        }
    }
}