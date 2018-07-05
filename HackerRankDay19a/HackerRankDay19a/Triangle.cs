using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay19a {
	class Triangle : Polygon {

		//all sides the same for equilateral
		public int Sides {
			get;
			set;
		}

		//private int side1;
		//private int side2;
		//private int side3;

		public double FindArea()
		{
			return ((.5*Sides)*Sides);
		}

		public double FindPerimeter()
		{
			return 0;
		}

		public bool IsTriangle()
		{
			return true;
		}
	}
}
