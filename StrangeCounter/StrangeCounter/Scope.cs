using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrangeCounter {
	class Scope {
		private int[] values;
		private int MaxDifference;

		public Scope(int[] Values) {
			//Array.Copy(Values, values, Values.Length);
			values = Values;
			FindDifference();
		}

		public int MaximumDifference { get { return MaxDifference; } }

		public void FindDifference() {
			//assuming values are positive
			Array.Sort(values);
			MaxDifference = Math.Abs(values[0] - values[values.Length - 1]);
		}
	}
}
