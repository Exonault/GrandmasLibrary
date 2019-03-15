using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GL.Model.Model.Contract;

namespace GL.Model.Model
{
    public class Book : BaseEntity
    {
        public Book(string name, Author author, int yearOfPublish)
        {
            Name = name;
            Author = author;
            YearOfPublish = yearOfPublish;
            Status = true;
        }

        [Required]
        public string Name { get; set; } 
        
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        
        public Author Author { get; set; }
     
        [Required]
        public int YearOfPublish { get; set; }

        public bool Status { get; set; }
    }
}