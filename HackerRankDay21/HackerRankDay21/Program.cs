using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//generics
namespace HackerRankDay21 {
	class Program {
		static void Main(string[] args)
		{
			int[] a = { 1, 2, 3, 4, 5 };
			String[] b = { "a", "b", "c", "d", "e" };
			PrintArrays p = new PrintArrays();
			Console.WriteLine(p.PrintArray(a));
			Console.WriteLine(p.PrintArray(b));

			int[] c = p.PrintArray(a);
			foreach (var item in c) {
				Console.WriteLine(item);
			}

			String[] d = p.PrintArray(b);
			foreach (var item in d) {
				Console.WriteLine(item);
			}

		}
	}

	public class PrintArrays {

		public T[] PrintArray<T>(T[] myArray)
		{
			foreach (var item in myArray) {
				Console.WriteLine(item);
			}
			Array.Reverse(myArray);
			return myArray;
		}

	}
}
