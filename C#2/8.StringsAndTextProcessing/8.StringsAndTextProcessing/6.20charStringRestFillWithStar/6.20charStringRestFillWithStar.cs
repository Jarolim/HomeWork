﻿using System;

class _20charStringRestFillWithStar
{
	static void Main()
	{
		/*Write a program that reads from the console a string of maximum 20 characters. 
		  If the length of the string is less than 20, the rest of the characters should be filled with '*'.
		  Print the result string into the console.*/
		Console.Write("Input the string: ");
		string str = Console.ReadLine();
		int maxChars = 20;

		if (str.Length <= maxChars) 
		{
			Console.WriteLine(str.PadRight(maxChars, '*'));
		}
	}
}