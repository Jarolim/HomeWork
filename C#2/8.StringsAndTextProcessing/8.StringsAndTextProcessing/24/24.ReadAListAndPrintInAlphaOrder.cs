using System;
using System.Linq;

public class ReadAListAndPrintInAlphaOrder
{
	public static void Main()
	{
		/*Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.*/
		string[] listOfWords = Console.ReadLine().Split();

		var sortWords = listOfWords.OrderBy(x => x);
		foreach (var word in sortWords)
		{
			Console.WriteLine("{0}", word);
		}
	}
}
