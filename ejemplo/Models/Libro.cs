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
        public String autor { get; set; }
        public String genero { get; set; }
        public String isbn { get; set; }
        public int cantEjemplares { get; set; }

        public Libro(string titulo, string autor, string genero, string isbn, int cantEjemplares)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.genero = genero;
            this.isbn = isbn;
            this.cantEjemplares = cantEjemplares;
        }

        public Libro()
        {
        }
    }
}