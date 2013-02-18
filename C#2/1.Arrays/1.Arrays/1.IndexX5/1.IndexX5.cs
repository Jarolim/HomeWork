using System;

class IndexX5
{
	static void Main()
	{
		/*Write a program that allocates array of 20 integers and initializes each 
		 element by its index multiplied by 5. Print the obtained array on the console.*/
		int[] arr = new int[20];
		for (int i = 0; i < arr.Length; i++)
		{
			//I am doing the if-else statement only to not have a coma (,) behind the last index
			if (i == arr.Length-1)
			{
				arr[i] = i * 5;
				Console.Write("{0}", arr[i]);
			}
			else
			{
				arr[i] = i * 5;
				Console.Write("{0}, ", arr[i]);
			}
		}
		Console.WriteLine();
	}
}

