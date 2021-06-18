using CondominioAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Repository
{
    public interface ICondominioRepository
    {
        //RESIDENTES
        public Task<IEnumerable<PersonaEntity>> GetPersonasAsync();
        public Task<PersonaEntity> GetPersonaAsync(long personaId);
        public void CreatePersona(PersonaEntity newPersona);
        public Task DeletePersonaAsync(long personaId);
        public Task UpdatePersonaAsync(long personaId, PersonaEntity updatedPersona);
        

        //DEPARTAMENTOS
        public Task<IEnumerable<DepartamentoEntity>> GetDepartamentosAsync();
        public void CreateDepartamento(DepartamentoEntity newDepartamento);
        public Task<DepartamentoEntity> GetDepartamentoAsync(long departamentoId);
        public Task DeleteDepartamentoAsync(long departamentoId);
        public Task UpdateDepartamentoAsync(long departamentoId, DepartamentoEntity updatedDepartamento);

        //ALQUILERES
        public Task<IEnumerable<AlquilerEntity>> GetAlquileresAsync();
        public void CreateAlquiler(AlquilerEntity newAlquiler);
        public Task<AlquilerEntity> GetAlquilerAsync(long alquilerId);
        public Task DeleteAlquilerAsync(long alquilerId);
        public Task UpdateAlquilerAsync(long alquilerId, AlquilerEntity updatedAlquiler);

        //COBROS
        public Task<IEnumerable<CobroEntity>> GetCobrosAsync();
        public void CreateCobro(CobroEntity newCobro);
        public Task<CobroEntity> GetCobroAsync(long cobroId);
        public Task DeleteCobroAsync(long cobroId);
        public Task UpdateCobroAsync(long cobroId, CobroEntity updatedCobro);

        //PUBLICACIONES
        public Task<IEnumerable<PublicacionEntity>> GetPublicacionesAsync();
        public void CreatePublicacion(PublicacionEntity newPublicacion);
        public Task<PublicacionEntity> GetPublicacionAsync(long publicacionId);
        public Task DeletePublicacionAsync(long publicacionId);
        public Task UpdatePublicacionAsync(long publicacionId, PublicacionEntity updatedPublicacion);

        //ROLES
        public Task<IEnumerable<RolEntity>> GetRolesAsync();
        public void CreateRol(RolEntity newRol);
        public Task<RolEntity> GetRolAsync(long rolId);
        public Task DeleteRolAsync(long rolId);
        public Task UpdateRolAsync(long rolId, RolEntity updatedRol);

        //LOGINS
        public Task<IEnumerable<LoginEntity>> GetLoginsAsync();
        public void CreateLogin(LoginEntity newLogin);
        public Task<LoginEntity> GetLoginAsync(long loginId);
        public Task DeleteLoginAsync(long loginId);
        public Task UpdateLoginAsync(long loginId, LoginEntity updatedLogin);

        //GUARDAR CAMBIOS
        Task<bool> SaveChangesAsync();
    }
}
