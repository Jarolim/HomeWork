using System;

class MaxSumOfKElements
{
	static void Main()
	{
		/*Write a program that reads two integer numbers N and K and an array of N elements from the console.
		Find in the array those K elements that have maximal sum.
		{ 12, 12, 12, 11, 11, 11, 7, 8, 9 };*/
		Console.Write("Enter the number of elements in the array: ");
		int n = int.Parse(Console.ReadLine());
		int[] array = new int[n];

		for (int i = 0; i < n; i++)
		{
			Console.Write("array[{0}]=", i);
			array[i] = int.Parse(Console.ReadLine());
		}

		Console.Write("Enter K: ");
		int k = int.Parse(Console.ReadLine());

		int sum = 0;
		int bestSum = 0;
		int length = 0;

		for (int i = 0; i < array.Length; i++)
		{
			sum += array[i];
			length++;
			if (sum > bestSum && length == k)
			{
				bestSum = sum;
			}
			if (length == k)
			{
				i = (i + 1) - k;
				length = 0;
				sum = 0;
			}
		}
		Console.WriteLine(bestSum);
	}
}
