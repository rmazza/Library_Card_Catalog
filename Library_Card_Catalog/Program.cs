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
}
