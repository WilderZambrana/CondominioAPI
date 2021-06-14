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
        public DbSet<ResidenteEntity> Residentes { get; set; }
        public DbSet<DepartamentoEntity> Departamentos { get; set; }

        public CondominioDbContext(DbContextOptions<CondominioDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ResidenteEntity>().ToTable("Residentes");
            modelBuilder.Entity<ResidenteEntity>().Property(r => r.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<DepartamentoEntity>().ToTable("Departamentos");
            modelBuilder.Entity<DepartamentoEntity>().Property(d => d.Id).ValueGeneratedOnAdd();
        }
    }
}
