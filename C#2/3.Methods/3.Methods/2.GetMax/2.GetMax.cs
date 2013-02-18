﻿using System;

class _2GetMax
{
	/*Write a method GetMax() with two parameters that returns the bigger of two integers.
	 Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().*/
	static int GetMax(int a, int b)
	{
		return a > b ? a : b;
	}

	static void Main()
	{
		Console.WriteLine("Pleace enter the 3 numbers:");
		int a = int.Parse(Console.ReadLine());
		int b = int.Parse(Console.ReadLine());
		int c = int.Parse(Console.ReadLine());

		Console.Write("The highest numeber is: ");
		Console.WriteLine(GetMax(GetMax(a, b), c));
	}
}
