using System;
using ExtracaoService.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ExtracaoService.Database.Contexts
{
    public class ExtractionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Machine));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Noticia>().Property(n => n.Id).ValueGeneratedOnAdd();
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
    }
}