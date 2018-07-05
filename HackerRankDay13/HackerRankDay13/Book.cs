using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay13 {
	abstract class Book {
		protected String _title;
		protected String _author;

		public Book(String Title, String Author)
		{
			_title = Title;
			_author = Author;
		}

		public abstract void Display();
	}


	class MyBook : Book {

		private int _price;

		public MyBook(String Title, String Author, int Price) : base(Title, Author)
		{
			_price = Price;
		}

		public override void Display()
		{
			Console.WriteLine("Title: " + _title);
			Console.WriteLine("Author: " + _author);
			Console.WriteLine("Price: " + _price);
		}

	}



}
