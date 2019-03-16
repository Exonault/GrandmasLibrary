using System.ComponentModel.DataAnnotations;
using GL.Model.Model.Contract;

namespace GL.Model.Model
{
    public class Book:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public bool IsTaken { get; set; }

        public Shelf Shelf { get; set; }
        public Person Person { get; set; }
        public Author Author { get; set; }
    }
}