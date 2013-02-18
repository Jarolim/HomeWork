using System;
using System.Text;

class ReplaceIdenticalLetter
{
	static void Main()
	{
		/*Write a program that reads a string from the console and replaces all series of consecutive
		  identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".*/
		string text = "aaaaabbbbbcdddeeeedssaa";
		StringBuilder str = new StringBuilder(text);

		for (int letter = 0; letter < str.Length - 1; letter++)
		{
			if (str[letter] == str[letter + 1])
			{
				str.Remove(letter, 1);
				letter--;
			}
		}
		Console.WriteLine(str);
	}
}