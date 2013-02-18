using System;

class ReverseString
{
	static void Main()
	{
		/*Write a program that reads a string, reverses it and prints the result at the console.
		  Example: "sample"  "elpmas".*/
		Console.Write("Input string: ");
		char[] input = Console.ReadLine().ToCharArray();

		Array.Reverse(input);

		Console.Write("The reversed string is: ");
		foreach (char character in input)
		{
			Console.Write(character);
		}

		Console.WriteLine();
	}
}
