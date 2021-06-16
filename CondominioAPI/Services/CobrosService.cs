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
    public class CobrosService : ICobrosService
    {
        private ICondominioRepository _condominioRepository;
        private IMapper _mapper;
        public CobrosService(ICondominioRepository condominioRepository, IMapper mapper)
        {
            _condominioRepository = condominioRepository;
            _mapper = mapper;
        }

        public async Task<CobroModel> CreateCobroAsync(CobroModel newCobro)
        {
            var resultEntity = _mapper.Map<CobroEntity>(newCobro);
            _condominioRepository.CreateCobro(resultEntity);
            var result = await _condominioRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<CobroModel>(resultEntity);
            }
            throw new Exception("Database Error");
        }
        public async Task<bool> DeleteCobroAsync(long cobroId)
        {
            await ValidateCobroAsync(cobroId);
            await _condominioRepository.DeleteCobroAsync(cobroId);
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return true;
        }
        public async Task<CobroModel> GetCobroAsync(long cobroId)
        {
            var result = await _condominioRepository.GetCobroAsync(cobroId);

            if (result == null)
            {
                throw new NotFoundItemException($"The cobro with id: {cobroId} does not exist.");
            }
            return _mapper.Map<CobroModel>(result);
        }
        public async Task<IEnumerable<CobroModel>> GetCobrosAsync()
        {
            var entityList = await _condominioRepository.GetCobrosAsync();
            var modelList = _mapper.Map<IEnumerable<CobroModel>>(entityList);
            return modelList;
        }
        public async Task<CobroModel> UpdateCobroAsync(long cobroId, CobroModel updatedCobro)
        {
            await GetCobroAsync(cobroId);
            updatedCobro.Id = cobroId;
            await _condominioRepository.UpdateCobroAsync(cobroId, _mapper.Map<CobroEntity>(updatedCobro));
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return _mapper.Map<CobroModel>(updatedCobro);
        }

        private async Task ValidateCobroAsync(long cobroId)
        {
            await GetCobroAsync(cobroId);
        }
    }
}
