using System;
using ExtracaoService.Data;
using ExtracaoService.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExtracaoService.Database.Contexts
{
    public class ExtractionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Common.Config["Settings:ExtractionContext"]);
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