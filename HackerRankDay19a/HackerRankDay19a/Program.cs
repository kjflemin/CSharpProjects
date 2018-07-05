using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay19a {
	class Program {
		static void Main(string[] args)
		{
			Triangle t = new Triangle();
			t.Sides = 5;
			double area = t.FindArea();

			Console.WriteLine("Side length = " + t.Sides + " Area= " + area);
			Console.ReadKey();

		}
	}
}
