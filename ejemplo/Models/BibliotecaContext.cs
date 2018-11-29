using System.Data.Entity;

//namespace EF6Console
namespace ejemplo.Models
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext() : base()
        {
          //  Database.SetInitializer<BibliotecaContext>(new CreateDatabaseIfNotExists<BibliotecaContext>());
           // Database.SetInitializer<BibliotecaContext>(null);
        }

        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}