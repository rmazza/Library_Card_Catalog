using System;
using System.Runtime.Serialization;

namespace Library_Card_Catalog
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
		}
	}

	public class Book : ISerializable {

		public string Title{ get; set; }
		public string Author{ get; set; }
		public string Genre{ get; set; }
		public int NumPages { get; set;}
		public int YearPublished{ get; set; }

		public Book () {
			//empty constructor
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// Use the AddValue method to specify serialized values.
			info.AddValue(this.Title, Title, typeof(string));
			info.AddValue (this.Author, Author, typeof(string));
			info.AddValue(this.Genre, Genre, typeof(string));
			info.AddValue (this.NumPages, NumPages, typeof(int));
			info.AddValue (this.YearPublished, YearPublished, typeof(int));

		}
	}

	public class CardCatalog {
		private string _fileName{ get; set; }
		 

		public void cardCatalog(string fileName) {

		}

		public string ListBooks() {

		}

		public void AddBook() {
			
			try{
			Console.WriteLine ("Enter the book title: ");
			Title = Console.ReadLine ();
			}catch(Exception){
				Console.WriteLine ("Exception found please enter a valid book title");
				Console.ReadLine ();
			}

			try {
			Console.WriteLine ("Enter the author of the book: ");
			Author = Console.ReadLine ();
			}catch(Exception) {
				Console.WriteLine ("Exception found please enter a valid book author");
				Console.ReadLine ();
			}

			try {
			Console.WriteLine ("Enter the genre of the book: ");
				Genre = Console.ReadLine ();
			}catch(Exception) {
				Console.WriteLine ("Exception found please enter a valid book genre");
				Console.ReadLine ();
			}

			Console.WriteLine ("Enter the number of pages the book has: ");
			NumPages = Convert.ToInt32 (Console.ReadLine ());

			Console.WriteLine ("Enter the year the book was published: ");
			YearPublished = Convert.ToInt32 (Console.ReadLine ());

		}

		public void Save() {

		}

	}
}
