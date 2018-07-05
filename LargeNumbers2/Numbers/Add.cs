using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers {
	public class Add {

		/// <summary>
		/// Constructors
		/// </summary>
		public Add() {
			carry = 0;
		}

		public Add(int Carry)
		{
			if (Carry == 1 || Carry == 0) {
				carry = Carry;
			}
		}

		//Carry for adding
		private int carry = 0;

		/// <summary>
		/// Getter/Setter for carry
		/// </summary>
		public int Carry {
			get { return carry; }
			set {
				if (value == 1 || value == 0) {
					carry = value;
				}
			}
		}

		/// <summary>
		/// Add 2 large integer values.
		/// </summary>
		/// <param name="FirstNumber">First value to add left of the decimal</param>
		/// <param name="SecondNumber">Second value to add left of the decimal</param>
		/// <returns>Result of added string</returns>
		public String AddTwoLargeNumbers(String FirstNumber, String SecondNumber)
		{
			//int carry = 0;
			int SmallerNumber = 0;
			int LongerNumber = 0;
			if (FirstNumber.Length < SecondNumber.Length) {
				SmallerNumber = FirstNumber.Length;
				LongerNumber = SecondNumber.Length;
			}
			else {
				SmallerNumber = SecondNumber.Length;
				LongerNumber = FirstNumber.Length;
			}

			if (string.IsNullOrWhiteSpace(FirstNumber) || string.IsNullOrWhiteSpace(SecondNumber)) {
				throw new NullReferenceException("Null value detected.");
			}

			//reverse the strings and add left to right
			FirstNumber = ReverseString(FirstNumber);
			SecondNumber = ReverseString(SecondNumber);

			//todo:check for digits only
			//todo:handle negative numbers
			//todo:what about decimals
			String char1;
			String char2;
			int num1 = 0;
			int num2 = 0;
			String Result = string.Empty;

			for (int LenOfString = 0; LenOfString < LongerNumber; LenOfString++) {

				if (LenOfString > FirstNumber.Length - 1) {
					char1 = "0";
				}
				else {
					char1 = FirstNumber.Substring(LenOfString, 1);
				}

				if (LenOfString > SecondNumber.Length - 1) {
					char2 = "0";
				}
				else {
					char2 = SecondNumber.Substring(LenOfString, 1);
				}

				int.TryParse(char1, out num1);
				int.TryParse(char2, out num2);

				int temp = num1 + num2 + carry;
				if (temp >= 10) {
					carry = 1;
					Result += temp.ToString().Substring(1, 1);
				}
				else {
					carry = 0;
					Result += temp.ToString();
				}

				Console.WriteLine(char1 + " " + char2);
			}

			if (carry == 1) {
				Result += carry.ToString();
			}
			Result = ReverseString(Result);

			return Result;
		}

		/// <summary>
		/// Basic reverse a string method
		/// </summary>
		/// <param name="myString">String to reverse</param>
		/// <returns>Reversed String</returns>
		public String ReverseString(String myString)
		{
			if (string.IsNullOrWhiteSpace(myString)) {
				throw new Exception("String is null or empty.");
			}
			char[] charArray = myString.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

	}
}
