using GL.Model.Model.Contract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GL.Model.Model
{
    public class Person:BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, Range(1,100)]
        public int Age { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}