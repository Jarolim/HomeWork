using System;
using System.Collections.Generic;

class DecimalToBinary
{
	static void Main()
	{
		/* Write a program to convert decimal numbers to their binary representation.*/
		Console.Write("Enter the number in Decimal: ");
		int number = int.Parse(Console.ReadLine());
		List<int> inBinary = new List<int>();
		while (number > 0)
		{
			inBinary.Add(number % 2);
			number = number / 2;
		}
		inBinary.Reverse();
		Console.Write("The number in Binary is: ");
		for (int i = 0; i < inBinary.Count; i++)
		{
			Console.Write("{0}", inBinary[i]);
		}
		Console.WriteLine();
	}
}
