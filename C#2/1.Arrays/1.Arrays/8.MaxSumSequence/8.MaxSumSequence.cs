using System;

class MaxSumSequence
{
	/*Write a program that finds the sequence of maximal sum in given array. Example:
	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
	Can you do it with only one loop (with single scan through the elements of the array)?*/
	static int ReadInts(string Value)
	{
		while (true)
		{
			int Integer;
			bool Result = int.TryParse(Value, out Integer);
			if (Result == true)
			{
				return Integer;
			}
			else
			{
				Console.Write(@"""{0}"" is not an integer. Try again: ", Value);
				Value = Console.ReadLine();
			}
		}
	}

	private static void PrintOneDimSubArray(int index1, int Length, int[] arr)
	{
		for (int index = index1; index < index1 + Length; index++)
		{
			Console.Write(arr[index] + " ");
		}
		Console.WriteLine();
	}

	static void Main(string[] args)
	{
		int N = -1;
		while (N <= 0)
		{
			Console.Write("Input size of array: ");
			N = ReadInts(Console.ReadLine());
		}
		int K = -1;
		while (K <= 0 || K > N)
		{
			Console.Write("Input size of sub-array: ");
			K = ReadInts(Console.ReadLine());
		}
		int[] Array = new int[N];
		for (int index = 0; index < Array.Length; index++)
		{
			Console.Write("Input Array[{0}]: ", index);
			Array[index] = ReadInts(Console.ReadLine());
		}
		int maxsum = int.MinValue;
		int tempsum = 0;
		int minIndex = 0;
		for (int index = 0; index < Array.Length - (K - 1); index++)
		{
			for (int sumIndex = 0; sumIndex < K; sumIndex++)
			{
				tempsum += Array[index + sumIndex];
			}
			if (maxsum < tempsum)
			{
				maxsum = tempsum;
				minIndex = index;
			}
			tempsum = 0;
		}
		Console.Write("Sub-array is: ");
		PrintOneDimSubArray(minIndex, K, Array);
		Console.WriteLine("The sum is: {0}", maxsum);
	}
}