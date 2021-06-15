using CondominioAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data
{
    public class CondominioDbContext : DbContext
    {
        public DbSet<PersonaEntity> Residentes { get; set; }
        public DbSet<DepartamentoEntity> Departamentos { get; set; }
        public DbSet<AlquilerEntity> Alquileres { get; set; }

        public CondominioDbContext(DbContextOptions<CondominioDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonaEntity>().ToTable("Residentes");
            modelBuilder.Entity<PersonaEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PersonaEntity>().HasMany(r => r.Departamentos).WithOne(d => d.Propietario);
            modelBuilder.Entity<PersonaEntity>().HasMany(r => r.Alquileres).WithOne(a => a.Arrendatario);

            modelBuilder.Entity<DepartamentoEntity>().ToTable("Departamentos");
            modelBuilder.Entity<DepartamentoEntity>().Property(d => d.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<DepartamentoEntity>().HasOne(d => d.Propietario).WithMany(r => r.Departamentos);
            modelBuilder.Entity<DepartamentoEntity>().HasOne(d => d.Alquiler).WithOne(d => d.Departamento);

            modelBuilder.Entity<AlquilerEntity>().ToTable("Alquileres");
            modelBuilder.Entity<AlquilerEntity>().Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<AlquilerEntity>().HasOne(a => a.Departamento).WithOne(d => d.Alquiler);
            modelBuilder.Entity<AlquilerEntity>().HasOne(a => a.Arrendatario).WithMany(r => r.Alquileres);
        }
    }
}
