using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryClock {
	class Program {
		static void Main(string[] args)
		{

			BinaryClock b = new BinaryClock();

			do {
				b.DisplayHours();
				b.DisplayMinutes();
				b.DisplaySeconds();
				Thread.Sleep(1000);
			} while (true);
			
		}
	}
}
