using AutoMapper;
using CondominioAPI.Data.Entities;
using CondominioAPI.Data.Repository;
using CondominioAPI.Exceptions;
using CondominioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Services
{
    public class PersonasService : IPersonasService
    {
        private ICondominioRepository _condominioRepository;
        private IMapper _mapper;
        public PersonasService(ICondominioRepository condominioRepository, IMapper mapper)
        {
            _condominioRepository = condominioRepository;
            _mapper = mapper;
        }

        public async Task<PersonaModel> CreatePersonaAsync(PersonaModel newPersona)
        {
            var resultEntity = _mapper.Map<PersonaEntity>(newPersona);
            _condominioRepository.CreatePersona(resultEntity);
            var result = await _condominioRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<PersonaModel>(resultEntity);
            }
            throw new Exception("Database Error");
        }
        public async Task<bool> DeletePersonaAsync(long personaId)
        {
            await ValidatePersonaAsync(personaId);
            await _condominioRepository.DeletePersonaAsync(personaId);
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return true;
        }
        public async Task<PersonaModel> GetPersonaAsync(long personaId)
        {
            var result = await _condominioRepository.GetPersonaAsync(personaId);

            if (result == null)
            {
                throw new NotFoundItemException($"The person with id: {personaId} does not exist.");
            }
            return _mapper.Map<PersonaModel>(result);
        }
        public async Task<IEnumerable<PersonaModel>> GetPersonasAsync()
        {
            var entityList = await _condominioRepository.GetPersonasAsync();
            var modelList = _mapper.Map<IEnumerable<PersonaModel>>(entityList);
            return modelList;
        }
        public async Task<PersonaModel> UpdatePersonaAsync(long personaId, PersonaModel updatedPersona)
        {
            await GetPersonaAsync(personaId);
            updatedPersona.Id = personaId;
            await _condominioRepository.UpdatePersonaAsync(personaId, _mapper.Map<PersonaEntity>(updatedPersona));
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return _mapper.Map<PersonaModel>(updatedPersona);
        }

        private async Task ValidatePersonaAsync(long personaId)
        {
            await GetPersonaAsync(personaId);
        }
    }
}
