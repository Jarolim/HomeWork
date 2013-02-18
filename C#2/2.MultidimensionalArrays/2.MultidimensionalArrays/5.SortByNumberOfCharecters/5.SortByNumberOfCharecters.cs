using System;

class SortByNumberOfCharecters
{
	/*You are given an array of strings. Write a method that sorts the array by the length of its elements
      (the number of characters composing them).*/
	public static int n, m;
	public static void SortStringsByLength(string[] arr)
	{
		int[] strLength = new int[n];
		for (m = 0; m < arr.Length; m++)
		{
			strLength[m] = arr[m].Length;
		}
		Array.Sort(strLength, arr);
	}

	static void Main()
	{
		Console.Write("Enter the length of the array: ");
		string nStr = Console.ReadLine();
		n = int.Parse(nStr);
		string[] arr = new string[n];
		m = 0;
		Console.WriteLine("Enter the strings in the array:");
		while (m < n)
		{
			arr[m] = Console.ReadLine();
			m++;
		}
		SortStringsByLength(arr);
		foreach (string item in arr)
		{
			Console.WriteLine(item);
		}
	}
}
