using System.ComponentModel.DataAnnotations;

namespace Ejemplo7_EF.Models
{
    public class Obra
    {
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Titulo { get; set; }
        [StringLength(50)]
        public string Estilo { get; set; }
        [StringLength(250)]
        public string UrlImagen { get; set; }
        public Guid ArtistaId { get; set; }
        public Artista? Artista { get; set; }
        public List<Exposicion>? ExposicionesObras { get; set; }
    }
}
