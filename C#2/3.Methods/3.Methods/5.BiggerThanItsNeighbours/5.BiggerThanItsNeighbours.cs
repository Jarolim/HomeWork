using System;

namespace _5.BiggerThanItsNeighbours
{
	class BiggerThanItsNeighbours
	{
		/*Write a method that checks if the element at given position in given array of
		 integers is bigger than its two neighbors (when such exist).*/
		static bool IsInside(int[] arr, int i)
		{
			return 0 <= i && i < arr.Length;
		}

		static bool IsBigger(int[] arr, int i, int j)
		{
			return IsInside(arr, j) ? arr[i] > arr[j] : true;
		}

		static bool IsBiggerThanItsNeighbours(int[] arr, int i)
		{
			return IsBigger(arr, i, i - 1) && IsBigger(arr, i, i + 1);
		}

		static void Main()
		{
			int[] arr = { 2, 6, 45, 5, 9, 55, 6 };
			Console.WriteLine("Array index: bigger than its neighbours");
			for (int i = 0; i < arr.Length; i++)
			{
				Console.WriteLine(arr[i] + ": " + IsBiggerThanItsNeighbours(arr, i));
			}
		}
	}
}
