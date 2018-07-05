using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay19 {
	class Jedi {
		public string weapon = "Green Lightsaber";
		public string special = "push";

		public String BaseCharacter {
			get {
				return "Jedi";
			}
		}

		public void Attack()
		{
			Console.WriteLine("Jedi attacking!");
		}

		public void Heal()
		{
			Console.WriteLine("Jedi is healing...");
		}

	}
}
