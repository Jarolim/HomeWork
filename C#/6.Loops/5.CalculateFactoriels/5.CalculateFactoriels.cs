using System;
using System.Numerics;

class CalculateFactoriels
{
    static void Main()
    {
        /*Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).*/

		Console.Write("Pleace enter N!: ");
		int n = int.Parse(Console.ReadLine());
		Console.Write("Pleace enter K!: ");
		int k = int.Parse(Console.ReadLine());
		int temp;
		double division;
		BigInteger nFactorial = 1;
		BigInteger kFactorial = 1;
		BigInteger denominator = 1;
		for (int i = 1; i <= n; i++)
		{
			nFactorial *= i;
		}
		for (int j = 1; j <= k; j++)
		{
			kFactorial *= j;
		}
		temp = k - n;
		for (int m = 1; m <= temp; m++)
		{
			denominator *= m;
		}
		division = (double)(nFactorial * kFactorial) / (double)(denominator);
		Console.WriteLine("N!*K! / (K-N)! = " + division);
    }
}

