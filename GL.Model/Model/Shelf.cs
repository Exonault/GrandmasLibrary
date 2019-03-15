using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GL.Model.Model.Contract;

namespace GL.Model.Model
{
    public class Shelf:BaseEntity
    {
        [Required, StringLength(2,MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}