using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalsHierarchy
{
	class Frog : Animal, ISound
	{
		public Frog(int age, string name, string sex)
			: base(age, name, sex)
		{
		}
		public void MakeSound()
		{
			Console.WriteLine(Name + " says: Gribbit Gribbit.");
		}
	}
}
