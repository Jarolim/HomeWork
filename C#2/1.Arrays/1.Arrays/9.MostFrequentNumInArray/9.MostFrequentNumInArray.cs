using System;

class Program
{
	static void Main(string[] args)
	{
		/*Write a program that finds the most frequent number in an array. Example:
	      {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)*/
		int[] arr = { 4 , 9 , 6 , 9 , 9 , 4 , 5 , 6 , 9 , 3 , 9 , 4 , 5 };
		int[] checking = new int[0];
		Array.Sort(arr);
		int freqNum = arr[0];
		if (arr[arr.Length - 1] < arr.Length)
		{
			checking = new int[arr.Length];
		}
		else if (arr[arr.Length - 1] > arr.Length)
		{
			checking = new int[arr[arr.Length - 1] + 1];
		}

		for (int i = 0; i < arr.Length; i++)
		{
			checking[arr[i]]++;
		}

		for (int i = 0; i < checking.Length; i++)
		{
			if (freqNum < checking[i])
			{ 
				freqNum = checking[i];
			}
		}

		Console.WriteLine("The most frequent number is : {1} ({0} times).", freqNum, Array.IndexOf(checking, freqNum));
	}
}
