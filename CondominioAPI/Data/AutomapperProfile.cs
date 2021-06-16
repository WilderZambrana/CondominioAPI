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
            this.CreateMap<AlquilerModel, AlquilerEntity>()
                .ForMember(ent => ent.Arrendatario, mod => mod.MapFrom(modSrc => new PersonaEntity() { Id = modSrc.ArrendatarioId }))
                .ForMember(ent => ent.Departamento, mod => mod.MapFrom(modSrc => new DepartamentoEntity() { Id = modSrc.DepartamentoId }))
                .ReverseMap()
                .ForMember(mod => mod.ArrendatarioId, ent => ent.MapFrom(entSrc => entSrc.Arrendatario.Id))
                .ForMember(mod => mod.DepartamentoId, ent => ent.MapFrom(entSrc => entSrc.Departamento.Id));

            this.CreateMap<CobroModel, CobroEntity>()
                .ForMember(ent => ent.Departamento, mod => mod.MapFrom(modSrc => new DepartamentoEntity() { Id = modSrc.DepartamentoId }))
                .ReverseMap()
                .ForMember(mod => mod.DepartamentoId, ent => ent.MapFrom(entSrc => entSrc.Departamento.Id));

            this.CreateMap<DepartamentoModel, DepartamentoEntity>()
                .ForMember(ent => ent.Propietario, mod => mod.MapFrom(modSrc => new PersonaEntity() { Id = modSrc.PropietarioId }))
                .ReverseMap()
                .ForMember(mod => mod.PropietarioId, ent => ent.MapFrom(entSrc => entSrc.Propietario.Id));

            this.CreateMap<LoginModel, LoginEntity>()
                .ForMember(ent => ent.Persona, mod => mod.MapFrom(modSrc => new PersonaEntity() { Id = modSrc.PersonaId }))
                .ForMember(ent => ent.Rol, mod => mod.MapFrom(modSrc => new RolEntity() { Id = modSrc.RolId }))
                .ReverseMap()
                .ForMember(mod => mod.PersonaId, ent => ent.MapFrom(entSrc => entSrc.Persona.Id))
                .ForMember(mod => mod.RolId, ent => ent.MapFrom(entSrc => entSrc.Rol.Id));

            this.CreateMap<PersonaModel, PersonaEntity>()
                .ReverseMap();

            this.CreateMap<PublicacionModel, PublicacionEntity>()
                .ForMember(ent => ent.Persona, mod => mod.MapFrom(modSrc => new PersonaEntity() { Id = modSrc.PersonaId }))
                .ReverseMap()
                .ForMember(mod => mod.PersonaId, ent => ent.MapFrom(entSrc => entSrc.Persona.Id));

            this.CreateMap<RolModel, RolEntity>()
                .ReverseMap();
        }
    }
}
