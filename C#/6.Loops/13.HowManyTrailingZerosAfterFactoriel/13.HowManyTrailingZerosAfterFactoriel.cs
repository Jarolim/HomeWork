using System;
using System.Numerics;
class HowManyTrailingZerosAfterFactoriel
{
    static void Main()
    {
        /*  13*Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
	        N = 10  N! = 3628800  2
	        N = 20  N! = 2432902008176640000  4
	        Does your program work for N = 50 000?
	        Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!*/
        Console.Write("Pleace enter N!: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger nFactoriel = 1;
        int trailingZeros = 0;
        for (int i = 1; i <= n; i++)
        {
            nFactoriel *= i;
        }
        Console.WriteLine("N! = {0}", nFactoriel);
        for (int i = 5; i <= n; i*=5)
        {
            trailingZeros = trailingZeros + (n / i);
        }
        Console.WriteLine("N! has {0} trailing zeros", trailingZeros);
    }
}

