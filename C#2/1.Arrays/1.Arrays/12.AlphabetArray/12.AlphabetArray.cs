using System;

class AlphabetArray
{
	static void Main()
	{
		/* Write a program that creates an array containing
		   all letters from the alphabet (A-Z). Read a word
           from the console and print the index of each of its letters in the array.*/
		int[] letterIndexes = new int[53];

		for (int i = 1; i < letterIndexes.Length / 2 + 1; i++)
		{
			letterIndexes[i] = ('a' - 1) + i;
		}

		string testWord = "ahdsfgz";
		for (int i = 0; i < testWord.Length; i++)
		{
			for (int j = 0; j < letterIndexes.Length; j++)
			{
				if (testWord[i] == letterIndexes[j])
				{
					Console.WriteLine("Letter {0} has index: {1}", testWord[i], j);
					break;
				}
			}
		}
	}
}