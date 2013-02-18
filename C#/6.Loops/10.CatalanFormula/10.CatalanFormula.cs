using System;
using System.Numerics;
class CatalanFormula
{
    /*In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:((2n)!)/((n+1)!n!)
	Write a program to calculate the Nth Catalan number by given N.*/
    static void Main()
    {
        Console.Write("Pleace enter N!: ");
        int n = int.Parse(Console.ReadLine());

        BigInteger nTimes2Factorial = 1;
        for (int i = 1; i <= 2*n; i++)
        {
            nTimes2Factorial *= i;
        }
        BigInteger twoN = nTimes2Factorial;
        Console.WriteLine("(2n)! = {0}", nTimes2Factorial);

        BigInteger nPlusOneFactorial = 1;
        for (int i = 1; i <= n+1; i++)
        {
            nPlusOneFactorial *= i;
        }
        BigInteger NplusOne = nPlusOneFactorial;
        Console.WriteLine("(n+1)! = {0}", nPlusOneFactorial);

        BigInteger nFactorial = 1;
        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
        }
        BigInteger NOnly = nFactorial;
        Console.WriteLine("n! = {0}", nFactorial);

        Console.WriteLine("((2n)!)/((n+1)!n!) = {0}", nTimes2Factorial / (nPlusOneFactorial*nFactorial));
    }
}

