


using GL.Model.Context;
using GL.Model.Model;

namespace GL.Services
{
    public class BookService
    {
        private  LibraryContext _context;
        private AuthorService _authorService;
        private ShelfService _shelfService;
        private PersonService _personService;

        public BookService(LibraryContext context  )
        {
            _context = context;
            _authorService = new AuthorService(_context);
            _shelfService=new ShelfService(_context);
            _personService=new PersonService(_context);
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

            if (!_authorService.Exists(authorfName, authorlName))
            {
                _authorService.AddAuthor(authorfName, authorlName);
            }

            _authorService.AddBookToAuthor(book, author);

            if (!_shelfService.Exists(shelfName))
            {
                _shelfService.AddShelf(shelfName);
            }

            _shelfService.AddBookToShelf(book, shelf);

            _context.Books.Add(book);
        }
        
    }
}