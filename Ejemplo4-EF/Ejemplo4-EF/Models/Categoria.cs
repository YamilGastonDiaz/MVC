namespace Ejemplo4_EF.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<Articulo>? CategoriaArticulos { get; set; }
    }
}
