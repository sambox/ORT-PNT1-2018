using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class Biblioteca
    {
        private const int DIAS_PRESTAMO = 7;
        public List<Prestamo> prestamos;
        public List<Libro> libros;



    }
}