using GL.Model.Context;
using GL.Model.Model;
using  System.Linq;
using System.Text;

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

        public Book GetBook(string title, Author author)
        {
            return _context.Books
                .Where(c => c.Title == title)
                .First(c => c.Author == author);
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
            _context.SaveChanges();
        }

        public void RemoveBook(string title, string authorfName, string authorlName)
        {
            Author author = _authorService.GetAuthor(authorfName, authorlName);

            Book book = GetBook(title, author);
            Shelf shelf = book.Shelf;
            _context.Remove(book);
            _shelfService.RemoveBookFromShelf(book,shelf);
            _context.SaveChanges();
        }

        public string ViewAllBooks()
        {
            var books=_context.Books
                .Select(c => $"{c.Title}, {c.Author.FirstName} {c.Author.LastName} ({c.Shelf.ShelfName})")
                .ToList();
            StringBuilder allBook=new StringBuilder("Library have the following books: \n");
            
            foreach (var book in books)
            {
                allBook.Append(book + "\n");
            }
            
            return allBook.ToString();
        }

        public void ChangeShelf(string title, string authorfName, string authorlName, string newShelf)
        {
            Author author = _authorService.GetAuthor(authorfName, authorlName);

            Book book = GetBook(title, author);

            Shelf shelf = book.Shelf;
            Shelf newShelfForTheBook = _shelfService.GetShelf(newShelf);
            
            _shelfService.RemoveBookFromShelf(book, shelf);
            _shelfService.AddBookToShelf(book,newShelfForTheBook);
            book.Shelf.ShelfName = newShelf;
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void PersonGetsBook(string title, string authorfName, string authorlName, string personfName,
            string personlName)
        {
            Author author = _authorService.GetAuthor(authorfName, authorlName);
            Book book = GetBook(title, author);
            Person person = _personService.GetPerson(personfName, personlName);

            book.IsTaken = true;
            book.Person = person;
            _personService.AddBooksToPersonList(book,person);

            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void PersonReturnsBook(string title, string authorfName, string authorlName)
        {
            Author author = _authorService.GetAuthor(authorfName, authorlName);
            Book book = GetBook(title, author);
            
            book.IsTaken = false;
            book.Person = null;
            
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        
        public string GetBookShelf(string title, string authorfName, string authorlName)
        {
             Author author = _authorService.GetAuthor(authorfName, authorlName);
             Book book = GetBook(title, author);
             return book.Shelf.ShelfName;
        }
    }
}