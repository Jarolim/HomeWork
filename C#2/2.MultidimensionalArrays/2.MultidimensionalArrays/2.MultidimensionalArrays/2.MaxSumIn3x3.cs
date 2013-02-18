using System;

class RectangularMatrixMaxSum
{
	static void Main()
	{
		/*Write a program that reads a rectangular matrix of size
		  N x M and finds in it the square 3 x 3 that has maximal sum of its elements.*/
		Console.WriteLine("The matrix is:");		
		int[,] matrixNM =
		{
			{4, 9, 4, 0, 9, 75},
			{5, 1, 2, 3, 6, 66},
			{1, 2, 9, 9, 5, 88},
			{9, 6, 7, 0, 1, 90},
		};
		int currentSum = int.MinValue;
		int maxSum = int.MinValue;
		int bestRow = 0;
		int bestCol = 0;

		for (int rows = 0; rows < matrixNM.GetLength(0); rows++)
		{
			for (int cols = 0; cols < matrixNM.GetLength(1); cols++)
			{
				if (cols == matrixNM.GetLength(1) - 1) 
				{
					Console.WriteLine("{0,3} ", matrixNM[rows, cols]);
				}
				else
				{
					Console.Write("{0,3} ", matrixNM[rows, cols]);
				}
			}
		}

		for (int rows = 0; rows <= matrixNM.GetLength(0) - 3; rows++)
		{
			for (int cols = 0; cols <= matrixNM.GetLength(1) - 3; cols++)
			{

				currentSum = matrixNM[rows, cols] + matrixNM[rows, cols + 1] + matrixNM[rows, cols + 2] +
						   matrixNM[rows + 1, cols] + matrixNM[rows + 1, cols + 1] + matrixNM[rows + 1, cols + 2] +
						   matrixNM[rows + 2, cols] + matrixNM[rows + 2, cols + 1] + matrixNM[rows + 2, cols + 2];

				if (currentSum > maxSum)
				{
					maxSum = currentSum;
					bestCol = cols;
					bestRow = rows;
				}
				currentSum = int.MinValue;
			}

		}
		Console.WriteLine("The max sum of the elements 3x3 is : {0}", maxSum);
		Console.WriteLine("The element 3x3 is:");
		Console.WriteLine("{0,4}, {1,4}, {2,4}", matrixNM[bestRow, bestCol], matrixNM[bestRow, bestCol + 1], matrixNM[bestRow, bestCol + 2]);
		Console.WriteLine("{0,4}, {1,4}, {2,4}", matrixNM[bestRow + 1, bestCol], matrixNM[bestRow + 1, bestCol + 1], matrixNM[bestRow + 1, bestCol + 2]);
		Console.WriteLine("{0,4}, {1,4}, {2,4}", matrixNM[bestRow + 2, bestCol], matrixNM[bestRow + 2, bestCol + 1], matrixNM[bestRow + 2, bestCol + 2]);
	}
}
