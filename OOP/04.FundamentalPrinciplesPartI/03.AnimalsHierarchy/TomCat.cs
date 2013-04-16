using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalsHierarchy
{
	class TomCat : Cat
	{
		public TomCat(int age, string name)
			: base(age, name, "Male")
		{
		}
	}
}
