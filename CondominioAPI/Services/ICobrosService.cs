using CondominioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Services
{
    public interface ICobrosService
    {
        public Task<IEnumerable<CobroModel>> GetCobrosAsync();
        public Task<CobroModel> GetCobroAsync(long cobroId);
        public Task<CobroModel> CreateCobroAsync(CobroModel newCobro);
        public Task<bool> DeleteCobroAsync(long cobroId);
        public Task<CobroModel> UpdateCobroAsync(long cobroId, CobroModel updatedCobro);
    }
}
