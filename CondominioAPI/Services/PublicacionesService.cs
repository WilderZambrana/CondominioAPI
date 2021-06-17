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
    public class PublicacionesService : IPublicacionesService
    {
        private ICondominioRepository _condominioRepository;
        private IMapper _mapper;
        public PublicacionesService(ICondominioRepository condominioRepository, IMapper mapper)
        {
            _condominioRepository = condominioRepository;
            _mapper = mapper;
        }

        public async Task<PublicacionModel> CreatePublicacionAsync(long personaId, PublicacionModel newPublicacion)
        {
            await ValidatePersonaAsync(personaId);
            newPublicacion.PersonaId = personaId;
            var resultEntity = _mapper.Map<PublicacionEntity>(newPublicacion);
            _condominioRepository.CreatePublicacion(personaId, resultEntity);
            var result = await _condominioRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<PublicacionModel>(resultEntity);
            }
            throw new Exception("Database Error");
        }
        public async Task<bool> DeletePublicacionAsync(long personaId, long publicacionId)
        {
            await ValidatePersonaAndPublicacionAsync(personaId, publicacionId);
            await _condominioRepository.DeletePublicacionAsync(personaId, publicacionId);
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return true;
        }
        public async Task<PublicacionModel> GetPublicacionAsync(long personaId, long publicacionId)
        {
            await ValidatePersonaAsync(personaId);
            var result = await _condominioRepository.GetPublicacionAsync(personaId, publicacionId);

            if (result == null)
            {
                throw new NotFoundItemException($"The publicacion with id: {publicacionId} does not exist.");
            }
            var resModel = _mapper.Map<PublicacionModel>(result);
            resModel.PersonaId = personaId;
            return resModel;
        }
        public async Task<IEnumerable<PublicacionModel>> GetPublicacionesAsync(long personaId)
        {
            await ValidatePersonaAsync(personaId);
            var entityList = await _condominioRepository.GetPublicacionesAsync(personaId);
            return _mapper.Map<IEnumerable<PublicacionModel>>(entityList);
        }
        public async Task<PublicacionModel> UpdatePublicacionAsync(long personaId, long publicacionId, PublicacionModel updatedPublicacion)
        {
            await ValidatePersonaAndPublicacionAsync(personaId, publicacionId);
            await _condominioRepository.UpdatePublicacionAsync(personaId, publicacionId, _mapper.Map<PublicacionEntity>(updatedPublicacion));
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return _mapper.Map<PublicacionModel>(updatedPublicacion);
        }

        private async Task ValidatePersonaAndPublicacionAsync(long personaId, long publicacionId)
        {
            var publicacion = await GetPublicacionAsync(personaId, publicacionId);
        }
        private async Task ValidatePersonaAsync(long personaId)
        {
            var persona = await _condominioRepository.GetPersonaAsync(personaId);
            if(persona ==null)
            {
                throw new NotFoundItemException($"The person with id: {personaId} does not exist.");
            }
        }
    }
}
