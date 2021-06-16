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

        public async Task<PublicacionModel> CreatePublicacionAsync(PublicacionModel newPublicacion)
        {
            var resultEntity = _mapper.Map<PublicacionEntity>(newPublicacion);
            _condominioRepository.CreatePublicacion(resultEntity);
            var result = await _condominioRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<PublicacionModel>(resultEntity);
            }
            throw new Exception("Database Error");
        }
        public async Task<bool> DeletePublicacionAsync(long publicacionId)
        {
            await ValidatePublicacionAsync(publicacionId);
            await _condominioRepository.DeletePublicacionAsync(publicacionId);
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return true;
        }
        public async Task<PublicacionModel> GetPublicacionAsync(long publicacionId)
        {
            var result = await _condominioRepository.GetPublicacionAsync(publicacionId);

            if (result == null)
            {
                throw new NotFoundItemException($"The publicacion with id: {publicacionId} does not exist.");
            }
            return _mapper.Map<PublicacionModel>(result);
        }
        public async Task<IEnumerable<PublicacionModel>> GetPublicacionesAsync()
        {
            var entityList = await _condominioRepository.GetPublicacionesAsync();
            var modelList = _mapper.Map<IEnumerable<PublicacionModel>>(entityList);
            return modelList;
        }
        public async Task<PublicacionModel> UpdatePublicacionAsync(long publicacionId, PublicacionModel updatedPublicacion)
        {
            await GetPublicacionAsync(publicacionId);
            updatedPublicacion.Id = publicacionId;
            await _condominioRepository.UpdatePublicacionAsync(publicacionId, _mapper.Map<PublicacionEntity>(updatedPublicacion));
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return _mapper.Map<PublicacionModel>(updatedPublicacion);
        }

        private async Task ValidatePublicacionAsync(long publicacionId)
        {
            await GetPublicacionAsync(publicacionId);
        }
    }
}
