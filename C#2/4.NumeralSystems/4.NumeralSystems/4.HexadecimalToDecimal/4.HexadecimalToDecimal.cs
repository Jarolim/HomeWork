using System;
using System.Collections.Generic;

class FromHexadecimalToDecimal
{
	/*Write a program to convert hexadecimal numbers to their decimal representation.*/
	static void Main()
	{
		List<char> hexa = new List<char>();
		Console.Write("Enter number in Hex: ");
		string hexString = Console.ReadLine();
		char[] hexr = hexString.ToCharArray();
		for (int i = 0; i < hexr.Length; i++)
		{
			hexa.Add(hexr[i]);
		}
		double dec = 0;
		double face = hexa.Count - 1;
		foreach (char hexChar in hexa)
		{
			int num;
			if (hexChar == 'A') num = 10;
			else if (hexChar == 'B') num = 11;
			else if (hexChar == 'C') num = 12;
			else if (hexChar == 'D') num = 13;
			else if (hexChar == 'E') num = 14;
			else if (hexChar == 'F') num = 15;
			else num = hexChar - '0';
			dec += num * (Math.Pow(16, face));
			face--;
		}
		Console.WriteLine("In decimal:" + dec);
	}
}
