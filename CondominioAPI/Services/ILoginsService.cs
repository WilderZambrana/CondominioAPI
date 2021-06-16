using CondominioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Services
{
    public interface ILoginsService
    {
        public Task<IEnumerable<LoginModel>> GetLoginsAsync();
        public Task<LoginModel> GetLoginAsync(long loginId);
        public Task<LoginModel> CreateLoginAsync(LoginModel newLogin);
        public Task<bool> DeleteLoginAsync(long loginId);
        public Task<LoginModel> UpdateLoginAsync(long loginId, LoginModel updatedLogin);
    }
}
