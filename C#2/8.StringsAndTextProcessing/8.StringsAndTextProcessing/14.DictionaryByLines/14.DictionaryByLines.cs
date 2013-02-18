using System;

class DictionaryByLines
{
	static void Main()
	{
		/*A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program
		  that enters a word and translates it by using the dictionary.*/
		string[] dictionary = { ".NET - platform for applications from Microsoft",
                                "CLR - managed execution environment for .NET",
                                "namespace - hierarchical - organization of classes",};
		string word = "CLR";
		foreach (string line in dictionary)
		{
			if (line.IndexOf(word + " -") == 0)
			{
				Console.WriteLine(line);
			}
		}
	}
}