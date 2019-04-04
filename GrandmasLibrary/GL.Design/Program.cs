using System;
using GL.Services;

namespace GL.Design
{
    class Program
    {
        static void Main(string[] args)
        {
            Draw();
            string selectNumber = Console.ReadLine();
            
            switch (selectNumber)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(" Log In");
                    Console.WriteLine(" --------------------------");
                    Console.Write(" Please enter your first name: ");
                    string firstName = Console.ReadLine();
                    Console.Write(" Please enter your last name: ");
                    string lastName = Console.ReadLine();
                    if (true) //валидация - ако няма
                    {

                    }
                    else
                    {
                        Console.WriteLine(" There's no person with that name found.");

                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine(" Sign Up");
                    Console.WriteLine(" --------------------------");
                    Console.Write(" Please enter your first name: ");
                    string firstNameSignUp = Console.ReadLine();
                    Console.Write(" Please enter your last name: ");
                    string lastNameSignUp = Console.ReadLine();
                    // Create new person & add
                    // person p = new person(firstnamesignup, lastnamesignup);
                    //persons.add(p);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine(" Search a Book");
                    Console.WriteLine(" --------------------------");
                    Console.Write(" Please enter the book's title: ");
                    string bookTitle = Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine(" Show Shelves");
                    Console.WriteLine(" --------------------------");
                    //Shelves.Show();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine(" Show Authors");
                    Console.WriteLine(" --------------------------");
                    //Authors.Show();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine(" Add a Book");
                    Console.WriteLine(" --------------------------");
                    Console.Write(" Please enter the book's title:");
                    string newBookTitle = Console.ReadLine();
                    Console.Write(" Please enter the book's author:");
                    string newBookAuthor = Console.ReadLine();
                    //book b = new book(newBookTitle, newBookAuthor);
                    //или  authors.add(newBookAuthor);
                    break;
                case "7":
                    Console.Clear();
                    Console.WriteLine(" Add an Author");
                    Console.WriteLine(" --------------------------");
                    Console.Write(" Please enter the author's name:");
                    string authorName = Console.ReadLine();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;

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
            Console.WriteLine(" 6. Add a Book");
            Console.WriteLine(" 7. Add an Author");
            Console.WriteLine(" 0. Exit");
            Console.WriteLine();
            Console.Write("Please enter one of the numbers above: ");
        }
      
        
            
    }
}
