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
            _condominioRepository.CreateResidente(resultEntity);
            var result = await _condominioRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<PersonaModel>(resultEntity);
            }
            throw new Exception("Database Error");
        }

        public async Task<IEnumerable<PersonaModel>> GetPersonasAsync()
        {
            var entityList = await _condominioRepository.GetResidentesAsync();
            var modelList = _mapper.Map<IEnumerable<PersonaModel>>(entityList);
            return modelList;
        }
    }
}
