using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay20 {
	class Program {
		static void Main(string[] args)
		{
			//sorting arrays
			int[] myIntArray = { 5, 4, 3, 2, 1 };
			String[] myStringArray = { "five","four","three","two","one" };

			Array.Sort(myIntArray);
			Array.Sort(myStringArray);


		}
	}
}


//traditional bubble sort
//for (int i = 0; i<n; i++) {
//    // Track number of elements swapped during a single array traversal
//    int numberOfSwaps = 0;
    
//    for (int j = 0; j<n - 1; j++) {
//        // Swap adjacent elements if they are in decreasing order
//        if (a[j] > a[j + 1]) {

//			swap(a[j], a[j + 1]);
//numberOfSwaps++;
//        }
//    }
    
//    // If no elements were swapped during a traversal, array is sorted
//    if (numberOfSwaps == 0) {
//        break;
//    }
//}
