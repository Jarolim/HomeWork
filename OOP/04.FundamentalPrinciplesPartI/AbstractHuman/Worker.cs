using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractHuman
{
	public class Worker : Human
	{
		//Fields:
		private double weekSalary;
		private double workHoursPerDay;

		//Properties:
		public double WeekSalary
		{
			get 
			{
				return this.weekSalary;
			}
			set
			{
				if (value > 0)
				{
					this.weekSalary = value;
				}
				else
				{
					throw new ArgumentException("We want to give money ... not take!");
				}

			}
		}

		public double WorkHoursPerDay
		{
			get 
			{ 
				return this.workHoursPerDay; 
			}
			set
			{
				if (value > 0 && value < 15)
				{
					this.workHoursPerDay = value;
				}
				else
				{
					throw new ArgumentException("The dude must sleep!");
				}
			}
		}

		//Constructors:

		public Worker(string firstName , string lastName , double weekSalary , int workHoursPedDay)
			: base(firstName, lastName)
		{
			this.WeekSalary = weekSalary;
			this.WorkHoursPerDay = workHoursPedDay;
		}

		//Methods:
		public double MoneyPerHour()
		{
			return this.weekSalary / (this.workHoursPerDay * 5);
		}

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
			return string.Format("Hello! My name is {0} {1}.\nI work 5 days a week for {3} hours. My week salary is : {4}\n My salary per hour is {2:F2}.",
				GetFirstName(), GetLastName(), MoneyPerHour(), workHoursPerDay, weekSalary);
		}
	}
}
