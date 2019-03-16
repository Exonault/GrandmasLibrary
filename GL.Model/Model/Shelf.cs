using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GL.Model.Model
{
    public class Shelf
    {
        [Required, StringLength(2,MinimumLength = 2)]
        public string ShelfName { get; set; }
        
        
        public ICollection<Book> Books { get; set; }
    }
}