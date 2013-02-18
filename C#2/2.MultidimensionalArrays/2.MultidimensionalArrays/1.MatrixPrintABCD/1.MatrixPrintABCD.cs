using System;

class MatrixPrintABCD
{
	/*Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)*/
	static void PrintA(int[,] matrix, byte n, int counter)
	{
		for (int col = 0; col < n; col++)
		{
			for (int row = 0; row < n; row++)
			{
				matrix[row, col] = counter++;
			}
		}
		Print(matrix, n);
	}
	static void PrintB(int[,] matrix, byte n, int counter)
	{
		for (int col = 0; col < n; col++)
		{
			if ((col & 1) == 0)
			{
				for (int row = 0; row < n; row++)
				{
					matrix[row, col] = counter++;
				}
			}
			else
			{
				for (int row = n - 1; row >= 0; row--)
				{
					matrix[row, col] = counter++;
				}
			}
		}
		Print(matrix, n);
	}
	static void PrintC(int[,] matrix, byte n, int counter)
	{
		for (int row = n - 1; row >= 0; row--)
		{
			for (int col = 0; col < n - row; col++)
			{
				matrix[row + col, col] = counter++;
			}
		}
		for (int col = 1; col < n; col++)
		{
			for (int row = 0; row < n - col; row++)
			{
				matrix[row, col + row] = counter++;
			}
		}
		Print(matrix, n);
	}
	
	static void Print(int[,] matrix, byte n)
	{
		for (int row = 0; row < n; row++)
		{
			for (int col = 0; col < n; col++)
			{
				Console.Write("{0,4}", matrix[row, col]);
			}
			Console.WriteLine();
		}
		Console.WriteLine();
	}
	static void Main()
	{
		Console.Write("Please enter a number for the width and height of the matrix (best to be a small number): ");
		byte n;
		if (byte.TryParse(Console.ReadLine(), out n))
		{
			int[,] matrix = new int[n, n];
			Console.WriteLine();
			PrintA(matrix, n, 1);
			PrintB(matrix, n, 1);
			PrintC(matrix, n, 1);
		}
	}
}