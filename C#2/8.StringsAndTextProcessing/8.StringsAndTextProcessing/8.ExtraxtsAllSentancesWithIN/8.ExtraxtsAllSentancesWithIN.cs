using System;
using System.Text.RegularExpressions;

class ExtractAllSentencesWithIN
{
	static void Main()
	{
		/*Write a program that extracts from a given text all sentences containing given word.*/
		string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
		string In = "in";
		string[] sentence = text.Split('.');

		for (int i = 0; i < sentence.Length; i++)
		{
			if (Regex.Matches(sentence[i], @"\b" + In + @"\b").Count > 0)
			{
				Console.WriteLine((sentence[i] + ".").Trim());
			}
		}
	}
}