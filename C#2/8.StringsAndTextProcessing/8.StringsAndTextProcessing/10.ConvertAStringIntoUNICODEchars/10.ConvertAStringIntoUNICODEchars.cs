using System;

class ConvertAStringIntoUNICODEchars
{
	static void Main()
	{
		/*Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings.*/
		string str = "Hello!";
		foreach (var symbol in str)
		{
			Console.Write("\\u{0:X4}", (int)symbol);
		}
		Console.WriteLine();
	}
}
