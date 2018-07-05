using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay19a {
	interface Polygon {

		int Sides { get; set; }

		double FindArea();
		double FindPerimeter();

		bool IsTriangle();
	}
}
