using System.Linq;
using GL.Model.Context;
using GL.Model.Model;
using GL.Services;


namespace DefaultNamespace
{
    public class BookService
    {
        private static LibraryContext _context;

        public BookService(LibraryContext context  )
        {
            _context = context;
        }

        public void AddBook(string title, string shelfName, string authorfName, string authorlName)
        {
            Book book=new Book();
            book.Title = title;
            book.IsTaken = false;
            
            Author author= new Author();            
            author.FirstName = authorfName;
            author.LastName = authorlName;
            
            Shelf shelf=new Shelf();
            shelf.ShelfName = shelfName;

            if (!AuthorService.Exists(authorfName, authorlName))
            {
                AuthorService.AddAuthor(authorfName, authorlName);
            }

            AuthorService.AddBookToAuthor(book, author);

            if (!ShelfService.Exists(shelfName))
            {
                ShelfService.AddShelf(shelfName);
            }

            ShelfService.AddBookToShelf(book, shelf);

            _context.Books.Add(book);
        }
        
    }
}