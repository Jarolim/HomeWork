using System;


class Compare2arrLetterByLetter
{
	static void Main()
	{
		/* Write a program that compares two char arrays lexicographically (letter by letter).*/
		char[] firstArray = { 'a', 'b', 'c', 'k', 'm' };
		char[] secondArray = { 'a', 'b', 'c', 'k', 'n' };
		bool equal = true;

		if (firstArray.Length == secondArray.Length)
		{
			for (int i = 0; i < firstArray.Length; i++)
			{
				if (firstArray[i] != secondArray[i])
				{
					equal = false;
				}
			}
			Console.WriteLine("The two arrays are equal: " + equal);
		}
		else
		{
			equal = false;
			Console.WriteLine("The two arrays are equal: " + equal);
		}

	}
}

