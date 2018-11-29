using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class LibroViewModel
    {
        public string Titulo { get; set; }
     public string Autor { get; set; }
        public string Isbn { get; set; }
        public string Genero { get; set; }
        public int Ejemplares { get; set; }

    }
}