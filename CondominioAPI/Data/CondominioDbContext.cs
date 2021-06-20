using CondominioAPI.Data.Entities;
using CondominioAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data
{
    public class CondominioDbContext : IdentityDbContext<IdentityUserModel>
    {
        public DbSet<PersonaEntity> Personas { get; set; }
        public DbSet<DepartamentoEntity> Departamentos { get; set; }
        public DbSet<AlquilerEntity> Alquileres { get; set; }
        public DbSet<CobroEntity> Cobros { get; set; }
        public DbSet<PublicacionEntity> Publicaciones { get; set; }

        public CondominioDbContext(DbContextOptions<CondominioDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonaEntity>().ToTable("Personas");
            modelBuilder.Entity<PersonaEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PersonaEntity>().HasMany(r => r.Departamentos).WithOne(d => d.Propietario);
            modelBuilder.Entity<PersonaEntity>().HasMany(r => r.Alquileres).WithOne(a => a.Arrendatario);
            modelBuilder.Entity<PersonaEntity>().HasMany(r => r.Publicaciones).WithOne(p => p.Persona);

            modelBuilder.Entity<DepartamentoEntity>().ToTable("Departamentos");
            modelBuilder.Entity<DepartamentoEntity>().Property(d => d.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<DepartamentoEntity>().HasOne(d => d.Propietario).WithMany(r => r.Departamentos);
            modelBuilder.Entity<DepartamentoEntity>().HasOne(d => d.Alquiler).WithOne(d => d.Departamento);
            modelBuilder.Entity<DepartamentoEntity>().HasMany(d => d.Cobros).WithOne(c => c.Departamento);

            modelBuilder.Entity<AlquilerEntity>().ToTable("Alquileres");
            modelBuilder.Entity<AlquilerEntity>().Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<AlquilerEntity>().HasOne(a => a.Departamento).WithOne(d => d.Alquiler);
            modelBuilder.Entity<AlquilerEntity>().HasOne(a => a.Arrendatario).WithMany(r => r.Alquileres);

            modelBuilder.Entity<PublicacionEntity>().ToTable("Publicaciones");
            modelBuilder.Entity<PublicacionEntity>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PublicacionEntity>().HasOne(p => p.Persona).WithMany(r => r.Publicaciones);

            modelBuilder.Entity<CobroEntity>().ToTable("Cobros");
            modelBuilder.Entity<CobroEntity>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CobroEntity>().HasOne(c => c.Departamento).WithMany(d => d.Cobros);
        }
    }
}
