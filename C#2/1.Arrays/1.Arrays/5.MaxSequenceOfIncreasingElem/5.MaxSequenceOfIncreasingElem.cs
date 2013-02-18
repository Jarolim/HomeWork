using System;

class IncreasingSequenceInArray
{
    static void Main()
    {
		/*Write a program that finds the maximal increasing sequence in an array. 
		  Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.  */
		Console.Write("Enter the lenght of the array: ");
		int lenght = int.Parse(Console.ReadLine());
        int[] array = new int[lenght];
		Console.WriteLine("Enter the elements: ");
        for (int i = 0; i < lenght; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int count = 0;
        int bestCount = 0;
        string openCurly = "{";
        string closeCurly = "{";

        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1])
            {
                count++;
                openCurly += array[i] + ", ";
            }
            else
            {
                if (count > bestCount)
                {
                    bestCount = count;
                    openCurly += array[i];
                    closeCurly = openCurly + "}";
                }
                count = 0;
            }
        }
        Console.WriteLine(closeCurly);
    }
}