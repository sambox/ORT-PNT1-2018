using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class LibroViewModel
    {
        public string titulo { get; set; }
        public string autor { get; set; }
        public string isbn { get; set; }
        public string genero { get; set; }
        public int cantEjemplares { get; set; }
    }
}