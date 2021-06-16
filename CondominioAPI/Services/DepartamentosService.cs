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
    public class DepartamentosService : IDepartamentosService
    {
        private ICondominioRepository _condominioRepository;
        private IMapper _mapper;
        public DepartamentosService(ICondominioRepository condominioRepository, IMapper mapper)
        {
            _condominioRepository = condominioRepository;
            _mapper = mapper;
        }

        public async Task<DepartamentoModel> CreateDepartamentoAsync(DepartamentoModel newDepartamento)
        {
            var resultEntity = _mapper.Map<DepartamentoEntity>(newDepartamento);
            _condominioRepository.CreateDepartamento(resultEntity);
            var result = await _condominioRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<DepartamentoModel>(resultEntity);
            }
            throw new Exception("Database Error");
        }
        public async Task<bool> DeleteDepartamentoAsync(long departamentoId)
        {
            await ValidateDepartamentoAsync(departamentoId);
            await _condominioRepository.DeleteDepartamentoAsync(departamentoId);
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return true;
        }
        public async Task<DepartamentoModel> GetDepartamentoAsync(long departamentoId)
        {
            var result = await _condominioRepository.GetDepartamentoAsync(departamentoId);

            if (result == null)
            {
                throw new NotFoundItemException($"The department with id: {departamentoId} does not exist.");
            }
            return _mapper.Map<DepartamentoModel>(result);
        }
        public async Task<IEnumerable<DepartamentoModel>> GetDepartamentosAsync()
        {
            var entityList = await _condominioRepository.GetDepartamentosAsync();
            var modelList = _mapper.Map<IEnumerable<DepartamentoModel>>(entityList);
            return modelList;
        }
        public async Task<DepartamentoModel> UpdateDepartamentoAsync(long departamentoId, DepartamentoModel updatedDepartamento)
        {
            await GetDepartamentoAsync(departamentoId);
            updatedDepartamento.Id = departamentoId;
            await _condominioRepository.UpdateDepartamentoAsync(departamentoId, _mapper.Map<DepartamentoEntity>(updatedDepartamento));
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return _mapper.Map<DepartamentoModel>(updatedDepartamento);
        }

        private async Task ValidateDepartamentoAsync(long departamentoId)
        {
            await GetDepartamentoAsync(departamentoId);
        }
    }
}
