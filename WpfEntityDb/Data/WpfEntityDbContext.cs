using System.Data.Entity;
using WpfEntityDb.Models;

namespace WpfEntityDb.Data
{

    public class WpfEntityDbContext : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'WpfEntityDbContext' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'WpfEntityDb.Data.WpfEntityDbContext' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'WpfEntityDbContext'  en el archivo de configuración de la aplicación.
        public WpfEntityDbContext()
            : base("name=WpfEntityDbContext")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Raza> Razas { get; set; }
        public virtual DbSet<Color> Colores { get; set; }
        public virtual DbSet<Animal> Animales { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Aquí haremos nuestras configuraciones con Fluent API.

            // Especificar el nombre de una tabla.
            modelBuilder.Entity<Raza>().Map(m => m.ToTable("Raza"));
            modelBuilder.Entity<Color>().Map(m => m.ToTable("Color"));
            modelBuilder.Entity<Animal>().Map(m => m.ToTable("Animal"));

            /*
            // establecer una primary key.
            modelBuilder.Entity<Producto>().HasKey(c => c.Codigo);

            // Definir un campo como requerida.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).IsRequired();

            // Definir el nombre de un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).HasColumnName("Nombre");

            // Definir el tipo de un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).HasColumnType("varchar");

            // Definir el orden de un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).HasColumnOrder(2);

            // Definir el máximo de caracteres permitidos para un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Descripcion).HasMaxLength(100);

            // indicar que no se debe mapear una pripiedad a la base de datos.
            modelBuilder.Entity<Producto>().Ignore(c => c.CodigoIso);   */

            base.OnModelCreating(modelBuilder);
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

}