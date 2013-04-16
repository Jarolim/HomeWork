using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractHuman
{
	public abstract class Human
	{
		//Fields:
		public string firstName;
		public string lastName;

		//Properties:
		public string FirstName 
		{
			get 
			{
				return this.firstName;
			}
			set 
			{
				this.firstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return this.lastName;
			}
			set
			{
				this.lastName = value;
			}
		}

		//Constructors:
		public Human(string firstName, string lastName)
		{
			if (firstName != string.Empty && firstName.Length >= 2)
			{
				this.firstName = firstName;
			}
			else
			{
				throw new ArgumentException("Name must be atleast 2 chars!");
			}

			if (lastName != string.Empty && lastName.Length >= 2)
			{
				this.lastName = lastName;
			}
			else
			{
				throw new ArgumentException("Name must be atleast 2 chars!");
			}
		}
	}
}
