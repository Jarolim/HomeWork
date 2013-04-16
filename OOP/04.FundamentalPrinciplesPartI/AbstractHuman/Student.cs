using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractHuman
{
	public class Student : Human
	{
		//Fields:
		private double grade;

		//Properties:
		public double Grade
		{
			get 
			{
				return this.grade;
			}
			set 
			{
				if (value >= 1 && value <= 12)
				{
					this.grade = value;
				}
				else
				{
					throw new ArgumentException("In school the grades are from 1 to 12!");
				}
			}
		}

		//Constructors:
		public Student(string firstName, string lastName, int grade)
			: base(firstName, lastName) 
		{
			this.Grade = grade;
		}

		//Methods:
		public string GetFirstName()
		{
			return this.FirstName;
		}

		public string GetLastName()
		{
			return this.LastName;
		}

		public override string ToString()
		{
			return string.Format("Hello! My name is {0} {1} and I'm in the {2} grade.",
				GetFirstName(), GetLastName(), this.grade);
		}
	
	}
}
