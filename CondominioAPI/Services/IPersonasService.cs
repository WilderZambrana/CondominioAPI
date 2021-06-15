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
        public Task<PersonaModel> CreatePersonaAsync(PersonaModel newPersona);
    }
}
