using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class Biblioteca
    {
        public const int DIAS_PRESTAMO = 7;
        public List<Prestamo> prestamos { get; set; }
        public List<Libro> libros { get; set; }
    }
}