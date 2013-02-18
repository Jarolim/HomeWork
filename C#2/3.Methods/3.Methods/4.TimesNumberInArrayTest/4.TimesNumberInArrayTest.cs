using System;

namespace _4.TimesNumberInArrayTest
{
	class TimesNumberInArrayTest
	{
		/*Write a method that counts how many times given number appears in given array.
		 Write a test program to check if the method is working correctly.*/
		public static decimal numberToCheck;
		public static int count;

		public static void CountAppearances(decimal[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == numberToCheck)
				{
					count++;
				}
			}
		}

		static void Main()
		{
			Console.Write("Enter the number which appearance you wish to count: ");
			numberToCheck = decimal.Parse(Console.ReadLine());
			decimal[] array = { 1, 2, 5, 2, 6, 7, 3, 2, 7, 8, 2 };
			CountAppearances(array);
			Console.WriteLine("The number {0} appears {1} of times in the array", numberToCheck, count);
		}
	}
}
