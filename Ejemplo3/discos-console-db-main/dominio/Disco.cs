using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        [DisplayName("Fecha")]
        public DateTime FechaLanzamiento { get; set; }
        [Required(ErrorMessage = "La cantidad de temas es requerida")]
        [DisplayName("Canciones")]
        public int CantidadCanciones { get; set; }
        [Required(ErrorMessage = "La url de la imagen es requerida")]
        [DisplayName("Imagen")]
        public string UrlTapa { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un estilo")]
        public Estilo Estilo { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un tipo de edicion")]
        public TipoEdicion TipoEdicion { get; set; }
    }
}
