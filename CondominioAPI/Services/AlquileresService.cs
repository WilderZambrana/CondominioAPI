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
    public class AlquileresService : IAlquileresService
    {
        private ICondominioRepository _condominioRepository;
        private IMapper _mapper;
        public AlquileresService(ICondominioRepository condominioRepository, IMapper mapper)
        {
            _condominioRepository = condominioRepository;
            _mapper = mapper;
        }

        public async Task<AlquilerModel> CreateAlquilerAsync(AlquilerModel newAlquiler)
        {
            var resultEntity = _mapper.Map<AlquilerEntity>(newAlquiler);
            _condominioRepository.CreateAlquiler(resultEntity);
            var result = await _condominioRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<AlquilerModel>(resultEntity);
            }
            throw new Exception("Database Error");
        }
        public async Task<bool> DeleteAlquilerAsync(long alquilerId)
        {
            await ValidateAlquilerAsync(alquilerId);
            await _condominioRepository.DeleteAlquilerAsync(alquilerId);
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return true;
        }
        public async Task<AlquilerModel> GetAlquilerAsync(long alquilerId)
        {
            var result = await _condominioRepository.GetAlquilerAsync(alquilerId);

            if (result == null)
            {
                throw new NotFoundItemException($"The alquiler with id: {alquilerId} does not exist.");
            }
            return _mapper.Map<AlquilerModel>(result);
        }
        public async Task<IEnumerable<AlquilerModel>> GetAlquileresAsync()
        {
            var entityList = await _condominioRepository.GetAlquileresAsync();
            var modelList = _mapper.Map<IEnumerable<AlquilerModel>>(entityList);
            return modelList;
        }
        public async Task<AlquilerModel> UpdateAlquilerAsync(long alquilerId, AlquilerModel updatedAlquiler)
        {
            await GetAlquilerAsync(alquilerId);
            updatedAlquiler.Id = alquilerId;
            await _condominioRepository.UpdateAlquilerAsync(alquilerId, _mapper.Map<AlquilerEntity>(updatedAlquiler));
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return _mapper.Map<AlquilerModel>(updatedAlquiler);
        }

        private async Task ValidateAlquilerAsync(long alquilerId)
        {
            await GetAlquilerAsync(alquilerId);
        }
    }
}
