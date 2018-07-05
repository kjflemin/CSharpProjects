using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ClassLibrary;

namespace MSUnitTest {
	class Program {
		static void Main(string[] args) {
			MainSimpleClass sc = new MainSimpleClass();
			Console.WriteLine(sc.AddInts(1, 2));

		}
	}
}
