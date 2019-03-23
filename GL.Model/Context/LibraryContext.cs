using GL.Model.Model;
using GL.Model.Model.Contract;
using Microsoft.EntityFrameworkCore;

namespace GL.Model.Context
{
    public class LibraryContext:DbContext
    {
        public LibraryContext()
        {     
        }

        public LibraryContext(DbContextOptions options):base(options)
        {          
        }

        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         //   optionsBuilder.UseSqlServer(Connection.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shelf>().HasMany(s => s.Books)
                .WithOne(b => b.Shelf);
            modelBuilder.Entity<Person>().HasMany(p => p.Books)
                .WithOne(b => b.Person);
            modelBuilder.Entity<Author>().HasMany(a => a.Books)
                .WithOne(b => b.Author);
        }
    }
}