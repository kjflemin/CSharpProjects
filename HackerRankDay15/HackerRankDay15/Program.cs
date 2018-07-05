using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay15 {
	class Program {
		static void Main(string[] args)
		{
			Node head = null;
			int T = Int32.Parse(Console.ReadLine());
			while (T-- > 0) {
				int data = Int32.Parse(Console.ReadLine());
				head = insert(head, data);
			}
			display(head);
		}

		public static void display(Node head)
		{
			Node start = head;
			while (start != null) {
				Console.Write(start.data + " ");
				start = start.next;
			}
		}

		public static Node Insert(Node head, int data)
		{//without recursion and prints backwards
			Node n = new Node(data);
			if (head == null) {
				n.next = head;
				return n;
			}
			else {
				n.next = head;
				return n;//this is the new head
			}
		}

		public static Node insert(Node head, int data)
		{
			// This will handle cases where the head node is empty.
			// Which is just an edge case.
			if (head == null) {
				return new Node(data);
			}

			// This is actual recursion. 
			// We check if the node's next is empty 
			// i.e. the node is the last node or the tail of the LL
			// and if so, add the new node as to it's next. 
			// This is the base case for recurison in the else clause.
			if (head.next == null) {
				head.next = new Node(data);
			}
			else {
				insert(head.next, data);
			}

			return head;

		}
	}



	class Node {
		public int data;
		public Node next;
		public Node(int d)
		{
			data = d;
			next = null;
		}


	}
}
