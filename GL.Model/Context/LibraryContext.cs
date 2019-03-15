using GL.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace GL.Model.Data
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
        public DbSet<Book> Books { get; set; }
        public DbSet<PersonBook> PersonsBooks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonBook>().HasKey(x => new {x.BookId, x.PersonId});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection.ConnectionString);
        }
    }
}