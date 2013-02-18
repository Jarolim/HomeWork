using System;

class LastNumToWord
{
	/*Write a method that returns the last digit of given integer as an English word. 
	  Examples: 512  "two", 1024  "four", 12309  "nine".*/
	static string[] digitNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

	static string GetDigitName(int n)
	{
		return digitNames[n];
	}

	static int GetLastDigit(int n)
	{
		return n % 10;
	}

	static void Main()
	{
		Console.Write("Enter the digit: ");
		Console.WriteLine(GetDigitName(GetLastDigit(int.Parse(Console.ReadLine()))));
	}
}
