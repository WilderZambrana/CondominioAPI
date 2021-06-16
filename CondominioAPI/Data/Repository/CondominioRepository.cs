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

        //CREATES
        public void CreateAlquiler(AlquilerEntity newAlquiler)
        {
            _dbContext.Alquileres.Add(newAlquiler);
        }
        public void CreateCobro(CobroEntity newCobro)
        {
            _dbContext.Cobros.Add(newCobro);
        }
        public void CreateDepartamento(DepartamentoEntity newDepartamento)
        {
            _dbContext.Departamentos.Add(newDepartamento);
        }
        public void CreateLogin(LoginEntity newLogin)
        {
            _dbContext.Logins.Add(newLogin);
        }
        public void CreatePersona(PersonaEntity newPersona)
        {
            _dbContext.Personas.Add(newPersona);
        }
        public void CreatePublicacion(PublicacionEntity newPublicacion)
        {
            _dbContext.Publicaciones.Add(newPublicacion);
        }
        public void CreateRol(RolEntity newRol)
        {
            _dbContext.Roles.Add(newRol);
        }

        //DELETES
        public async Task DeleteAlquilerAsync(long alquilerId)
        {
            var toDelete = await _dbContext.Alquileres.FirstAsync(t => t.Id == alquilerId);
            _dbContext.Alquileres.Remove(toDelete);
        }
        public async Task DeleteCobroAsync(long cobroId)
        {
            var toDelete = await _dbContext.Cobros.FirstAsync(t => t.Id == cobroId);
            _dbContext.Cobros.Remove(toDelete);
        }
        public async Task DeleteDepartamentoAsync(long departamentoId)
        {
            var toDelete = await _dbContext.Departamentos.FirstAsync(t => t.Id == departamentoId);
            _dbContext.Departamentos.Remove(toDelete);
        }
        public async Task DeleteLoginAsync(long loginId)
        {
            var toDelete = await _dbContext.Logins.FirstAsync(t => t.Id == loginId);
            _dbContext.Logins.Remove(toDelete);
        }
        public async Task DeletePersonaAsync(long personaId)
        {
            var toDelete = await _dbContext.Personas.FirstAsync(t => t.Id == personaId);
            _dbContext.Personas.Remove(toDelete);
        }
        public async Task DeletePublicacionAsync(long publicacionId)
        {
            var toDelete = await _dbContext.Publicaciones.FirstAsync(t => t.Id == publicacionId);
            _dbContext.Publicaciones.Remove(toDelete);
        }
        public async Task DeleteRolAsync(long rolId)
        {
            var toDelete = await _dbContext.Roles.FirstAsync(t => t.Id == rolId);
            _dbContext.Roles.Remove(toDelete);
        }

        //GETS
        public async Task<AlquilerEntity> GetAlquilerAsync(long alquilerId)
        {
            IQueryable<AlquilerEntity> query = _dbContext.Alquileres;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(t => t.Id == alquilerId);
        }
        public async Task<IEnumerable<AlquilerEntity>> GetAlquileresAsync()
        {
            IQueryable<AlquilerEntity> query = _dbContext.Alquileres;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }
        public async Task<CobroEntity> GetCobroAsync(long cobroId)
        {
            IQueryable<CobroEntity> query = _dbContext.Cobros;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(t => t.Id == cobroId);
        }
        public async Task<IEnumerable<CobroEntity>> GetCobrosAsync()
        {
            IQueryable<CobroEntity> query = _dbContext.Cobros;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }
        public async Task<DepartamentoEntity> GetDepartamentoAsync(long departamentoId)
        {
            IQueryable<DepartamentoEntity> query = _dbContext.Departamentos;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(t => t.Id == departamentoId);
        }
        public async Task<IEnumerable<DepartamentoEntity>> GetDepartamentosAsync()
        {
            IQueryable<DepartamentoEntity> query = _dbContext.Departamentos;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }
        public async Task<LoginEntity> GetLoginAsync(long loginId)
        {
            IQueryable<LoginEntity> query = _dbContext.Logins;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(t => t.Id == loginId);
        }
        public async Task<IEnumerable<LoginEntity>> GetLoginsAsync()
        {
            IQueryable<LoginEntity> query = _dbContext.Logins;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }
        public async Task<PersonaEntity> GetPersonaAsync(long personaId)
        {
            IQueryable<PersonaEntity> query = _dbContext.Personas;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(t => t.Id == personaId);
        }
        public async Task<IEnumerable<PersonaEntity>> GetPersonasAsync()
        {
            IQueryable<PersonaEntity> query = _dbContext.Personas;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }
        public async Task<PublicacionEntity> GetPublicacionAsync(long publicacionId)
        {
            IQueryable<PublicacionEntity> query = _dbContext.Publicaciones;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(t => t.Id == publicacionId);
        }
        public async Task<IEnumerable<PublicacionEntity>> GetPublicacionesAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<RolEntity> GetRolAsync(long rolId)
        {
            IQueryable<RolEntity> query = _dbContext.Roles;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(t => t.Id == rolId);
        }
        public async Task<IEnumerable<RolEntity>> GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        //SAVE CHANGES
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

        //UPDATES
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
