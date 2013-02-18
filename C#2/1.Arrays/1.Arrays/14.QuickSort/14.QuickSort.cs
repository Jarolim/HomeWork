using System;

class Quicksort
{
	/*Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).*/
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

	static void QuickSort(string[] ArrayOfStrings)
	{
		for (int index1 = 0; index1 < ArrayOfStrings.Length; index1++)
		{
			for (int index2 = index1 + 1; index2 < ArrayOfStrings.Length; index2++)
			{
				if (ArrayOfStrings[index1].Length > ArrayOfStrings[index2].Length)
				{
					string Temp = ArrayOfStrings[index1];
					ArrayOfStrings[index1] = ArrayOfStrings[index2];
					ArrayOfStrings[index2] = Temp;
				}
			}
		}
	}

	static void Main(string[] args)
	{
		int N = -1;
		while (N < 0)
		{
			Console.Write("Input N: ");
			N = ReadInts(Console.ReadLine());
		}
		string[] StringArray = new string[N];
		Console.WriteLine("Input {0} strings:", N);
		for (int index = 0; index < StringArray.Length; index++)
		{
			StringArray[index] = Console.ReadLine();
		}

		QuickSort(StringArray);

		Console.WriteLine("Sorted array of strings is:");
		for (int index = 0; index < StringArray.Length; index++)
		{
			Console.WriteLine(StringArray[index]);
		}
	}
}
