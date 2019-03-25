using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GL.Model.Model.Contract;

namespace GL.Model.Model
{
    public class Shelf:BaseEntity
    {
        [Required, StringLength(2,MinimumLength = 2)]
        public string ShelfName { get; set; }
        
        
        public ICollection<Book> Books { get; set; }
    }
}