using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrangeCounter {
	class Program {
		static void Main(string[] args) {

			// Hacker Rank Code for 30 days
			HackerRank HackRank = new HackerRank();

			#region Days 11-15

			#region Day 14 - Scope
			int val;
			int[] val1 = new int[] { 1, 2, 5 };
			Scope s1 = new Scope(val1);
			val = s1.MaximumDifference;

			int[] val2 = new int[] { 2, 2, 9, 15, 22 };
			Scope s2 = new Scope(val2);
			val = s2.MaximumDifference;
			#endregion Day 14 - Scope


			#region Day 13 - abstract inheritance
			/*Task
			 * Create an abstract class Book that has a method left undefined. Create 2
			 * other classes that will implement the undefined method.
			 */
			KeithsBookOne b1 = new KeithsBookOne("1", "1", "1");
			b1.PrintBookInformation();
			KeithsBookTwo b2 = new KeithsBookTwo("2", "2", "2");
			b2.PrintBookInformation();
			Console.ReadLine();
			Console.Clear();
			#endregion Day 13 - abstract inheritance

			HackRank.Day12_Inheritance();

			HackRank.Day11_HourGlassSum();
			#endregion Days 11-15

			#region Days 1-10
			//Hacker Rank Day 10
			Console.Clear();
			HackRank.FlipSwitch(1, 0);
			HackRank.FlipSwitch(2, 0);
			HackRank.FlipSwitch(3, 0);
			HackRank.FlipSwitch(4, 0);
			HackRank.FlipSwitch(1, 15);
			Console.Clear();

			HackRank.Swap2VarsWithXOR(5, 10);

			HackRank.LogicCharts();
			List<String> BinaryNumber = HackRank.Day10_BinaryNumbersBase10ToBase2(8);

			HackerRankExtras HRExtras = new HackerRankExtras();
			int ret = HRExtras.GetResultForStrangeCounter(100);
			HRExtras.PrintArrayOfIntegersAndSum();

			//Hacker Rank Day 2
			HackRank.TipCalculator("402.13", "22", "14");

			//Hacker Rank Day 3 (Fizz Buzz modification)
			Console.Clear();
			HackRank.ShowWierdNumbers();

			//Day 4
			//Class vs instance
			#region day 4
			Person p = new Person(10);
			p.AmIOld();
			p.YearPasses(2);
			p.AmIOld();
			p.YearPasses();
			p.AmIOld();
			p.YearPasses(4);
			p.AmIOld();
			p.YearPasses();
			p.AmIOld();
			#endregion day 4

			//Day 5
			Console.Clear();
			HackRank.PrintMultiplicationTableForGivenValue(7);
			Console.ReadLine();

			//Day 6
			HackRank.Day6_MixedStrings();
			Console.ReadLine();

			//Day 7
			HackRank.Day7_ReverseAString();
			Console.ReadLine();

			//Day 8
			HackRank.Day8_DictionariesAndMaps();
			HackRank.Day8_DictionariesAndMaps("Nicole");
			HackRank.Day8_DictionariesAndMaps("nicole");
			Console.ReadLine();
			//Day 9
			int Result = HackRank.Day9_GiveFactorialOfANumberRecursively(3);
			Result = HackRank.Day9_GiveFactorialOfANumberRecursively(4);
			Result = HackRank.Day9_GiveFactorialOfANumberRecursively(5);

			#endregion Days 1-10

			//testing inheritance
			TestInheritanceClass myclass = new TestInheritanceClass();
			myclass.WriteToScreen();
			myclass.SendToScreen();
		}
	}

	class Person {
		int _Age;
		public Person(int InitialAge) {
			if (InitialAge > 0) {
				_Age = InitialAge;
			} else {
				_Age = 0;
				Console.WriteLine("Initial Age is not valid > " + InitialAge + ". Age has been set to 0.");
			}
		}

		public void YearPasses(int Years) {
			_Age = _Age + Years;
		}
		public void YearPasses() {
			_Age++;
		}

		public void AmIOld() {
			if (_Age < 13) {
				Console.Write("You are young.");
			} else if ((_Age >= 13) && (_Age < 18)) {
				Console.Write("You are a teenager.");
			} else {
				Console.Write("You are old.");
			}
			Console.WriteLine(" " + _Age);
		}
	}

	/// <summary>
	/// Hacker Rank Challenges
	/// </summary>



	class HackerRankExtras {

		public void PrintArrayOfIntegersAndSum() {
			/*
			 * Given a string of integers print how many are in the array,
			 * the array of numbers, and the sum of all the integers in the array.
			 */
			Random r = new Random();
			int RandNumber = r.Next(1, 100);
			List<int> NumberList = new List<int>();
			Console.Write(RandNumber + ":: ");

			for (int cnt = 0; cnt < RandNumber; cnt++) {
				NumberList.Add(r.Next(1, 25));
				//add sleep so you do not get dup numbers
				System.Threading.Thread.Sleep(50);
			}

			int SumOfIntegers = 0;
			for (int cnt = 0; cnt < RandNumber; cnt++) {
				SumOfIntegers += NumberList[cnt];
				Console.Write(NumberList[cnt] + " ");
			}
			Console.WriteLine("= " + SumOfIntegers);
		}

		public int GetResultForStrangeCounter(int TimeValueToRetrieve) {
			#region description
			/*
 * Bob has a strange counter. At the first second, t=1, it displays the number 3. At each 
 * subsequent second, the number displayed by the counter decrements by 1. 

	The counter counts down in cycles. In the second after the counter counts down to 1, the 
	number becomes 2X the initial number for that countdown cycle and then continues counting 
	down from the new initial number in a new cycle. The diagram below shows the counter 
	values for each time  in the first three cycles:
	1  3        4  6        10  12
	2  2        5  5        11  11
	3  1        6  4        12  10
				7  3        ...
				8  2        21  1
				9  1
	*/
			#endregion description

			int CycleValue = 3;
			int TimeValue = 1;
			int NewCycleValue = CycleValue;

			do {

				for (int cnt = 0; cnt < NewCycleValue; cnt++) {
					Console.WriteLine("{0}   {1}", TimeValue, CycleValue);
					if (TimeValue == TimeValueToRetrieve) {
						return CycleValue;
					}
					TimeValue++;
					CycleValue--;
				}
				Console.WriteLine("---------");
				NewCycleValue *= 2;
				CycleValue = NewCycleValue;
			} while (TimeValue < int.MaxValue);
			return -1;
		}
	}
}
