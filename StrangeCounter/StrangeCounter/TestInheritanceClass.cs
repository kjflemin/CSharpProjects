using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrangeCounter {
	class TestInheritanceClass : TestInheritanceBaseClass {
		public void WriteToScreen(String myString = "Ghosts say ") {
			Console.WriteLine(myString);
			Console.ReadLine();
		}
		
	}

	class TestInheritanceBaseClass {
		public void SendToScreen(String myString = "Boo!") {
			Console.WriteLine(myString);
			Console.ReadLine();
		}
	}
}
