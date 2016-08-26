using System;
using System.IO;

namespace Library_Card_Catalog
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int choice, year, pages;
            string title, author, genre, fileName;

            //Gets the path of the current directory and appends a '\' 
            //Stores the string into the path variable, the file name is NOT saved in this string
            string path = Directory.GetCurrentDirectory() + "\\";

            //Ask user for a file name and read into string variable fileName
            Console.Write("Enter a filename to save to: ");
            fileName = Console.ReadLine();

            //Create a new instance of the CardCatalog class
            CardCatalog cat = new CardCatalog(fileName);

            //Pass the path and the file name to the CardCatalog's Load method
            cat.Load(path + fileName);

            do
            {
                //Ask User to input a number 1 - 3 based on which option they choose
                Console.WriteLine("\nWhich option would you like (choose by number 1 - 3):");
                Console.Write("1: List All Books\n2: Add A Book\n3:Save and Exit\nChoice: ");
                string c = Console.ReadLine();

                //this Console.WriteLine() is just to give a space on the console for looks
                Console.WriteLine();

                //Parse the string to an integer and if successful returns the parsed number to the variable choice
                int.TryParse(c, out choice);


                if (choice == 1)
                {
                    //List All Books
                    cat.ListBooks();

                }
                else if (choice == 2)
                {
                    //ADD A BOOK
                    Console.Write("Please enter the title: ");
                    title = Console.ReadLine();

                    Console.Write("Please enter the author: ");
                    author = Console.ReadLine();

                    Console.Write("Please enter the genre: ");
                    genre = Console.ReadLine();

                    Console.Write("Please enter the # of pages: ");
                    int.TryParse(Console.ReadLine(), out pages);

                    Console.Write("Please enter the year published: ");
                    int.TryParse(Console.ReadLine(), out year);

                    //call AddBook from the Card Catalog class and pass a new Book object to store in the list
                    cat.AddBook(new Book(title, author, genre, pages, year));
                }
                else
                {
                    // SAVE AND EXIT
                    // If the choice is 3 or any other number beside 1 or 2
                    // The SaveAndExit method is called and then the program is exited
                    cat.SaveAndExit(path + fileName);
                }

            } while (choice >= 1 && choice <= 2);

        }

    }
}
