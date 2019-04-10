using System.Linq;
using System.Text;
using GL.Model.Context;
using GL.Model.Model;

namespace GL.Services
{
    public class PersonService
    {
        private LibraryContext _context;

        public PersonService(LibraryContext context)
        {
            _context = context;
        }

        public bool Exists(string fName, string lName, int age)
        {
            return _context.Persons.Any(x => (x.FirstName == fName && x.LastName == lName) && x.Age==age);
        }

        public void AddPerson(string fName, string lName, int age)
        {
            Person person = new Person();

            person.FirstName = fName;
            person.LastName = lName;
            person.Age = age;

            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public string ViewAllPeople()
        {
            StringBuilder allPeople = new StringBuilder("Allow to this library are: \n");
            var people = _context.Persons.Select(c => $"{c.LastName}, {c.FirstName} {c.Age}y.o.").ToList();

            foreach (var person in people)
            {
                allPeople.Append(person + "\n");
            }

            return allPeople.ToString();
        }

        public Person GetPerson(string fName, string lName)
        {
            return _context.Persons
                .Where(c => c.FirstName == fName)
                .First(c => c.LastName == lName);
        }

        public void ChangePersonName(string currentFName, string currentLName, string newFName, string newLName)
        {
            Person person = GetPerson(currentFName, currentLName);

            person.FirstName = newFName;
            person.LastName = newLName;

            _context.SaveChanges();
        }

        public void Birthday(string fName, string lName)
        {
            Person person = GetPerson(fName, lName);

            person.Age += 1;

            _context.SaveChanges();
        }

        public void RemovePerson(string fName, string lName)
        {
            Person person = GetPerson(fName, lName);

            _context.Persons.Remove(person);
            _context.SaveChanges();
        }

        public void AddBooksToPersonList(Book book, Person person)
        {
            person.Books.Add(book);
            _context.Persons.Update(person);
            _context.SaveChanges();
        }

        public string ViewAllPersonBooks(string fName, string lName)
        {
            Person person = GetPerson(fName, lName);
            var books = person.Books.ToList();
            StringBuilder allPerosonBooks = new StringBuilder("That person have there books (once upon a time): \n");

            foreach (var book in books)
            {
                allPerosonBooks.Append(
                    $"{book.Title} from {book.Author.FirstName} {book.Author.LastName} on shelf {book.Shelf.ShelfName}\n");
            }

            return allPerosonBooks.ToString();
        }
    }
}