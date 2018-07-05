using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay18 {
	class MyQueue {
		protected Queue<String> q = new Queue<string>(); 

		public void Enqueue(String StringToGoInQueue)
		{
			q.Enqueue(StringToGoInQueue);
		}

		public String Dequeue()
		{
			return q.Dequeue();
		}
	}
}
