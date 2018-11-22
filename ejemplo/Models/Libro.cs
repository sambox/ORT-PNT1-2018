using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class Libro
    {
        public int LibroID { get; set; }
        public String titulo { get; set; }
        public List<String> autores { get; set; }
        public List<String> generos { get; set; }
        public String isbn { get; set; }
        public int cantEjemplares { get; set; }

        public Libro(string titulo, List<string> autores, List<string> generos, string isbn, int cantEjemplares)
        {
            this.titulo = titulo;
            this.autores = autores;
            this.generos = generos;
            this.isbn = isbn;
            this.cantEjemplares = cantEjemplares;
        }
    }
}