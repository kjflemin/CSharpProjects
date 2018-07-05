using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay17 {
	class Calculator {
		public int power (int n, int p)
		{
			Double result;
			if ((n <=0) || (p<=0)) {
				throw new ArgumentOutOfRangeException("n and p should be non-negative");
			}
			else {
				try {
					result = Math.Pow(n, p);
				}
				catch (Exception ex) {
					throw new Exception(ex.Message);
				}
			}
			return Convert.ToInt16(result);
		}
	}
}
