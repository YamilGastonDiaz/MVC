using System.ComponentModel.DataAnnotations;

namespace Ejemplo7_EF.Models
{
    public class Artista
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Pais { get; set; }
    }
}
