using AutoMapper;
using CondominioAPI.Data.Entities;
using CondominioAPI.Data.Repository;
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

        public async Task<IEnumerable<DepartamentoModel>> GetDepartamentosAsync()
        {
            var entityList = await _condominioRepository.GetDepartamentosAsync();
            var modelList = _mapper.Map<IEnumerable<DepartamentoModel>>(entityList);
            return modelList;
        }
    }
}
