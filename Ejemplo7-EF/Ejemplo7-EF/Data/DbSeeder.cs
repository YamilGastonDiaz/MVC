using Ejemplo7_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo7_EF.Data
{
    public static class DbSeeder
    {
        public static void Seed(GaleriaDbContext context)
        {
            context.Database.EnsureCreated();

            // =========================
            // ARTISTAS ARGENTINOS
            // =========================

            var artistas = new List<Artista>
            {
                new Artista
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Antonio Berni",
                    Pais = "Argentina"
                },

                new Artista
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Xul Solar",
                    Pais = "Argentina"
                },

                new Artista
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Emilio Pettoruti",
                    Pais = "Argentina"
                },
            };

            if (!context.Artistas.Any())
                context.Artistas.AddRange(artistas);

            Guid A(string nombre)
                => artistas.Single(a => a.Nombre == nombre).Id;

            // =========================
            // OBRAS
            // =========================

            var obras = new List<Obra>
            {
                // =========================
                // Antonio Berni
                // =========================

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Manifestación",
                    Estilo = "Realismo Social",
                    ArtistaId = A("Antonio Berni"),
                    UrlImagen = "https://coleccion.malba.org.ar/wp-content/uploads/2019/05/Berni-Manifestacion-023-1.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Juanito Laguna",
                    Estilo = "Collage",
                    ArtistaId = A("Antonio Berni"),
                    UrlImagen = "https://coleccion.malba.org.ar/wp-content/uploads/2019/05/Berni-Juanito-dormido-019.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Chelsea Hotel",
                    Estilo = "Realismo Social",
                    ArtistaId = A("Antonio Berni"),
                    UrlImagen = "https://coleccion.malba.org.ar/wp-content/uploads/2019/05/Berni-Chelsea-hotel-017.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Ramona Bebe",
                    Estilo = "Collage",
                    ArtistaId = A("Antonio Berni"),
                    UrlImagen = "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjcbHZQoBOnotjsTmJgdUOCbZHGKLQ-wLeieG6uXFiOd5WPRQTUguPvXHPoEbRsPj2KsH4yaM9PvFmBxJN3BcIhimaRakRg6DuJfk86LF5hde1r293v5xi5QX8FDidt8PRq2SGQQvJHKFRi/s1600/RamonaBebeBerni.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "El Coronel Golpista N°3",
                    Estilo = "Collage",
                    ArtistaId = A("Antonio Berni"),
                    UrlImagen = "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjC8qWX4dDkMC-Afbga0JJvGgmRda1Iu1NvI_BqwjmRLzHssOZDvQRRxwle1Gas9Sq9VwByCEHBkPMTnfV8A04AgYI-j_uARizj-66M9kozeeBi8ugNCiaI4RcDfSpsvPb4z6cAjsXC_JaP/s1600/ElCoronelGolpista3Berni.jpg"
                },

                // =========================
                // Xul Solar
                // =========================

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Vuel Villa",
                    Estilo = "Surrealismo",
                    ArtistaId = A("Xul Solar"),
                    UrlImagen = "https://www.xulsolar.org.ar/img/coleccion/30-02-Vuel%20Villa.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Drago",
                    Estilo = "Acuarela",
                    ArtistaId = A("Xul Solar"),
                    UrlImagen = "https://www.xulsolar.org.ar/img/coleccion/20-01-Drago.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Ciudad Lagui",
                    Estilo = "Fantástico",
                    ArtistaId = A("Xul Solar"),
                    UrlImagen = "https://www.xulsolar.org.ar/img/coleccion/30-06-Ciudad%20Lagui.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Signos Zodiacales Impares",
                    Estilo = "Vanguardista",
                    ArtistaId = A("Xul Solar"),
                    UrlImagen = "https://www.xulsolar.org.ar/img/coleccion/50-09-Signos%20Zodiacales%20Impares.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Signos Zodiacales Pares",
                    Estilo = "Vanguardista",
                    ArtistaId = A("Xul Solar"),
                    UrlImagen = "https://www.xulsolar.org.ar/img/coleccion/50-11-Signos%20Zodiacales%20Pares.jpg"
                },

                // =========================
                // Emilio Pettoruti
                // =========================

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "El hombre de la flor amarilla",
                    Estilo = "Cubismo",
                    ArtistaId = A("Emilio Pettoruti"),
                    UrlImagen = "https://bellasartes.gob.ar/media/thumbs/uploads/coleccion/VCQyOMMPiS24.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Arlequín",
                    Estilo = "Cubismo",
                    ArtistaId = A("Emilio Pettoruti"),
                    UrlImagen = "https://bellasartes.gob.ar/media/thumbs/uploads/coleccion/cYBStyHIP_JH.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Sol Argentino",
                    Estilo = "Vanguardismo",
                    ArtistaId = A("Emilio Pettoruti"),
                    UrlImagen = "https://bellasartes.gob.ar/media/thumbs/uploads/coleccion/4mjuvvV8_Ldm.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "Vino Rosso",
                    Estilo = "Cubismo",
                    ArtistaId = A("Emilio Pettoruti"),
                    UrlImagen = "https://bellasartes.gob.ar/media/thumbs/uploads/coleccion/P8fOrmq3JZRO.jpg"
                },

                new Obra
                {
                    Id = Guid.NewGuid(),
                    Titulo = "El Sifón",
                    Estilo = "Cubismo",
                    ArtistaId = A("Emilio Pettoruti"),
                    UrlImagen = "https://bellasartes.gob.ar/media/thumbs/uploads/coleccion/FKOPH2Mpd1GO.jpg"
                },
            };

            if (!context.Obras.Any())
                context.Obras.AddRange(obras);

            // =========================
            // EXPOSICIONES
            // =========================

            var exposiciones = new List<Exposicion>
            {
                new Exposicion
                {
                    Nombre = "Vanguardias Argentinas del Siglo XX",
                    FechaInicio = Convert.ToDateTime("01/06/2026"),
                    FechaFin = Convert.ToDateTime("31/08/2026")
                },

                new Exposicion
                {
                    Nombre = "Berni y la Crítica Social",
                    FechaInicio = Convert.ToDateTime("15/09/2026"),
                    FechaFin = Convert.ToDateTime("15/11/2026")
                }
            };

            if (!context.Exposiciones.Any())
                context.Exposiciones.AddRange(exposiciones);

            context.SaveChanges();
        }
    }
}

