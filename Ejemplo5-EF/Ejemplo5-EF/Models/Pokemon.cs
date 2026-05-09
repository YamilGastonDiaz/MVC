using System.ComponentModel;

namespace Ejemplo5_EF.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [DisplayName("Imagen")]
        public string UrlImagen { get; set; }
        public int TipoId { get; set; }
        public int DebilidadId { get; set; }
        public Elemento? Tipo { get; set; }
        public Elemento? Debilidad { get; set; }
        public bool Estado { get; set; }
    }
}
