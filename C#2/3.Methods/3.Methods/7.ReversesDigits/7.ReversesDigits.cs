using System;

class ReverseDigits
{
	/*Write a method that reverses the digits of given decimal number. Example: 256  652*/
	static void ReverseDigitsNumber(bool isNegative, char[] reverseDigits)
	{
		Console.Write("The reversed number is:");
		Array.Reverse(reverseDigits);

		for (int i = 0; i < reverseDigits.Length; i++)
		{
			if (isNegative == true && i == reverseDigits.Length - 1)
			{
				break;
			}
			Console.Write(reverseDigits[i]);
		}
		Console.WriteLine();
	}
	static void Main()
	{
		Console.Write("Enter number: ");
		string decimalStr = Console.ReadLine();
		bool isNegative = false;
		char[] reverseDigits = decimalStr.ToCharArray();
		ReverseDigitsNumber(isNegative, reverseDigits);
	}
}
