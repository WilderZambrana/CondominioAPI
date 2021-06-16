using CondominioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Services
{
    public interface IRolesService
    {
        public Task<IEnumerable<RolModel>> GetRolesAsync();
        public Task<RolModel> GetRolAsync(long rolId);
        public Task<RolModel> CreateRolAsync(RolModel newRol);
        public Task<bool> DeleteRolAsync(long rolId);
        public Task<RolModel> UpdateRolAsync(long rolId, RolModel updatedRol);
    }
}
