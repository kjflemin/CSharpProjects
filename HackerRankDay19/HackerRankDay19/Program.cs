using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay19 {


	class Program {

		//this does not work in C#
		//public static IStarWarsCharacter SummonCharacter()
		//{
		//	Random rand = new Random();
		//	if ((rand.Next() % 2) == 0) {
		//		Jedi j = new Jedi();
		//		return (IStarWarsCharacter)j;
		//	}
		//	else {
		//		Sith s = new Sith();
		//		return (IStarWarsCharacter)s;
		//	}
		//}

		static void Main(string[] args)
		{

			Jedi ObiWan = new Jedi();
			Sith Darth = new Sith();

			Darth.Attack();
			ObiWan.Attack();

			Darth.Heal();
			ObiWan.Heal();

			Console.WriteLine("Darth's weapon: " + Darth.weapon);
			//IStarWarsCharacter spy = SummonCharacter();
			//spy.Attack();
			//spy.Heal();


		}
	}
}
