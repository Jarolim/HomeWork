using System;

class OutputASpiralMatrixFromN
{
    static void Main()
    {
        /*14* Write a program that reads a positive integer number N (N < 20) 
         from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.*/
        Console.Write("Pleace enter a number in the interval [1...19]: ");
        int n = int.Parse(Console.ReadLine());
        for (int row = 1; row <= n; row++)
        {
            for (int column = row; column < n + row; column++)
            {
                Console.Write("{0} ", column);
            }
            Console.WriteLine();
        }
    }
}

