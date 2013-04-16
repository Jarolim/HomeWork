using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalsHierarchy
{
	class Cat : Animal , ISound
	{
		public Cat(int age, string name, string sex)
			: base(age, name, sex)
		{
		}
		public void MakeSound()
		{
			Console.WriteLine(Name + " says: Meowwwwww Meowwwwww");
		}
	}
}
