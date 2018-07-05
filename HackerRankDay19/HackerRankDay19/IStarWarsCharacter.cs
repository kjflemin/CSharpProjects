using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankDay19 {
	public interface IStarWarsCharacter {
		void Attack();
		void Heal();

		String BaseCharacter {
			get;
		}

	}
}
