using System;
using System.IO;

namespace ConsoleApplication2
{
	class Concatenate
	{
		static void Main(string[] args)
		{
			/*Write a program that concatenates two text files into another text file.*/
			StreamWriter newFile = new StreamWriter("Concatenated.txt");
			using (newFile)
			{
				StreamReader text1 = new StreamReader("Text1.txt");
				using (text1)
				{
					string a = text1.ReadToEnd();
					newFile.WriteLine(a);

				}
				StreamReader text2 = new StreamReader("Text2.txt");
				using (text2)
				{
					string b = text2.ReadToEnd();
					newFile.WriteLine(b);
				}
			}
		}
	}
}