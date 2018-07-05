using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay16 {
	class Program {
		static void Main(string[] args)
		{
			string S = Console.ReadLine();
			int myvalue;

			try {
				myvalue = Int32.Parse(S);
				Console.WriteLine(myvalue);
			}
			catch (FormatException) {
				Console.WriteLine("Bad String");
			}catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
	}
}
