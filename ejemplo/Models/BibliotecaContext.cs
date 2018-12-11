using System.Data.Entity;

namespace ejemplo.Models
{
    public class BibliotecaContext : DbContext
    {

        public BibliotecaContext() : base()
        {
        }

        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}