using System;

class BinaryToDecimal
{
	static void Main()
	{
		/* Write a program to convert binary numbers to their decimal representation.*/
		Console.Write("Enter the Binary number: ");
		string binary = Console.ReadLine();
		int decimalNumber = 0;
		for (int i = 0; i < binary.Length; i++)
		{
			decimalNumber = decimalNumber << 1;
			if (binary[i] == '1')
			{
				decimalNumber = decimalNumber ^ 1;
			}
		}
		Console.Write("The number in Decimal is: ");
		Console.WriteLine(decimalNumber);
	}
}
