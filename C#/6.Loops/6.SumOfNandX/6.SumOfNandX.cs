using System;
using System.Numerics;

class SumOfNAndX
{
	static void Main()
	{
		/*Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN*/
		Console.Write("Pleace enter N: ");
		int n = int.Parse(Console.ReadLine());
		Console.Write("Pleace enter X: ");
		int x = int.Parse(Console.ReadLine());
		BigInteger factorial = 1;
		BigInteger denominator = x;
		double sum = (double)(1 + 1 / (double)(x));
		for (int i = 2; i <= n; i++)
		{
			factorial *= i;
			denominator *= x;
			sum += (double)factorial / (double)denominator;
		}
		Console.WriteLine("S = 1 + 1!/X + 2!/X2 + ... + N!/XN = " + sum);
	}
}