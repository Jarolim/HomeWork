using System;

class WhichDayOfWeek
{
	static void Main(string[] args)
	{
		/*Write a program that prints to the console which day of the week is today. Use System.DateTime.*/
		DateTime today = DateTime.Now;
		object dayOfWeek = today.DayOfWeek;
		Console.WriteLine("Today is {0}!", dayOfWeek);
	}
}

