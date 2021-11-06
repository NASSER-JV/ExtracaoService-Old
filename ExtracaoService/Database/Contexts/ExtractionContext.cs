using ExtracaoService.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ExtracaoService.Database.Contexts
{
    public class ExtractionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(@"Host=localhost;user id=postgres;password=nf231;database=TesteBanco;");
        
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
    }
}