using System;
using System.IO;

class Compare2filesSameLines
{
	static void ConcatTwoFiles(string firstFileName, string secondFileName)
	{
		/*Write a program that compares two text files line by line and prints the number of lines that are 
		  the same and the number of lines that are different. Assume the files have equal number of lines.*/
		int sameLines = 0;
		int differentLines = 0;
		using (StreamReader readFirstFile = new StreamReader(firstFileName))
		{
			using (StreamReader readSecondFile = new StreamReader(secondFileName))
			{
				string lineFirstFile = readFirstFile.ReadLine();
				string lineSecondFile = readSecondFile.ReadLine();
				while (lineFirstFile != null && lineSecondFile != null)
				{
					if (lineFirstFile == lineSecondFile)
					{
						sameLines++;
					}
					else
					{
						differentLines++;
					}
					lineFirstFile = readFirstFile.ReadLine();
					lineSecondFile = readSecondFile.ReadLine();
				}
			}
		}
		Console.WriteLine("The number of lines that are the same: {0}", sameLines);
		Console.WriteLine("The number of lines that are different: {0}", differentLines);
	}
	static void Main()
	{
		string filename1 = "Text1.txt";
		string filename2 = "Text2.txt";
		ConcatTwoFiles(filename1, filename2);
	}
}