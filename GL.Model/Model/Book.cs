using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GL.Model.Model
{
    public class Book : BaseEntity
    {
        public Book(string name, Author author, int yearOfPublish, string shelf)
        {
            Name = name;
            Author = author;
            YearOfPublish = yearOfPublish;
            Shelf = shelf;
            Status = true;
        }

        [Required]
        public string Name { get; set; } 
        
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        
        public Author Author { get; set; }
     
        [Required]
        public int YearOfPublish { get; set; }

        [Required, StringLength(2,MinimumLength = 2)]
        public string Shelf { get; set; }

        public bool Status { get; set; }
    }
}