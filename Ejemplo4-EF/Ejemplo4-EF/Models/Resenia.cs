namespace Ejemplo4_EF.Models
{
    public class Resenia
    {
        public int Id { get; set; }
        public int Puntuacion { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public Articulo Articulo { get; set; }
    }
}
