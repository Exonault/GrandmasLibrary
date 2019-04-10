using System;
using GL.Model.Context;
using GL.Services;

namespace GL.Design
{
    class Program
    {
        private static AuthorService _authorService=new AuthorService(new LibraryContext());
        private static ShelfService _shelfService=new ShelfService(new LibraryContext());
        private static PersonService _personService= new PersonService(new LibraryContext());
        private static BookService _bookService= new BookService(new LibraryContext());
        static string firstName;
        static string lastName;

        static void Main(string[] args)
        {
            Draw();
            while(true){
            string selectNumber = Console.ReadLine();
            switch (selectNumber)
            {
                case "1":
                    LogIn();
                    break;
                case "2":
                    SignUp();
                    break;
                case "3":
                    if (IsPersonLogIn())
                    {
                        SearchBook();
                    }
                    else
                    {
                        Console.WriteLine("You need to log in for this use 1.");
                    }

                    break;
                case "4":
                    if (IsPersonLogIn())
                    {
                        Console.Clear();
                        Console.WriteLine(" Show Shelves");
                        Console.WriteLine(" --------------------------");
                        Console.WriteLine(_shelfService.ViewShelves());
                    }
                    else
                    {
                        Console.WriteLine("You need to log in for this use 1.");
                    }

                    break;
                case "5":
                    if (IsPersonLogIn())
                    {
                        Console.Clear();
                        Console.WriteLine(" Show Authors");
                        Console.WriteLine(" --------------------------");
                        Console.WriteLine(_authorService.ViewAllAuthors());
                    }
                    else
                    {
                        Console.WriteLine("You need to log in for this use 1.");
                    }

                    break;
                case "6":
                    if (IsPersonLogIn())
                    {
                        Console.Clear();
                        Console.WriteLine(" Show Books");
                        Console.WriteLine(" --------------------------");
                        Console.WriteLine(_bookService.ViewAllBooks());
                    }
                    else
                    {
                        Console.WriteLine("You need to log in for this use 1.");
                    }

                    break;
                case "7":
                    if (IsPersonLogIn())
                    {
                        AddShelf();
                    }
                    else
                    {
                        Console.WriteLine("You need to log in for this use 1.");
                    }

                    break;
                case "8":
                    if (IsPersonLogIn())
                    {
                        AddBook();

                    }
                    else
                    {
                        Console.WriteLine("You need to log in for this use 1.");
                    }

                    break;
                case "9":
                    Draw();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
            }
            }
        }
        static void Draw()
        {
            Console.WriteLine(" Welcome to Grandma's Library!");
            Console.WriteLine(" What do you wish to do?");
            Console.WriteLine();
            Console.WriteLine(" --------------------------");
            Console.WriteLine();
            Console.WriteLine(" 1. Log In");
            Console.WriteLine(" 2. Sign Up");
            Console.WriteLine(" 3. Search a Book");
            Console.WriteLine(" 4. Show Shelves");
            Console.WriteLine(" 5. Show Authors");
            Console.WriteLine(" 6. Show Books");
            Console.WriteLine(" 7. Add a Shelf");
            Console.WriteLine(" 8. Add a Book");
            Console.WriteLine(" 9.Show Menu");
            Console.WriteLine(" 0. Exit");
            Console.WriteLine();
            Console.Write("Please enter one of the numbers above: ");
        }

        static void LogIn()
        {
            Console.Clear();
            Console.WriteLine(" Log In");
            Console.WriteLine(" --------------------------");
            Console.Write(" Please enter your first name: ");
            firstName = Console.ReadLine();
            Console.Write(" Please enter your last name: ");
            lastName = Console.ReadLine();
            Console.Write(" Enter your age: ");
            int age = int.Parse(Console.ReadLine());
            if (!_personService.Exists(firstName, lastName, age))
            {
                Console.WriteLine(" There's no person with that name found.");
                Console.WriteLine(" Use 2 to Sign Up or try again");
                firstName = null;
                lastName = null;
            }
        }

