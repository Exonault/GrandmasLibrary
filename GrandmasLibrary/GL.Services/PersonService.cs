using System.Linq;
using GL.Model.Context;
using GL.Model.Model;

namespace GL.Services
{
    public class PersonService
    {
        private readonly LibraryContext _context;

        public PersonService(LibraryContext context  )
        {
            _context = context;
        }
        
        public bool Exists(string fName, string lName, int age)
        {
            bool exist = false;
            
            var people = _context.Persons.Select(c => $"{c.LastName},{c.FirstName} {c.Age}").ToList();
            string name = $"{lName},{fName} {age}";

            foreach (var person in people)
            {
                if (person == name)
                {
                    exist = true;
                }
            }
            
            return exist;
        }
        
        public void AddPerson(string fName, string lName, int age)
        {
            Person person= new Person();
            
            person.FirstName = fName;
            person.LastName = lName;
            person.Age = age;
            
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public string ViewAllPeople()
        {
            string allPeople = "Allow to this library are: \n";
            var people = _context.Persons.Select(c => $"{c.LastName}, {c.FirstName} {c.Age}y.o.").ToList();
            
            foreach (var person in people)
            {
                allPeople += person + "\n";
            }
            
            return allPeople;
        }
        
        public void ChangePersonName(string currentFName,string currentLName, string newFName, string newLName)
        {
            Person person = _context.Persons
                .Where(c => c.FirstName == currentFName)
                .First(c => c.LastName == currentLName);
            
            person.FirstName = newFName;
            person.LastName = newLName;
            
            _context.SaveChanges();
        }

        public void Birthday(string fName, string lName)
        {
            Person person=_context.Persons
                .Where(c => c.FirstName == fName)
                .First(c => c.LastName == lName);
            
            person.Age += 1;
            
            _context.SaveChanges();
            
        }

        public void RemovePerson(string fName, string lName)
        {
            Person person=_context.Persons
                .Where(c => c.FirstName == fName)
                .First(c => c.LastName == lName);
            
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
        
        
    }
}