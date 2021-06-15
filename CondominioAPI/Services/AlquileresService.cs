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

        public async Task<IEnumerable<AlquilerModel>> GetAlquileresAsync()
        {
            var entityList = await _condominioRepository.GetAlquileresAsync();
            var modelList = _mapper.Map<IEnumerable<AlquilerModel>>(entityList);
            return modelList;
        }
    }
}
