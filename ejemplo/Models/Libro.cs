using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class Libro
    {
        private String titulo;
        private ArraySegment<String> autores;
        private ArraySegment<String> generos;
        private String isbn;
        private int cantEjemplares;
    }
}