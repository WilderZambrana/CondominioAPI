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
    public class LoginsService : ILoginsService
    {
        private ICondominioRepository _condominioRepository;
        private IMapper _mapper;
        public LoginsService(ICondominioRepository condominioRepository, IMapper mapper)
        {
            _condominioRepository = condominioRepository;
            _mapper = mapper;
        }

        public async Task<LoginModel> CreateLoginAsync(LoginModel newLogin)
        {
            var resultEntity = _mapper.Map<LoginEntity>(newLogin);
            _condominioRepository.CreateLogin(resultEntity);
            var result = await _condominioRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<LoginModel>(resultEntity);
            }
            throw new Exception("Database Error");
        }
        public async Task<bool> DeleteLoginAsync(long loginId)
        {
            await ValidateLoginAsync(loginId);
            await _condominioRepository.DeleteLoginAsync(loginId);
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return true;
        }
        public async Task<LoginModel> GetLoginAsync(long loginId)
        {
            var result = await _condominioRepository.GetLoginAsync(loginId);

            if (result == null)
            {
                throw new NotFoundItemException($"The login with id: {loginId} does not exist.");
            }
            return _mapper.Map<LoginModel>(result);
        }
        public async Task<IEnumerable<LoginModel>> GetLoginsAsync()
        {
            var entityList = await _condominioRepository.GetLoginsAsync();
            var modelList = _mapper.Map<IEnumerable<LoginModel>>(entityList);
            return modelList;
        }
        public async Task<LoginModel> UpdateLoginAsync(long loginId, LoginModel updatedLogin)
        {
            await GetLoginAsync(loginId);
            updatedLogin.Id = loginId;
            await _condominioRepository.UpdateLoginAsync(loginId, _mapper.Map<LoginEntity>(updatedLogin));
            var result = await _condominioRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return _mapper.Map<LoginModel>(updatedLogin);
        }

        private async Task ValidateLoginAsync(long loginId)
        {
            await GetLoginAsync(loginId);
        }
    }
}
