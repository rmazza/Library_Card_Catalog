using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library_Card_Catalog
{
    class CardCatalog
    {
        private string _fileName;
        private List<Book> books;

        public CardCatalog() { }

        public CardCatalog(string fileName)
        {
            this._fileName = fileName;
            this.books = new List<Book>();
        }

        public void ListBooks()
        {
            foreach (Book b in books)
            {
                //Read trough each book oject in the list and print the appropriate information about the book
                Console.Write("Title: {0}\nAuthor: {1}\nGenre: {2}\n# of Pages: {3}\nYear: {4}\n", b.Title, b.Author, b.Genre, b.NumPages, b.YearPublished);
                Console.WriteLine();
            }
        }

        public void AddBook(Book b)
        {
            books.Add(b);
        }

        // SaveAndExit Method - takes one string parameter 'path'
        // Serialiazes the Book List (List<Book>) and writes it to the file given in the path
        public void SaveAndExit(string path, IFormatter formatter)
        {
            try
            {
                FileStream writeStream = new FileStream(path, FileMode.Open, FileAccess.Write);
                formatter.Serialize(writeStream, this.books);

                // Closes the file stream
                writeStream.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("There was an error saving the file!");
            }
        }

        //Load Method - takes one string parameter 'path'
        //checks to see if a file already exists
        //If file exists then it loads the file's serialized content into memory
        //If file does not exist then it creates the file
        public void Load(string path, IFormatter formatter)
        {
            // Check to see if the file exists
            // If true then tries to desearialize the file
            // If false then creates a new empty file
            if (File.Exists(path))
            {

                try
                {
                    FileStream readerFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    this.books = (List<Book>)formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when we are done
                    readerFileStream.Close();


                    Console.WriteLine("{0} successfully loaded", this._fileName);

                }
                catch (IOException e)
                {
                    Console.WriteLine("Error loading the file!\nMessage: {0}", e.Message);
                }

            }
            else
            {

                try
                {
                    FileStream s = new FileStream(path, FileMode.CreateNew);
                    s.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error creating a new empty file.\nMessage: {0}", e.Message);
                }

            }

        }

    }
}
