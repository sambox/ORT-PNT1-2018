using System.Data.Entity;

//namespace EF6Console
namespace ejemplo.Models
{
    public class BibliotecaContext : DbContext
    {

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Libro>().HasMany(x => x.Prestamos).WithRequired().Map(x => x.MapKey("libro_LibroID"));

        //    //modelBuilder.Entity<Usuario>().HasMany(x => x.Prestamos).WithRequired().Map(x => x.MapKey("usuario_UsuarioId"));

        //    modelBuilder.Entity<Usuario>()
        //        .HasMany(x => x.Prestamos).WithOptional(x => x.usuario);
        //    modelBuilder.Entity<Libro>()
        //        .HasMany(x => x.Prestamos).WithOptional(x => x.libro);

        //    Database.SetInitializer<BibliotecaContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
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