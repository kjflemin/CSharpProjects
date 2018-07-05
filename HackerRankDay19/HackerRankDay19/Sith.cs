using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay19 {
	class Sith : IStarWarsCharacter {
		public string weapon = "Red Lightsaber";
		public string special = "choke";

		public String BaseCharacter {
			get {
				return "Sith";
			}
		}

		public void Attack() {
			Console.WriteLine("Sith attacking!");
		}

		public void Heal() {
			Console.WriteLine("Sith is healing...");
		}


	}
}
