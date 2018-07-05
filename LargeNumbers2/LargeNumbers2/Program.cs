using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numbers;

namespace LargeNumbers2 {
	class Program {
		static void Main(string[] args)
		{
			Add AddingNumbers = new Add();
			String ret = AddingNumbers.AddTwoLargeNumbers("123", "123");
		}
	}
}
