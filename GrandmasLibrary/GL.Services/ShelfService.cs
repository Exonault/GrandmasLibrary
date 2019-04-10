using System;
using System.Linq;
using System.Text;
using GL.Model.Context;
using GL.Model.Model;

namespace GL.Services
{
    public class ShelfService
    {
        private  LibraryContext _context;

        public ShelfService(LibraryContext context  )
        {
            _context = context;
        }

        public  bool Exists(string name)
        {
            return _context.Shelves.Any(x => x.ShelfName == name);
        }

        public  void AddBookToShelf(Book book, Shelf shelf)
        {
            shelf.Books.Add(book);
            _context.Shelves.Update(shelf);
            _context.SaveChanges();
        }

        public void RemoveBookFromShelf(Book book, Shelf shelf)
        {
            shelf.Books.Remove(book);
            _context.Shelves.Update(shelf);
            _context.SaveChanges();
        }

        public string ViewAllBooksOnShelf(string shelfName)
        {
            Shelf shelf = GetShelf(shelfName);
            var books = shelf.Books.ToList();
            StringBuilder allBooks = new StringBuilder("This shelf have the following books: \n");
            
            foreach (var book in books)
            {
                allBooks.Append($"{book.Title}, {book.Author.FirstName} {book.Author.LastName}"+ "\n");
            }

            return allBooks.ToString();
             
        }
        
        public  void AddShelf(string shelfName)
        {
            Shelf shelf=new Shelf();
            
            shelf.ShelfName = shelfName;
            
            _context.Shelves.Add(shelf);
            _context.SaveChanges();
        }
        
        public void DeleteShelf( string shelfName)
        {
            _context.Shelves.Remove(GetShelf(shelfName));
            _context.SaveChanges();
        }
       
        public string ViewShelves()
        {
            var shelves = _context.Shelves.Select(c => c.ShelfName).ToList();
            StringBuilder allShelves = new StringBuilder("Library have the following shelfs: \n");
            
            foreach (var shelf in shelves)
            {
                allShelves.Append(shelf + "\n");
            }

            return allShelves.ToString();
        }

        public Shelf GetShelf(string shelfName)
        {
            return _context.Shelves.First(x=>x.ShelfName==shelfName);
        }
       
        public void ChangeName(string currentName, string newName)
        {
            Shelf shelf = GetShelf(currentName);
            
            shelf.ShelfName = newName;
            _context.SaveChanges();
        }
        
    }
}