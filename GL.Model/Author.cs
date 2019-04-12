using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GL.Model.Model.Contract;

namespace GL.Model.Model
{
    public class Author:BaseEntity  
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
        
        
    }
}