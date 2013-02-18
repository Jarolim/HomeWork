using System;

class ArrayBinarySearch
{
	static void Main()
	{
		/*Write a program, that reads from the console an array of N integers and an integer K, sorts the array and 
		  using the method Array.BinSearch() finds the largest number in the array which is ≤ K. */
		Console.Write("Enter number of charecters in the array:");
		int n = int.Parse(Console.ReadLine());
		int[] numbers = new int[n];

		Console.WriteLine("Enter the numbers:");
		for (int i = 0; i < numbers.Length; i++)
		{
			numbers[i] = int.Parse(Console.ReadLine());
		}

		Console.WriteLine("Input K:");
		int k = int.Parse(Console.ReadLine());


		Array.Sort(numbers);
		int index = Array.BinarySearch(numbers, k);

		if (numbers[0] > k)
		{
			Console.WriteLine("No number in the array meets the requirements.");
		}
		else
		{
			if (index >= 0)
			{
				Console.WriteLine("The largest number in the array which is less or equal to K is {0}", numbers[index]);
			}
			else
			{
				Console.WriteLine("The largest number in the array which is less or equal to K is {0}", numbers[-index - 2]);
			}
		}
	}
}