using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay14 {
	class Program {
		static void Main(string[] args)
		{
			Convert.ToInt32(Console.ReadLine());

			int[] a = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

			Difference d = new Difference(a);

			d.computeDifference(a);
			//d.computeDifference();

			Console.Write(d.maximumDifference);
			Console.ReadKey();
		}
	}


	public class Difference {
		private int[] elements;
		public int maximumDifference;

		public Difference()
		{
			for (int i = 0; i < 5; i++) {
				elements[i] = i * 2;
			}
		}
		public Difference(int[] InputArray)
		{
			elements = InputArray;
		}


		public void sortElements()
		{
			Array.Sort(elements);
		}

		public void computeDifference()
		{
			sortElements();

			maximumDifference = Math.Abs(elements[0] - elements[elements.Length - 1]);
		}

		public void computeDifference(int[] InputArray)
		{
			elements = InputArray;
			sortElements();//cheat by sorting first, then you know the first is least and last is greatest

			//for (int FirstIndex = 0; FirstIndex < (elements.Length) - 1; FirstIndex++) {
			//	for (int Index = 1; Index < elements.Length; Index++) {
			//		int result = Math.Abs(elements[FirstIndex] - elements[Index]);
			//		if (result > maximumDifference) {
			//			maximumDifference = result;
			//		}
			//	}
			//}
			maximumDifference = Math.Abs(elements[0] - elements[elements.Length - 1]);
		}
	}
}
