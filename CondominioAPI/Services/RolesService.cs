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
    public class RolesService : IRolesService
    {
        private ICondominioRepository _condominioRepository;
        private IMapper _mapper;
        public RolesService(ICondominioRepository condominioRepository, IMapper mapper)
        {
            _condominioRepository = condominioRepository;
            _mapper = mapper;
        }

        public async Task<RolModel> CreateRolAsync(RolModel newRol)
        {
            var resultEntity = _mapper.Map<RolEntity>(newRol);
            _condominioRepository.CreateRol(resultEntity);
            var result = await _condominioRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<RolModel>(resultEntity);
            }
            throw new Exception("Database Error");
        }
        public async Task<bool> DeleteRolAsync(long rolId)
        {
            await ValidateRolAsync(rolId);
            await _condominioRepository.DeleteRolAsync(rolId);
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return true;
        }
        public async Task<RolModel> GetRolAsync(long rolId)
        {
            var result = await _condominioRepository.GetRolAsync(rolId);

            if (result == null)
            {
                throw new NotFoundItemException($"The rol with id: {rolId} does not exist.");
            }
            return _mapper.Map<RolModel>(result);
        }
        public async Task<IEnumerable<RolModel>> GetRolesAsync()
        {
            var entityList = await _condominioRepository.GetRolesAsync();
            var modelList = _mapper.Map<IEnumerable<RolModel>>(entityList);
            return modelList;
        }
        public async Task<RolModel> UpdateRolAsync(long rolId, RolModel updatedRol)
        {
            await GetRolAsync(rolId);
            updatedRol.Id = rolId;
            await _condominioRepository.UpdateRolAsync(rolId, _mapper.Map<RolEntity>(updatedRol));
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return _mapper.Map<RolModel>(updatedRol);
        }

        private async Task ValidateRolAsync(long rolId)
        {
            await GetRolAsync(rolId);
        }
    }
}
