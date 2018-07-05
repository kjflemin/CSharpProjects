using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrangeCounter {


	class HackerRank {

		public void Day12_Inheritance() {
			/*
			Task 
			You are given two classes, Person and Student, where Person is the base class 
			and Student is the derived class. Completed code for Person and a declaration 
			for Student are provided for you in the editor. Observe that Student inherits 
			all the properties of Person.

			Complete the Student class by writing the following:
			1.A Student class constructor, which has 4 parameters: 
				1.A string, first name.
				2.A string, last name.
				3.An integer, id.
				4.An integer array (or vector) of test scores.

			A string calculate() method that calculates a Student object's average and 
			returns the grade character representative of their calculated average 90+=A etc.

			Sample Input
			Taken from the constructor

			Sample Output
			Name: Memelli, Heraldo
			ID: 8135627
			Grade: O

			*/
			int[] TestScores = { 123, 40, 99, 100, 100, 95 };
			Student Student_A = new Student("Fleming", "Keith", 7, TestScores);
			String Grade = Student_A.CalculateScores();
			Student_A.printPerson();
			Console.WriteLine("Your grade is: {0}", Student_A.CalculateScores());

		}

		public void Day11_HourGlassSum() {
			/*
			 * Given a 2D array with equal length and width >= 3x3 give the largest hourglass sum
			 * An hourglass is defined by
			 *   x x x
			 *     x
			 *   x x x
			 *   where x is an int value
			 *   
			 *   A 2D array could be defined as
			 *   x x x
			 *   x x x
			 *   x x x
			 *   or
			 *   x x x x x x
			 *   x x x x x x
			 *   x x x x x x
			 *   x x x x x x
			 *   x x x x x x
			 *   x x x x x x
			 */
			int[,] array1 = {
				{1,2,3 },
				{2,3,4 },
				{3,4,5 }
				};

			int[,] array2 = {
				{1,2,3,4,5,6 },
				{2,3,4,5,6,7 },
				{3,4,5,6,7,8 },
				{8,7,6,5,4,3 },
				{1,3,6,7,9,0 },
				{0,1,9,9,9,1 }
				};

			int HourGlassSum = 0;
			String Location = string.Empty;
			//int val = array2.GetLength(0);
			for (int Row = 0; Row <= (array2.GetLength(0) - 3); Row++) {//march along the top
				for (int Col = 0; Col <= (array2.GetLength(1) - 3); Col++) {
					//get the sum
					int sum = array2[Row, Col] + array2[Row + 1, Col] + array2[Row + 2, Col];
					sum = sum + array2[Row + 1, Col + 1];
					sum = sum + array2[Row, Col + 2] + array2[Row + 1, Col + 2] + array2[Row + 2, Col + 2];
					if (sum > HourGlassSum) {
						HourGlassSum = sum;
						Location = Row.ToString() + "," + Col.ToString();
					}
				}
			}
		}

		public int FlipSwitch(int Switch, int CurrentState) {
			Console.WriteLine("Current State > {0}", Convert.ToString(CurrentState, 2));
			switch (Switch) {
				case 1:
					CurrentState = 1 ^ CurrentState;
					Console.WriteLine("Flip Switch 1 > New State > {0}", Convert.ToString(CurrentState, 2));
					break;
				case 2:
					CurrentState = 2 ^ CurrentState;
					Console.WriteLine("Flip Switch 2 > New State > {0}", Convert.ToString(CurrentState, 2));
					break;
				case 3:
					CurrentState = 4 ^ CurrentState;
					Console.WriteLine("Flip Switch 3 > New State > {0}", Convert.ToString(CurrentState, 2));
					break;
				case 4:
					CurrentState = 8 ^ CurrentState;
					Console.WriteLine("Flip Switch 4 > New State > {0}", Convert.ToString(CurrentState, 2));
					break;
				default:
					Console.WriteLine("Invalid Switch (1-4 only)");
					break;
			}
			return CurrentState;
		}

		public void Swap2VarsWithXOR(int a, int b) {
			Console.Clear();
			List<String> Binary = Day10_BinaryNumbersBase10ToBase2(a);
			String c = Binary[0];
			Binary.Clear();
			Binary = Day10_BinaryNumbersBase10ToBase2(b);
			String d = Binary[0];

			Console.WriteLine("             A={0} B={1}   Binary A={2} B={3}", a, b, c, d);

			a = a ^ b;
			Binary.Clear();
			Binary = Day10_BinaryNumbersBase10ToBase2(a);
			c = Binary[0];
			Binary = Day10_BinaryNumbersBase10ToBase2(b);
			d = Binary[0];
			Console.WriteLine("A = A XOR B  A>{0} B>{1}   Binary A={2} B={3}", a, b, c, d);

			b = b ^ a;
			Binary.Clear();
			Binary = Day10_BinaryNumbersBase10ToBase2(a);
			c = Binary[0];
			Binary = Day10_BinaryNumbersBase10ToBase2(b);
			d = Binary[0];
			Console.WriteLine("B = B XOR A  A>{0} B>{1}   Binary A={2} B={3}", a, b, c, d);

			a = a ^ b;
			Binary.Clear();
			Binary = Day10_BinaryNumbersBase10ToBase2(a);
			c = Binary[0];
			Binary = Day10_BinaryNumbersBase10ToBase2(b);
			d = Binary[0];
			Console.WriteLine("A = A XOR B  A>{0} B>{1}   Binary A={2} B={3}", a, b, c, d);
		}

		public void LogicCharts() {
			Console.Clear();
			//opposed to logical || &&  - will short-circuit
			Console.WriteLine("Bitwise compare ( | & ) using true and false. Bitwise does not short-circuit.\n\n");

			Console.WriteLine("OR");
			Console.WriteLine("   |   0    |   1 ");
			Console.WriteLine(" 0 | {0,-6} | {1,-6}", false | false, false | true);
			Console.WriteLine(" 1 | {0,-6} | {1,-6}\n", true | false, true | true);

			Console.WriteLine("XOR");
			Console.WriteLine("   |   0    |   1 ");
			Console.WriteLine(" 0 | {0,-6} | {1,-6}", false ^ false, false ^ true);
			Console.WriteLine(" 1 | {0,-6} | {1,-6}\n", true ^ false, true ^ true);

			Console.WriteLine("AND");
			Console.WriteLine("   |   0    |   1 ");
			Console.WriteLine(" 0 | {0,-6} | {1,-6}", false & false, false & true);
			Console.WriteLine(" 1 | {0,-6} | {1,-6}\n", true & false, true & true);
		}

		public List<String> Day10_BinaryNumbersBase10ToBase2(int NumberToConvert) {
			/*
			 * Given a base-10 integer, n, convert it to binary (base-2). 
			 * Then find and print the base-10 integer denoting the 
			 * maximum number of consecutive 1's in n's binary representation. 
			 * 
			 */

			//use the string method
			List<String> ReturnVals = new List<string>();
			ReturnVals.Add(Convert.ToString(NumberToConvert, 2));

			//use the division method and a handy reverse method overload
			String remainder = string.Empty;
			while (NumberToConvert > 0) {
				remainder += NumberToConvert % 2;
				NumberToConvert /= 2;
			}
			ReturnVals.Add(remainder.Reverse());

			//manually reverse the string to return
			String reversed = "";
			for (int i = remainder.Length - 1; i >= 0; i--) {
				reversed += remainder[i];
			}

			ReturnVals.Add(reversed);
			return ReturnVals;
		}

		public int Day9_GiveFactorialOfANumberRecursively(int Number) {
			/*
			 * Write a factorial function that takes a positive integer, 
			 * N as a parameter and prints the result of N! (N factorial).
			 */

			int Result = Number;
			if (Number >= 2) {
				Result *= Day9_GiveFactorialOfANumberRecursively(Number - 1);
			}
			return Result;
		}

		public void Day8_DictionariesAndMaps(String NameToFind = "Keith") {
			/*
			 * Given n names and phone numbers, assemble a phone book that maps 
			 * friends' names to their respective phone numbers. You will then 
			 * be given an unknown number of names to query your phone book for. 
			 * For each name queried, print the associated entry from your phone 
			 * book on a new line in the form name=phoneNumber; if an entry for 
			 * name is not found, print Not found instead.
			 */
			Dictionary<String, String> PhoneBook = new Dictionary<string, string>()
			{
				{ "Mary","111-1111"},
				{ "Pete","222-2222"},
				{ "Zack","333-3333"},
				{ "Nicole","444-4444"}
			};
			//
			bool keyfound = PhoneBook.ContainsKey(NameToFind);
			if (keyfound) {
				Console.WriteLine("{0},{1}", NameToFind, PhoneBook[NameToFind]);
			} else {
				Console.WriteLine("Not Found");
			}

			Console.WriteLine("<><><>");
			//iterate till you find a name and print it
			bool found = false;
			foreach (var item in PhoneBook) {
				if (item.Key == NameToFind) {
					Console.WriteLine(item.Key + "=" + item.Value);
					found = true;
					break;
				}
			}
			if (!found) {
				Console.WriteLine("Not Found");
			}
		}

		public void Day7_ReverseAString(String OriginalString = "Hacker Rank") {
			String Reverse1 = "";

			for (int cnt = OriginalString.Length; cnt >= 1; cnt--) {
				Reverse1 += OriginalString.Substring(cnt - 1, 1);
			}

			String Reverse2 = new String(OriginalString.ToCharArray().Reverse().ToArray());

			String Reverse3 = "";
			char[] Rev3 = OriginalString.ToArray();
			for (int cnt = OriginalString.Length; cnt >= 1; cnt--) {
				Reverse3 += Rev3[cnt - 1];
			}

			Console.WriteLine("Reversed Strings >{0},{1},{2}", Reverse1, Reverse2, Reverse3);
		}

		public void Day6_MixedStrings(String OriginalString = "HackerRank") {
			/*
				 Given a string, S, of length N that is indexed from 0 to N-1, 
				 print its even-indexed and odd-indexed characters as  space-separated 
				 strings on a single line (see the Sample below for more detail). 

				Hacker
				Rank

				Hce akr
				Rn ak
			*/
			String first = string.Empty;
			String second = string.Empty;
			for (int cnt = 0; cnt < OriginalString.Length; cnt++) {
				if (OriginalString.Substring(cnt, 1) == " ") {
					cnt++;
				} else {
					if ((cnt % 2) == 0) {
						first += OriginalString.Substring(cnt, 1);
					} else {
						second += OriginalString.Substring(cnt, 1);
					}
				}
			}
			Console.WriteLine("\n{2}\n>{0} >{1}\n", first, second, OriginalString);
		}

		public void PrintMultiplicationTableForGivenValue(int Value) {
			List<int> myList = new List<int>();
			int counter = 0;

			Console.WriteLine("For");
			for (int cnt = 0; cnt < 13; cnt++) {
				Console.WriteLine(Value + " * " + cnt + " = {0}", cnt * Value);
				myList.Add(cnt);
			}
			Console.ReadLine();

			Console.WriteLine("Foreach");
			foreach (var item in myList) {
				Console.WriteLine(Value + " * " + item.ToString() + " = {0}", Value * (int)item);
			}

			Console.WriteLine("do");
			do {
				Console.WriteLine(Value + " * " + counter + " = {0}", counter * Value);
				counter++;
			} while (counter < 13);
			counter = 0;

			Console.WriteLine("while");
			while (counter < 13) {
				Console.WriteLine(Value + " * " + counter + " = {0}", counter * Value);
				counter++;
			}
		}

		public void ShowWierdNumbers(int LastValue = 25) {
			/*
			 * Task: Given an integer 0 <= n <= 100, perform the following conditional actions:
				If n is odd, print Weird
				If n is even and in the inclusive range of 2 to 5, print Not Weird
				If n is even and in the inclusive range of 6 to 20, print Weird
				If n is even and greater than 20, print Not Weird
			 */
			for (int cnt = 1; cnt <= LastValue; cnt++) {
				Boolean WeirdFlag = true;
				Console.Write(cnt + ":");
				if ((cnt % 1) == 0) {
					//Console.Write("Weird");
					WeirdFlag = true;
				}
				if (((cnt % 2) == 0) && ((cnt >= 2) && (cnt <= 5))) {
					//Console.Write(" Not Weird");
					WeirdFlag = false;
				}
				if (((cnt % 2) == 0) && ((cnt >= 6) && (cnt <= 20))) {
					//Console.Write(" Weird");
					WeirdFlag = true;
				}
				if (((cnt % 2) == 0) && ((cnt > 20))) {
					//Console.Write(" Not Weird");
					WeirdFlag = false;
				}

				if (WeirdFlag) {
					Console.Write("Weird");
				} else {
					Console.Write("Not Weird");
				}
				Console.WriteLine();
			}
		}

		public void TipCalculator(String Cost = "10.25", String Tax = "8", String TipPercent = "10") {
			/*
				Task 
				 Given the meal price (base cost of a meal), tip percent (the percentage of the meal price being added as tip), 
				 and tax percent (the percentage of the meal price being added as tax) for a meal, find and print the meal's total cost. 

				Note: Be sure to use precise values for your calculations, or you may end up with an incorrectly rounded result!

				Input Format
				 There are 3 inputs cost tax percent. 

				Output Format


				Print The total meal cost, where the cost is the rounded integer result of the entire bill (with added tax and tip).
			*/

			Double cost;
			Double tax;
			Double tip;

			double.TryParse(Cost, out cost);
			double.TryParse(Tax, out tax);
			double.TryParse(TipPercent, out tip);

			decimal taxAmt = (decimal)(cost * (tax * .01));
			decimal tipAmt = (decimal)(cost * (tip * .01));

			decimal TotalAmt = taxAmt + tipAmt + (decimal)cost;
			//this rounds
			TotalAmt = Math.Round(TotalAmt, 2);
			//the {0:C} rounds and changes to currency adding $ for you. The below example shows both.
			Console.WriteLine("Cost={0:C}  Tip={1}%  Tax={2}%  Total=${3}", cost, tip, tax, TotalAmt);
		}
	}

	public abstract class Book {
		private String _name;
		private String _title;
		private String _number;

		//Constructor
		public Book(String name, String title, String mynumber) {
			this._name = name;
			this._title = title;
			this._number = mynumber;
		}

		//method must be defined in sub-class
		abstract public String GetLastParameter();

		public void PrintBookInformation() {
			Console.WriteLine("{0},{1},{2},{3}", _name, _title, _number, GetLastParameter());
		}
	}

	public class KeithsBookOne : Book {

		private String _BookName;
		private String _BookTitle;
		private String _ISBN;

		public KeithsBookOne(String BookName, String BookTitle, String ISBN) : base(BookName, BookTitle, ISBN) {
			this._BookName = BookName;
			this._BookTitle = BookTitle;
			this._ISBN = ISBN;	
		}

		//abstract method implementation
		public override String GetLastParameter() {
			return "Last Parameter";
		}
	}

	public class KeithsBookTwo : Book {

		private String _BookName;
		private String _BookTitle;
		private String _ISBN;

		//Here is an example of how a constructor can be used to populate an inherited
		//classes constructor
		public KeithsBookTwo(String BookName, String BookTitle, String ISBN) : base(BookName, BookTitle, ISBN) {
			this._BookName = BookName;
			this._BookTitle = BookTitle;
			this._ISBN = ISBN;
		}

		public override String GetLastParameter() {
			return "Very Last Parameter";
		}
	}

	static class StringExtensions {
		public static string Reverse(this string input) {
			return new string(input.ToCharArray().Reverse().ToArray());
		}
	}

	class StudentBase {
		protected string firstName;
		protected string lastName;
		protected int id;

		public StudentBase() { }
		public StudentBase(string firstName, string lastName, int identification) {
			this.firstName = firstName;
			this.lastName = lastName;
			this.id = identification;
		}
		public void printPerson() {
			Console.WriteLine("Name: " + lastName + ", " + firstName + "\nID: " + id);
		}
	}

	class Student : StudentBase {
		//I did not add any validation
		private int[] testScores;

		public Student() { //set defaults in here 
		}

		public Student(String Fname, String Lname, int StudentID, int[] Scores) {
			testScores = Scores;
			firstName = Fname;
			lastName = Lname;
			id = StudentID;
		}

		public String CalculateScores() {
			int sum = 0;
			foreach (var score in testScores) {
				sum += score;
			}
			int total = (sum / testScores.Length);

			if (total > 90) {
				return "A";
			} else if (total > 80) {
				return "B";
			} else if (total > 70) {
				return "C";
			} else if (total > 60) {
				return "D";
			} else {
				return "F";
			}
		}

	}


}
