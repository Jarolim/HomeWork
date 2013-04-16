using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalsHierarchy
{
	class Kitten : Cat
	{
		public Kitten(int age, string name)
			: base(age, name, "Female")
		{
		}
	}
}
