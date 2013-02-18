using System;

class GivenSumIfPresentInArray
{
	static void Main()
	{
		/*Write a program that finds in given array of 
		  integers a sequence of given sum S (if present). 
		  Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}*/
		int[] arr = { 4, 3, 1, 4, 2, 5, 8 };
		int S = 8,
			Break = 0;

		for (int i = 0; i < arr.Length; i++)
		{
			if (Break == 1) break;
			for (int j = i + 1; j < arr.Length; j++)
			{
				if (Break == 1) break;
				for (int k = j + 1; k < arr.Length; k++)
				{
					if (Break == 1) break;
					if (arr[i] + arr[j] + arr[k] == S)
					{
						Console.Write("The sequence is: ");
						Console.WriteLine("{" + arr[i] + " " + arr[j] + " " + arr[k] + "}");
						Break++;
					}
				}
			}
		}
	}
}