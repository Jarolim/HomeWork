using System;

class MaxSequenceOnEqualElem
{
	static void Main()
	{
		/* Write a program that finds the maximal sequence of equal elements in an array.
           Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}. */
		int[] givenArray = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
		int lenght = 1;
		int bestLenght = 0;
		int type = 0;
		for (int i = 0; i < givenArray.Length - 1; i++)
		{
			if (givenArray[i] == givenArray[i + 1])
			{
				lenght++;
			}
			else
			{
				if (lenght > bestLenght)
				{
					bestLenght = lenght;
					type = givenArray[i];
				}
				lenght = 1;
			}
		}
		if (lenght > bestLenght)
		{
			bestLenght = lenght;
			type = givenArray[givenArray.Length - 1];
		}
		Console.WriteLine("We have a sequence of {0} elements of type '{1}'", bestLenght, type);
	}
}
