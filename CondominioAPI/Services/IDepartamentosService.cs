using CondominioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Services
{
    public interface IDepartamentosService
    {
        public Task<IEnumerable<DepartamentoModel>> GetDepartamentosAsync();
        public Task<DepartamentoModel> CreateDepartamentoAsync(DepartamentoModel newDepartamento);
        public Task<DepartamentoModel> GetDepartamentoAsync(long departamentoId);
        public Task<bool> DeleteDepartamentoAsync(long departamentoId);
        public Task<DepartamentoModel> UpdateDepartamentoAsync(long departamentoId, DepartamentoModel updatedDepartamento);
    }
}
