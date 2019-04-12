using System.Linq;
using System.Text;
using GL.Data;
using GL.Model.Model;

namespace GL.Services
{
    public class AuthorService
    {
        private LibraryContext _context;

        public AuthorService(LibraryContext context)
        {
            _context = context;
        }

        public bool Exists(string fName, string lName)
        {
            return _context.Authors.Any(x => x.FirstName == fName && x.LastName == lName);
        }

        public void AddBookToAuthor(Book book, Author author)
        {
            author.Books.Add(book);
            _context.SaveChanges();
        }

        public void AddAuthor(string fName, string lName)
        {
            Author author = new Author();

            author.FirstName = fName;
            author.LastName = lName;

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public string ViewAllAuthors()
        {
            StringBuilder allAutors = new StringBuilder("Library has the following authors: \n");

            var authors = _context.Authors.Select(c => $"{c.LastName}, {c.FirstName}").ToList();

            foreach (var author in authors)
            {
                allAutors.Append(author + "\n");
            }

            return allAutors.ToString();
        }

        public Author GetAuthor(string fName, string lName)
        {
            return _context.Authors
                .First(c => c.FirstName == fName && c.LastName == lName);
        }

        public void ChangeAuthorName(string currentFName, string currentLName, string newFName, string newLName)
        {
            Author author = GetAuthor(currentFName, currentLName);

            author.FirstName = newFName;
            author.LastName = newLName;

            _context.SaveChanges();
        }

        public void DeleteAuthor(string fName, string lName)
        {
            _context.Remove(GetAuthor(fName, lName));
            _context.SaveChanges();
        }
    }
}