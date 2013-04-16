using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Define a class InvalidRangeException<T> that holds information about 
  an error condition related to invalid range. It should hold error 
  message and a range definition [start … end].
	Write a sample application that demonstrates the 
  InvalidRangeException<int> and InvalidRangeException<DateTime> 
  by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].*/
namespace _03.InvalidRangeExeption
{
	class TestInvalidRangeExeption
	{
		static void Main(string[] args)
		{
			//Testing the integer exeption:
			InvalidRangeExeption<int> IntExeption =
			new InvalidRangeExeption<int>("The must enter a number in the range from 0 do 100! Its not cool if you dont!", 0, 100);
			Console.WriteLine("Input 3 numbers from 0 do 100:");
			for (int i = 0; i < 3; i++)
			{
				int number = int.Parse(Console.ReadLine());
				if (number < IntExeption.Start || number > IntExeption.End)
				{
					throw IntExeption;
				}
				else
				{
					if ((3 - (i + 1)) == 0)
					{
						Console.WriteLine("You are good!");
					}
					else 
					{ 
						Console.WriteLine("Go on! Your number is cool. {0} more!", 3 - (i + 1));
					} 					
				}
			}

			//Testing the date exeption:
			string startDate = "1.1.1980";
			string endDate = "1.1.2013";
			InvalidRangeExeption<DateTime> DateExpection =
			new InvalidRangeExeption<DateTime>("You must input a date in the range from 1980 to 2013!", DateTime.Parse(startDate), DateTime.Parse(endDate));
			Console.WriteLine("Input 3 dates (between 1980 to 2013 year) in the format: dd.mm.yyyy!");
			for (int i = 0; i < 3; i++)
			{
				string date = Console.ReadLine();
				DateTime someDate = DateTime.Parse(date);
				if (someDate.Year < DateExpection.Start.Year || someDate.Year > DateExpection.End.Year)
				{
					throw DateExpection;
				}
				else
				{
					if ((3 - (i + 1)) == 0)
					{
						Console.WriteLine("You are superb! Bye Bye.");
					}
					else
					{
						Console.WriteLine("Go on! Your date is cool. {0} more!", 3 - (i + 1));
					}
				}
			}
		}
	}
}
