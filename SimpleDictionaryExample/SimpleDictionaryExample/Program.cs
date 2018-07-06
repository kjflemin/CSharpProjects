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

			foreach (var item in myDictionary) {
				Console.WriteLine(item.Key + "-" + item.Value);
			}

			Console.WriteLine("There are {0} elements in the Dictionary.", myDictionary.Count);

			if (myDictionary.ContainsKey("Keith")) {
				Console.WriteLine("This dictionary contains Keith");
			}

			myDictionary.Clear();

			Console.ReadKey();

		}
	}
}
