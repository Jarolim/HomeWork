using System;

class ReadValuesFromStringAndSum
{
	static void Main()
	{
		/*You are given a sequence of positive integer values written into a string, 
		  separated by spaces. Write a function that reads these values from given 
		  string and calculates their sum. Example: string = "43 68 9 23 318"  result = 461 */
		string inputString = "43 68 9 23 318";
		Console.WriteLine("The input string is: {0}", inputString);
		int sum = 0;
		string[] stringNumbers = inputString.Split(' ');
		for (int i = 0; i < stringNumbers.Length; i++)
		{
			sum = sum + int.Parse(stringNumbers[i]);
		}
		Console.WriteLine("The sum of the values is: " + sum);
	}
}
