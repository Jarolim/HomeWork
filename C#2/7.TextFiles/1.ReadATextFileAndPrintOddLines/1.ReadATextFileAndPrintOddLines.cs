using System;
using System.IO;

class PrintOddLines
{
	static void ReadOddLines(string fileName)
	{
		/*Write a program that reads a text file and prints on the console its odd lines.*/
		StreamReader reader = new StreamReader(fileName);
		using (reader)
		{
			int lineNumber = 0;
			string line = reader.ReadLine();
			while (line != null)
			{
				lineNumber++;
				if ((lineNumber % 2) != 0)
				{
					Console.WriteLine("Line {0}: {1}", lineNumber, line);
				}
				line = reader.ReadLine();
			}
		}
	}

	static void Main()
	{
		string filename = "TheProgrammerLifestyle.txt";
		ReadOddLines(filename);
	}
}
