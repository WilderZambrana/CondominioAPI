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
            _dbContext.Entry(newAlquiler.Departamento).State = EntityState.Unchanged;
            _dbContext.Entry(newAlquiler.Arrendatario).State = EntityState.Unchanged;
            _dbContext.Alquileres.Add(newAlquiler);
        }
        public void CreateCobro(CobroEntity newCobro)
        {
            _dbContext.Entry(newCobro.Departamento).State = EntityState.Unchanged;
            _dbContext.Cobros.Add(newCobro);
        }
        public void CreateDepartamento(DepartamentoEntity newDepartamento)
        {
            _dbContext.Entry(newDepartamento.Propietario).State = EntityState.Unchanged;
            _dbContext.Departamentos.Add(newDepartamento);
        }
        public void CreateLogin(LoginEntity newLogin)
        {
            _dbContext.Entry(newLogin.Persona).State = EntityState.Unchanged;
            _dbContext.Entry(newLogin.Rol).State = EntityState.Unchanged;
            _dbContext.Logins.Add(newLogin);
        }
        public void CreatePersona(PersonaEntity newPersona)
        {
            _dbContext.Personas.Add(newPersona);
        }
        public void CreatePublicacion(PublicacionEntity newPublicacion)
        {
            _dbContext.Entry(newPublicacion.Persona).State = EntityState.Unchanged;
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
            query = query.Include(a => a.Departamento);
            query = query.Include(a => a.Arrendatario);
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
            query = query.Include(d => d.Propietario);
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
            query = query.Include(l => l.Persona);
            query = query.Include(l => l.Rol);
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
            query = query.Include(p => p.Persona);
            return await query.FirstOrDefaultAsync(p => p.Id == publicacionId);
        }
        public async Task<IEnumerable<PublicacionEntity>> GetPublicacionesAsync()
        {
            IQueryable<PublicacionEntity> query = _dbContext.Publicaciones;
            query = query.Include(p => p.Persona);
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }
        public async Task<RolEntity> GetRolAsync(long rolId)
        {
            IQueryable<RolEntity> query = _dbContext.Roles;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(t => t.Id == rolId);
        }
        public async Task<IEnumerable<RolEntity>> GetRolesAsync()
        {
            IQueryable<RolEntity> query = _dbContext.Roles;
            query = query.AsNoTracking();
            return await query.ToListAsync();
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
        public async Task UpdateAlquilerAsync(long alquilerId, AlquilerEntity updatedAlquiler)
        {
            _dbContext.Entry(updatedAlquiler.Arrendatario).State = EntityState.Unchanged;
            _dbContext.Entry(updatedAlquiler.Departamento).State = EntityState.Unchanged;
            var toUpdate = await _dbContext.Alquileres.FirstOrDefaultAsync(t => t.Id == alquilerId);

            toUpdate.FechaInicio = updatedAlquiler.FechaInicio ?? toUpdate.FechaInicio;
            toUpdate.FechaFin = updatedAlquiler.FechaFin ?? toUpdate.FechaFin;
            toUpdate.Departamento = updatedAlquiler.Departamento ?? toUpdate.Departamento;
            toUpdate.Arrendatario = updatedAlquiler.Arrendatario ?? toUpdate.Arrendatario;
        }
        public async Task UpdateCobroAsync(long cobroId, CobroEntity updatedCobro)
        {
            _dbContext.Entry(updatedCobro.Departamento).State = EntityState.Unchanged;
            var toUpdate = await _dbContext.Cobros.FirstOrDefaultAsync(t => t.Id == cobroId);

            toUpdate.Descripcion = updatedCobro.Descripcion ?? toUpdate.Descripcion;
            toUpdate.Valor = updatedCobro.Valor ?? toUpdate.Valor;
            toUpdate.MultaPorcentaje = updatedCobro.MultaPorcentaje ?? toUpdate.MultaPorcentaje;
            toUpdate.FechaRegistro = updatedCobro.FechaRegistro ?? toUpdate.FechaRegistro;
            toUpdate.FechaVencimiento = updatedCobro.FechaVencimiento ?? toUpdate.FechaVencimiento;
            toUpdate.Departamento = updatedCobro.Departamento ?? toUpdate.Departamento;
        }
        public async Task UpdateDepartamentoAsync(long departamentoId, DepartamentoEntity updatedDepartamento)
        {
            _dbContext.Entry(updatedDepartamento.Propietario).State = EntityState.Unchanged;
            var toUpdate = await _dbContext.Departamentos.FirstOrDefaultAsync(t => t.Id == departamentoId);

            toUpdate.Bloque = updatedDepartamento.Bloque ?? toUpdate.Bloque;
            toUpdate.NumeroDepartamento = updatedDepartamento.NumeroDepartamento ?? toUpdate.NumeroDepartamento;
            toUpdate.NumeroDormitorios = updatedDepartamento.NumeroDormitorios ?? toUpdate.NumeroDormitorios;
            toUpdate.FechaRegistro = updatedDepartamento.FechaRegistro ?? toUpdate.FechaRegistro;
            toUpdate.FechaActualizacion = updatedDepartamento.FechaActualizacion ?? toUpdate.FechaActualizacion;
            toUpdate.Propietario = updatedDepartamento.Propietario ?? toUpdate.Propietario; 
        }
        public async Task UpdateLoginAsync(long loginId, LoginEntity updatedLogin)
        {
            _dbContext.Entry(updatedLogin.Persona).State = EntityState.Unchanged;
            _dbContext.Entry(updatedLogin.Rol).State = EntityState.Unchanged;
            var toUpdate = await _dbContext.Logins.FirstOrDefaultAsync(t => t.Id == loginId);

            toUpdate.Usuario = updatedLogin.Usuario ?? toUpdate.Usuario;
            toUpdate.Password = updatedLogin.Password ?? toUpdate.Password;
            toUpdate.Persona = updatedLogin.Persona ?? toUpdate.Persona;
            toUpdate.Rol = updatedLogin.Rol ?? toUpdate.Rol;
        }
        public async Task UpdatePersonaAsync(long personaId, PersonaEntity updatedPersona)
        {
            var toUpdate = await _dbContext.Personas.FirstOrDefaultAsync(t => t.Id == personaId);

            toUpdate.Nombres = updatedPersona.Nombres ?? toUpdate.Nombres;
            toUpdate.Apellidos = updatedPersona.Apellidos ?? toUpdate.Apellidos;
            toUpdate.CI = updatedPersona.CI ?? toUpdate.CI;
            toUpdate.Telefono = updatedPersona.Telefono ?? toUpdate.Telefono;
            toUpdate.Email = updatedPersona.Email ?? toUpdate.Email;
            toUpdate.Celular = updatedPersona.Celular ?? toUpdate.Celular;
            toUpdate.FechaRegistro = updatedPersona.FechaRegistro ?? toUpdate.FechaRegistro;
            toUpdate.FechaActualizacion = updatedPersona.FechaActualizacion ?? toUpdate.FechaActualizacion;
        }
        public async Task UpdatePublicacionAsync(long publicacionId, PublicacionEntity updatedPublicacion)
        {
            _dbContext.Entry(updatedPublicacion.Persona).State = EntityState.Unchanged;
            var toUpdate = await _dbContext.Publicaciones.FirstOrDefaultAsync(t => t.Id == publicacionId);

            toUpdate.Persona = updatedPublicacion.Persona ?? toUpdate.Persona;
            toUpdate.Asunto = updatedPublicacion.Asunto ?? toUpdate.Asunto;
            toUpdate.Detalle = updatedPublicacion.Detalle ?? toUpdate.Detalle;
            toUpdate.FechaPublicacion = updatedPublicacion.FechaPublicacion ?? toUpdate.FechaPublicacion;
        }
        public async Task UpdateRolAsync(long rolId, RolEntity updatedRol)
        {
            var toUpdate = await _dbContext.Roles.FirstOrDefaultAsync(t => t.Id == rolId);

            toUpdate.NombreRol = updatedRol.NombreRol ?? toUpdate.NombreRol;
        }
    }
}
