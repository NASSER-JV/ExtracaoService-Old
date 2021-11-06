using System.ComponentModel.DataAnnotations.Schema;

namespace ExtracaoService.Database.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        [Column(TypeName = "text")]
        public string Corpo { get; set; }
        public int EmpresaId { get; set; }
    }
}