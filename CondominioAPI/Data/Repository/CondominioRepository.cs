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

        public void CreateCobro(CobroEntity newCobro)
        {
            throw new NotImplementedException();
        }

        public void CreateDepartamento(DepartamentoEntity newDepartamento)
        {
            _dbContext.Departamentos.Add(newDepartamento);
        }

        public void CreateLogin(LoginEntity newLogin)
        {
            throw new NotImplementedException();
        }

        public void CreatePersona(PersonaEntity newResidente)
        {
            _dbContext.Residentes.Add(newResidente);
        }

        public void CreatePublicacion(PublicacionEntity newPublicacion)
        {
            throw new NotImplementedException();
        }

        public void CreateRol(RolEntity newRol)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAlquilerAsync(long alquilerId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCobroAsync(long cobroId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDepartamentoAsync(long departamentoId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLoginAsync(long loginId)
        {
            throw new NotImplementedException();
        }

        public Task DeletePersonaAsync(long personaId)
        {
            throw new NotImplementedException();
        }

        public Task DeletePublicacionAsync(long publicacionId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRolAsync(long rolId)
        {
            throw new NotImplementedException();
        }

        public Task<AlquilerEntity> GetAlquilerAsync(long alquilerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AlquilerEntity>> GetAlquileresAsync()
        {
            IQueryable<AlquilerEntity> query = _dbContext.Alquileres;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public Task<CobroEntity> GetCobroAsync(long cobroId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CobroEntity>> GetCobrosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DepartamentoEntity> GetDepartamentoAsync(long departamentoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DepartamentoEntity>> GetDepartamentosAsync()
        {
            IQueryable<DepartamentoEntity> query = _dbContext.Departamentos;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public Task<LoginEntity> GetLoginAsync(long loginId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoginEntity>> GetLoginsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonaEntity> GetPersonaAsync(long personaId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonaEntity>> GetPersonasAsync()
        {
            IQueryable<PersonaEntity> query = _dbContext.Residentes;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public Task<PublicacionEntity> GetPublicacionAsync(long publicacionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PublicacionEntity>> GetPublicacionesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RolEntity> GetRolAsync(long rolId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RolEntity>> GetRolesAsync()
        {
            throw new NotImplementedException();
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

        public Task UpdateAlquilerAsync(long alquilerId, AlquilerEntity updatedAlquiler)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCobroAsync(long cobroId, CobroEntity updatedCobro)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDepartamentoAsync(long departamentoId, DepartamentoEntity updatedDepartamento)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLoginAsync(long loginId, LoginEntity updatedLogin)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonaAsync(long personaId, PersonaEntity updatedPersona)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePublicacionAsync(long publicacionId, PublicacionEntity updatedPublicacion)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRolAsync(long rolId, RolEntity updatedRol)
        {
            throw new NotImplementedException();
        }
    }
}
