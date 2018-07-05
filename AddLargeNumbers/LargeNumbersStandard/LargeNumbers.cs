using System;

namespace LargeNumbers
{
    public class LargeNumbers
    {
		public String AddTwoLargeNumbers(String FirstNumber, String SecondNumber)
		{
			int carry = 0;
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
				throw new Exception("A value is null or empty for the first or second number.");
			}

			//reverse the strings and add left to right
			FirstNumber = ReverseString(FirstNumber);
			SecondNumber = ReverseString(SecondNumber);

			//check for digits only
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
