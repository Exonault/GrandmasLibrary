using System.ComponentModel.DataAnnotations;
using GL.Model.Model.Contract;

namespace GL.Model.Model
{
    public class Person:BaseEntity
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }
        
        
        
    }
}