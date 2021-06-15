using AutoMapper;
using CondominioAPI.Data.Entities;
using CondominioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<PersonaModel, PersonaEntity>()
                .ReverseMap();

            this.CreateMap<DepartamentoModel, DepartamentoEntity>()
                .ForMember(ent => ent.Propietario, mod => mod.MapFrom(modSrc => new PersonaEntity() { Id = modSrc.PropietarioId }))
                .ReverseMap()
                .ForMember(mod => mod.PropietarioId, ent => ent.MapFrom(entSrc => entSrc.Propietario.Id));

            this.CreateMap<AlquilerModel, AlquilerEntity>()
                .ForMember(ent => ent.Arrendatario, mod => mod.MapFrom(modSrc => new PersonaEntity() { Id = modSrc.ArrendatarioId }))
                .ForMember(ent => ent.Departamento, mod => mod.MapFrom(modSrc => new DepartamentoEntity() { Id = modSrc.DepartamentoId }))
                .ReverseMap()
                .ForMember(mod => mod.ArrendatarioId, ent => ent.MapFrom(entSrc => entSrc.Arrendatario.Id))
                .ForMember(mod => mod.DepartamentoId, ent => ent.MapFrom(entSrc => entSrc.Departamento.Id));
        }
    }
}
