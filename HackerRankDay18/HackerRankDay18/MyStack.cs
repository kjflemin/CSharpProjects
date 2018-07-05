using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay18 {
	class MyStack {
		protected Stack<String> stack = new Stack<string>();

		public void Push(String StringToPush)
		{
			stack.Push(StringToPush);
		}

		public String Pop()
		{
			return stack.Pop();
		}
	}
}
