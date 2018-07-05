using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDictionaryExample {
	class Program {
		static void Main(string[] args)
		{
			Dictionary<String, String> myDictionary = new Dictionary<string, string>();

			myDictionary.Add("Keith", "Fleming");
			myDictionary.Add("Nicole", "Fleming");
			myDictionary.Add("Julie", "Fleming");
			myDictionary.Add("Zack", "Fleming");

			Console.WriteLine(myDictionary.Count());

			foreach (var item in myDictionary) {
				Console.WriteLine(item.Key + "-" + item.Value);
			}

			myDictionary.Clear();

			Console.ReadKey();

		}
	}
}
