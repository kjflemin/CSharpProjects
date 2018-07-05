using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay18 {
	class Program {
		static void Main(string[] args)
		{
			Queue<String> q = new Queue<string>();
			Stack<String> s = new Stack<string>();
			String val1 = String.Empty;
			String val2 = String.Empty;
			String InputString = "abccba";

			foreach (var item in InputString) {
				q.Enqueue(item.ToString());
				s.Push(item.ToString());
			}

			for (int cnt = 0; cnt < q.Count; cnt++) {
				val1 = q.Dequeue() ;
				val2 = s.Pop();
				if (!val1.Equals(val2)) {
					Console.WriteLine("Not a Palendrome: {0},{1}", val1, val2);
					break;
				}
			}
			Console.WriteLine(InputString);
		}
	}
}
