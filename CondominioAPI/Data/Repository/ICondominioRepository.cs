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
        public Task<IEnumerable<PersonaEntity>> GetResidentesAsync();
        public void CreateResidente(PersonaEntity newResidente);


        //DEPARTAMENTOS
        public Task<IEnumerable<DepartamentoEntity>> GetDepartamentosAsync();
        public void CreateDepartamento(DepartamentoEntity newDepartamento);


        //ALQUILERES
        public Task<IEnumerable<AlquilerEntity>> GetAlquileresAsync();
        public void CreateAlquiler(AlquilerEntity newAlquiler);


        //GUARDAR CAMBIOS
        Task<bool> SaveChangesAsync();
    }
}
