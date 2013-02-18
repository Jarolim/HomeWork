//Write a program that reads a text file and inserts line numbers in front of each of its lines. 
//The result should be written to another text file.

using System;
using System.IO;

namespace InsertLineNumbers
{
	class InsertLineNumbers
	{
		static void InsertLine(string fileName, string newTextFile)
		{
			using (StreamWriter streamWriter = new StreamWriter(newTextFile))
			{
				using (StreamReader readFile = new StreamReader(fileName))
				{
					string line = readFile.ReadLine();
					int lineNumber = 1;
					while (line != null)
					{
						streamWriter.WriteLine(lineNumber + " " + line);
						line = readFile.ReadLine();
						lineNumber++;
					}
				}
			}
			Console.WriteLine("New file with insert line numbers is created!");
			Console.WriteLine(newTextFile);
		}
		static void Main()
		{
			string filename = "TheProgrammerLifestyle.txt";
			string newTextFile = "TextWithLineNumbers.txt";
			InsertLine(filename, newTextFile);
		}
	}
}
