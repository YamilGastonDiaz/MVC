using System.ComponentModel;

namespace Ejemplo6_EF.Models
{
    public class Disco
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamineto { get; set; }
        public int CantidadCanciones { get; set; }
        [DisplayName("Tapa")]
        public string UrlTapa { get; set; }
        public int EstiloId { get; set; }
        public int TipoEdicionId { get; set; }
        public Estilo? Estilo { get; set; }
        public TipoEdicion? TipoEdicion { get; set; }
    }
}
