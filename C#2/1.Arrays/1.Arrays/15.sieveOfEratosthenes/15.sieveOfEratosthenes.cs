using System;

class SieveOfEratosthenes
{
	/*Write a program that finds all prime numbers in the 
	  range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).*/
	static void Main(string[] args)
	{
		int[] TenMil = new int[10000000];
		for (int index = 0; index < TenMil.Length; index++)
		{
			TenMil[index] = index;
		}
		bool[] IndexOfPrimeNumbers = new bool[TenMil.Length]; 
		for (int index = 2; index < TenMil.Length; index++)
		{
			if (IndexOfPrimeNumbers[index] == false)
			{
				for (long index2 = 2 * index; index2 < TenMil.Length; index2 += index)
				{
					IndexOfPrimeNumbers[index2] = true;
				}
			}
		}
		for (int index = 0; index < TenMil.Length; index++)
		{
			if (IndexOfPrimeNumbers[index] == false)
			{
				Console.WriteLine(TenMil[index]);
			}
		}
	}
}
