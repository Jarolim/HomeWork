using System;

class SortAnArray
{
	static void Main()
	{
		/*Sorting an array means to arrange its elements in increasing order. Write a program to 
		  sort an array. Use the "selection sort" algorithm: Find the smallest element, move 
		  it at the first position, find the smallest from the rest, move it at the second position, etc.*/
		Console.Write("Enter the length of the array: ");
		int n = int.Parse(Console.ReadLine());

		int[] array = new int[n];

		for (int i = 0; i < n; i++)
		{
			
			Console.Write("array[{0}]=", i);
			array[i] = int.Parse(Console.ReadLine());
		}

		int currentMin, temp;

		for (int i = 0; i < array.Length - 1; i++)
		{
			currentMin = i;
			for (int j = i + 1; j < array.Length; j++)
			{
				if (array[j] < array[currentMin])
				{
					currentMin = j;
				}
			}
			temp = array[i];
			array[i] = array[currentMin];
			array[currentMin] = temp;
		}
		Console.Write("The sorted array is: ");
		for (int i = 0; i < array.Length; i++)
		{
			
			Console.Write(array[i] + " ");
		}
		Console.WriteLine();
	}
}
