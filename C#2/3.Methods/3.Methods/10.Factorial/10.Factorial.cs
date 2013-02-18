using System;
using System.Numerics;

class Factorial
{
	static void Main()
	{
		Console.Write("Enter n! - from 0 to 100: ");
		int n = int.Parse(Console.ReadLine());

		FactorialCalculation(n);
	}

	private static void FactorialCalculation(int n)
	{
		BigInteger factorial = 1;

		for (int i = 1; i <= n; i++)
		{
			factorial *= i;
		}

		Console.WriteLine("{0}! = {1}", n, factorial);
	}
}
