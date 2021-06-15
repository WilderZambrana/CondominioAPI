using CondominioAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Repository
{
    public class CondominioRepository : ICondominioRepository
    {
        private CondominioDbContext _dbContext;
        public CondominioRepository(CondominioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateAlquiler(AlquilerEntity newAlquiler)
        {
            _dbContext.Alquileres.Add(newAlquiler);
        }

        public void CreateDepartamento(DepartamentoEntity newDepartamento)
        {
            _dbContext.Departamentos.Add(newDepartamento);
        }

        public void CreateResidente(PersonaEntity newResidente)
        {
            _dbContext.Residentes.Add(newResidente);
        }

        public async Task<IEnumerable<AlquilerEntity>> GetAlquileresAsync()
        {
            IQueryable<AlquilerEntity> query = _dbContext.Alquileres;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<DepartamentoEntity>> GetDepartamentosAsync()
        {
            IQueryable<DepartamentoEntity> query = _dbContext.Departamentos;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<PersonaEntity>> GetResidentesAsync()
        {
            IQueryable<PersonaEntity> query = _dbContext.Residentes;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var res = await _dbContext.SaveChangesAsync();
                return res > 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
