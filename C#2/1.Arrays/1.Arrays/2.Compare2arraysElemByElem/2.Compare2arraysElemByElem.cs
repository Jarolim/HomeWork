using System;

class Compare2arraysElemByElem
{
	static void Main()
	{
		/*Write a program that reads two arrays from the console and compares them element by element.*/
		Console.Write("Pleace enter the length of the two arrays: ");
		int n = int.Parse(Console.ReadLine());
		int[] firstArray = new int[n];
		int[] secondArray = new int[n];
		for (int i = 0; i < firstArray.Length; i++)
		{
			Console.Write("Enter element {0} from the first array: ", i);
			firstArray[i] = int.Parse(Console.ReadLine());
		}
		for (int i = 0; i < firstArray.Length; i++)
		{
			Console.Write("Enter element {0} from the second array: ", i);
			secondArray[i] = int.Parse(Console.ReadLine());
		}
		Array.Sort(firstArray);
		Array.Sort(secondArray);
		bool equal = true;
		for (int i = 0; i < firstArray.Length; i++)
		{
			if (firstArray[i] != secondArray[i])
			{
				equal = false;
				break;
			}
		}
		if (equal == true)
		{
			Console.WriteLine("The two arrays are equal!", equal);
		}
		else
		{
			Console.WriteLine("The two arrays are unequal.", equal);
		}
	}
}

