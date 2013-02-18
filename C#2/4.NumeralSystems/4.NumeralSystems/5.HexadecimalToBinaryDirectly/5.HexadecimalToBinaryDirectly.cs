using System;
using System.Text;

class HexadecimalToBinaryDirectly
{
	/*Write a program to convert hexadecimal numbers to binary numbers (directly).*/
	static void Main()
	{
		string hex = "5644DE6A";
		string convertedBin = HexadecimalBinaryDirectly(hex);
		Console.WriteLine(convertedBin);
	}
	static string HexadecimalBinaryDirectly(string hex)
	{
		char[] hexChar = hex.ToCharArray();
		StringBuilder hexString = new StringBuilder();

		for (int i = 0; i < hexChar.Length; i++)
		{
			switch (hexChar[i])
			{
				case 'A': hexString.Append(" 1010"); break;
				case 'B': hexString.Append(" 1011"); break;
				case 'C': hexString.Append(" 1100"); break;
				case 'D': hexString.Append(" 1101"); break;
				case 'E': hexString.Append(" 1110"); break;
				case 'F': hexString.Append(" 1111"); break;
				case '0': hexString.Append(" 0000"); break;
				case '1': hexString.Append(" 0001"); break;
				case '2': hexString.Append(" 0010"); break;
				case '3': hexString.Append(" 0011"); break;
				case '4': hexString.Append(" 0100"); break;
				case '5': hexString.Append(" 0101"); break;
				case '6': hexString.Append(" 0110"); break;
				case '7': hexString.Append(" 0111"); break;
				case '8': hexString.Append(" 1000"); break;
				case '9': hexString.Append(" 1001"); break;
			}
		}
		return hexString.ToString();
	}
}
