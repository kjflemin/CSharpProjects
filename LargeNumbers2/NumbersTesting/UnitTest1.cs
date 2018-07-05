using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numbers;

namespace NumbersTesting {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void Test1()
		{
			Numbers.Add numbers = new Numbers.Add();
			Assert.AreEqual(numbers.AddTwoLargeNumbers("123", "321"), "444");
		}

		[TestMethod]
		public void Test2()
		{
			Numbers.Add numbers = new Numbers.Add();
			Assert.AreEqual(numbers.AddTwoLargeNumbers("1234", "321"), "1555");
		}

		[TestMethod]
		public void Test3()
		{
			Numbers.Add numbers = new Numbers.Add();
			Assert.AreEqual(numbers.AddTwoLargeNumbers("123", "1321"), "1444");
		}

		[TestMethod]
		public void Test4()
		{
			Numbers.Add numbers = new Numbers.Add();
			Assert.AreEqual(numbers.AddTwoLargeNumbers("0", "0"), "0");
		}

		[TestMethod]
		public void Test5()
		{
			Numbers.Add numbers = new Numbers.Add();
			Assert.AreEqual(numbers.AddTwoLargeNumbers("1000000000", "1000000000"), "2000000000");
		}

		[TestMethod]
		public void Test6()
		{
			Numbers.Add numbers = new Numbers.Add();
			Assert.AreEqual(numbers.AddTwoLargeNumbers("1000000000000000000000000000000000000000", "1000000000000000000000000000000000000000"), "2000000000000000000000000000000000000000");
		}

		[TestMethod]
		public void Test7()
		{
			Numbers.Add numbers = new Numbers.Add();
			Assert.AreEqual(numbers.AddTwoLargeNumbers("9999999999", "9999999999"), "19999999998");
		}

		[TestMethod]
		public void Test8()
		{
			Numbers.Add numbers = new Numbers.Add();
			Assert.AreEqual(numbers.AddTwoLargeNumbers("9999999999999999999999999999999999999999", "9999999999999999999999999999999999999999"), "19999999999999999999999999999999999999998");
		}

		[TestMethod]
		public void Test9()
		{
			try {
				Numbers.Add numbers = new Numbers.Add();
				numbers.AddTwoLargeNumbers(null, null);
				Assert.Fail();
			}
			catch (Exception) {

			}

		}

		[TestMethod]
		public void Test10()
		{
			//test getter/setter
			Numbers.Add numbers = new Numbers.Add(1);
			Assert.AreEqual(numbers.Carry,1);
			numbers.Carry = 0;
			Assert.AreEqual(numbers.Carry, 0);
		}

		[TestMethod]
		public void Test11()
		{
			//test constructor
			Numbers.Add numbers = new Numbers.Add(1);
			Assert.AreEqual(numbers.Carry, 1);
			numbers.Carry = 0;
			Assert.AreEqual(numbers.Carry, 0);

			numbers = new Numbers.Add(0);
			Assert.AreEqual(numbers.Carry, 0);
			numbers.Carry = 1;
			Assert.AreEqual(numbers.Carry, 1);
		}

		[TestMethod]
		public void Test12()
		{
			//constructor
			Numbers.Add numbers = new Numbers.Add(5);
			Assert.AreEqual(numbers.Carry, 0);
		}


	}
}
