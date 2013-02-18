﻿using System;

class PrintAsHexPercentageScience
{
	static void Main()
	{
		/*Write a program that reads a number and prints it as a decimal number, hexadecimal number, 
		  percentage and in scientific notation. Format the output aligned right in 15 symbols.*/
		Console.Write("Enter your number: ");
		int number = int.Parse(Console.ReadLine());

		Console.WriteLine("{0,15} in Decimal", number);

		Console.WriteLine("{0,15:X} in Hexadecimal", number); 

		Console.WriteLine("{0,15:P} as a percentage", number);

		Console.WriteLine("{0,15:E} as a scientific notation", number);
	}
}
