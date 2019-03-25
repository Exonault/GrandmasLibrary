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
            bool exist = false;
            
            var shelves = _context.Shelves.Select(c => c.ShelfName).ToList();

            foreach (var shelf in shelves)
            {
                if (shelf == name)
                {
                    exist = true;
                }
            }
            
            return exist;
        }

        public  void AddBookToShelf(Book book, Shelf shelf)
        {
            shelf.Books.Add(book);
            _context.SaveChanges();
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
            Shelf shelf = _context.Shelves.Find(shelfName);
            
            _context.Shelves.Remove(shelf);
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
       
        public void ChangeName(string currentName, string newName)
        {
            Shelf shelf = _context.Shelves.Find(currentName);
            
            shelf.ShelfName = newName;
            _context.SaveChanges();
        }
        
    }
}