        static void SignUp()
        {
            Console.Clear();
            Console.WriteLine(" Sign Up");
            Console.WriteLine(" --------------------------");
            Console.Write(" Please enter your first name: ");
            string firstNameSignUp = Console.ReadLine();
            Console.Write(" Please enter your last name: ");
            string lastNameSignUp = Console.ReadLine();
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());
            if (_personService.Exists(firstNameSignUp, lastNameSignUp, age))
            {
                Console.WriteLine("This person already have an account. Please use 1 to log in");
            }
            else
            {
                if (SignUpValidation(firstNameSignUp, lastNameSignUp, age))
                {
                    firstName = firstNameSignUp;
                    lastName = lastNameSignUp;
                    _personService.AddPerson(firstNameSignUp,lastNameSignUp,age);
                    Console.WriteLine("New person added. Now you can use our library.");
                    
                }
            }
            
        }

        static void SearchBook()
        {
            Console.Clear();
            Console.WriteLine(" Search a Book");
            Console.WriteLine(" --------------------------");
            Console.Write(" Please enter the book's title: ");
            string bookTitle = Console.ReadLine();
            Console.Write(" Please enter the book's author's FIRST name: ");
            string bookAuthorFirstName = Console.ReadLine();
            Console.Write(" Please enter the book's author's LAST name: ");
            string bookAuthorLastName = Console.ReadLine();
            Console.WriteLine($"The book {0} from {1} is on shelf {2}"
                ,bookTitle
                , bookAuthorFirstName+bookAuthorLastName
                ,_bookService.GetBookShelf(bookTitle
                    ,bookAuthorFirstName
                    ,bookAuthorLastName));
            Console.WriteLine(" --------------------------");
            Console.WriteLine("Do you want to get the book? \n Yes/No");
            string answer = Console.ReadLine();
            if (answer == "Yes")
            {
                _bookService.PersonGetsBook(bookTitle
                    ,bookAuthorFirstName
                    ,bookAuthorLastName
                    ,firstName
                    ,lastName);
            }
        }

        static void AddShelf()
        {
            Console.Clear();
            Console.WriteLine(" Add a Shelf");
            Console.WriteLine(" --------------------------");
            Console.Write(" Please enter the Shelf's name:");
            string shelfName = Console.ReadLine();
            if (shelfName.Length != 2)
            {
                Console.WriteLine("Invalid shelf name!!! Shelf's name must be 2 characters ");
            }
            else
            {
                if (!_shelfService.Exists(shelfName))
                {
                    _shelfService.AddShelf(shelfName);
                }
                else
                {
                    Console.WriteLine("This shelf already exist. \n Do you want to see the books on it? \n Yes/No");
                    string answer = Console.ReadLine();
                    if (answer == "Yes")
                    {
                        _shelfService.ViewAllBooksOnShelf(shelfName);
                    }
                }
            }
        }
        
        static void AddBook()
        {
            Console.Clear();
            Console.WriteLine(" Add a Book");
            Console.WriteLine(" --------------------------");
            Console.Write(" Please enter the book's title:");
            string newBookTitle = Console.ReadLine();
            Console.Write(" Please enter the book's author's FIRST name: ");
            string bookAuthorFirstName = Console.ReadLine();
            Console.Write(" Please enter the book's author's LAST name: ");
            string bookAuthorLastName = Console.ReadLine();
            Console.WriteLine("Please enter the book's shelf: ");
            string shelfName = Console.ReadLine();
            _bookService.AddBook(newBookTitle,
                shelfName,
                bookAuthorFirstName,
                bookAuthorLastName);
        }
        
        static bool SignUpValidation(string fName, string lName, int age)
        {
            bool nameIsValid = true;
            
            for (int i = 0; i < 10; i++)
            {
                if (fName.Contains(char.Parse(i.ToString())) || lName.Contains(char.Parse(i.ToString())))
                {
                    nameIsValid = false;
                }
            }

            if (fName==" "||lName==" ")
            {
                nameIsValid = false;
            }
            
            if (age <= 0 || age > 150)
            {
                nameIsValid = false;
            }
            return nameIsValid;
        }
        
        static bool IsPersonLogIn()
        {
            if (firstName==null || lastName==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        }
    }
