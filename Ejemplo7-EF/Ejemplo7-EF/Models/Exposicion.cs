

using System.ComponentModel.DataAnnotations;

namespace Ejemplo7_EF.Models
{
    public class Exposicion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        public List<Obra>? ObrasExpuestas { get; set; }
    }
}
