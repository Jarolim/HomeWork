using System;

class LeapYearDateTime
{
	static void Main()
	{
		/*Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.*/
		Console.Write("Please enter year: ");
		int Year = int.Parse(Console.ReadLine());
		Console.WriteLine(DateTime.IsLeapYear(Year) ? "It's a leap year!" : "It's not a leap year.");
	}
}
