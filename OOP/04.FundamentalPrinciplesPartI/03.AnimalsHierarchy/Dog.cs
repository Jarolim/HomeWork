using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalsHierarchy
{
	class Dog : Animal, ISound
	{
		public Dog(int age, string name, string sex)
			: base(age, name, sex)
		{
		}
		public void MakeSound()
		{
			Console.WriteLine(Name + " says: Bauuuuu Bauuuuu");
		}
	}
}
