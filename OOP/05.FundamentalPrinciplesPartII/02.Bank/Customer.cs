using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

	public abstract class Customer
	{
		//Fields:
		private string name;

		//Properties:
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		//Constructors:
		public Customer(string name)
		{
			this.Name = name;
		}
	}
