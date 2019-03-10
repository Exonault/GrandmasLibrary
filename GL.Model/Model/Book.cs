namespace GL.Model.Model
{
    public class Book
    {

        public int Id { get; set; }

        public string Name { get; set; }
        
        public Author Author { get; set; }
        
        public int AuthorId { get; set; }
        
        public int YearOfPublish { get; set; }
        
        public string Shelf { get; set; }
        
        public bool Status { get; set; }

        public Book(string name, Author author, int yearOfPublish, string shelf)
        {
            Name = name;
            Author = author;
            YearOfPublish = yearOfPublish;
            Shelf = shelf;
            Status = true;
        }
    }
}