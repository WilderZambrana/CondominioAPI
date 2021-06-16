using CondominioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Services
{
    public interface IPersonasService
    {
        public Task<IEnumerable<PersonaModel>> GetPersonasAsync();
        public Task<PersonaModel> GetPersonaAsync(long personaId);
        public Task<PersonaModel> CreatePersonaAsync(PersonaModel newPersona);
        public Task<bool> DeletePersonaAsync(long personaId);
        public Task<PersonaModel> UpdatePersonaAsync(long personaId, PersonaModel updatedPersona);

    }
}
