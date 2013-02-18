using System;
using System.Collections.Generic;

class AreBracketsPutCorrectly
{
	static void Main()
	{
		/*Write a program to check if in a given expression the brackets are put correctly.
			Example of correct expression: ((a+b)/5-d).
			Example of incorrect expression: )(a+b)).*/
		Console.Write("Input expression: ");
		string input = Console.ReadLine();
		List<char> bracket = new List<char>();
		foreach (char item in input)
		{
			if (item == '(')
			{
				bracket.Add(item);
			}
			else if (item == ')')
			{
				if (bracket.Count > 0)
				{
					bracket.Remove('(');
				}
				else
				{
					Console.WriteLine("Incorrect expression");
					return;
				}
			}
		}
		if (bracket.Count == 0)
		{
			Console.WriteLine("Correct expression");
		}
		else
		{
			Console.WriteLine("Incorrect expression");
		}
	}
}
