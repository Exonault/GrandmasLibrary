using System.Linq;
using GL.Model.Context;
using GL.Model.Model;

namespace GL.Services
{
    public class AuthorService
    {
        private readonly LibraryContext _context;

        public AuthorService(LibraryContext context  )
        {
            _context = context;
        }

        public void AddAuthor(string fNAme, string lName)
        {
            Author author=new Author();
            author.FirstName = fNAme;
            author.LastName = lName;
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public string ViewAllAuthors()
        {
            string allAutors = "Library have the following authors: \n";
            
            var authors = _context.Authors.Select(c => $"{c.LastName},{c.FirstName}").ToList();
            
         //   var authorsFirstName = _context.Authors.Select(c => c.FirstName).ToList();
            foreach (var author in authors)
            {
                allAutors += author + "\n";
            }
            return allAutors;
        }

        public void ChangeAuthorName(string currentFName,string currentLName, string newFName, string newLName)
        {
            Author author = _context.Authors
                .Where(c => c.FirstName == currentFName)
                .First(c => c.LastName == currentLName);
            author.FirstName = newFName;
            author.LastName = newLName;
            _context.SaveChanges();
        }

        public void DeleteAuthor(string fName, string lName)
        {
            Author author = _context.Authors
                .Where(c => c.FirstName == fName)
                .First(c => c.LastName == lName);
            _context.Remove(author);
            _context.SaveChanges();
        }
    }
}