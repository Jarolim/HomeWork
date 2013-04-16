using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolWithAClassDiagram
{
	public class School
	{
		//Fields
		private List<ClassRoom> classes;

		//Properties:
		public ClassRoom[] Classes
		{
			get
			{
				return this.classes.ToArray();
			}
			private set
			{
			}
		}

		//Constructors:
		public School(ClassRoom[] classes)
		{
			this.classes = new List<ClassRoom>(classes);
		}

		//Methods:
		public void AddClass(ClassRoom classes)
		{
			this.classes.Add(classes);
		}

		public void RemoveClass(ClassRoom classes)
		{
			this.classes.Remove(classes);
		}
	}
}
