using GL.Helpers;
using GL.Model.Model;
using Microsoft.EntityFrameworkCore;


namespace GL.Data
{
    public class LibraryContext:DbContext
    {
        public LibraryContext()
        {
            
        }

        public LibraryContext(DbContextOptions options):base(options)
        {
            
        }

        public virtual DbSet<Shelf> Shelves { get; set; }
        
        public virtual DbSet<Person> Persons { get; set; }
        
        public virtual DbSet<Author> Authors { get; set; }
        
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection.ConnectionString);
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