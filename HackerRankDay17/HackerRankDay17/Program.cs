using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay17 {
	class Program {
		static void Main(string[] args)
		{
			Calculator myCalculator = new Calculator();
			int T = Int32.Parse(Console.ReadLine());
			while (T-- > 0) {
				string[] num = Console.ReadLine().Split();
				int n = int.Parse(num[0]);
				int p = int.Parse(num[1]);
				try {
					int ans = myCalculator.power(n, p);
					Console.WriteLine(ans);
				}
				catch (Exception e) {
					Console.WriteLine(e.Message);

				}
			}
		}
	}
}
