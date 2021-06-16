using CondominioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Services
{
    public interface IAlquileresService
    {
        public Task<IEnumerable<AlquilerModel>> GetAlquileresAsync();
        public Task<AlquilerModel> GetAlquilerAsync(long alquilerId);
        public Task<AlquilerModel> CreateAlquilerAsync(AlquilerModel newAlquiler);
        public Task<bool> DeleteAlquilerAsync(long alquilerId);
        public Task<AlquilerModel> UpdateAlquilerAsync(long alquilerId, AlquilerModel updatedAlquiler);
    }
}
