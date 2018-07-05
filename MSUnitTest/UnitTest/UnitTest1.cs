using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.Common;
using Microsoft.VisualStudio.TestTools.Utility;
using UnitTest;
using MSUnitTest;

namespace UnitTest {
	[TestClass]
	public class UnitTest1 {
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void TestMethod1() {
			MainSimpleClass sc = new MainSimpleClass();
			myAssert.isTrue(false);
		}
	}

	//wrapping assert makes it so I can use any assertion framework I want and the user does not care
	//if the assertion framework is not what we like, we change it in one place...
	public static class myAssert {//make this any name we want
		public static void isTrue(bool value) {//make this method look like anything we want
			try {
				Assert.IsTrue(value);
				//log to database
				//we have the power to log far more info than just what the assert gives us
				ProcessResults(TestContext, CustomMessage, "Pass");
			} catch (System.Exception ex) {
				//add test context information
				//log to database
				//anything else we want here
				ProcessResults(TestContext, CustomMessage, "Fail", ex);
				throw new Exception(ex.Message);
			}

		}
	}
}
