using System;

class OutputAMatrixFromN
{
    static void Main()
    {
        /*Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:*/

        Console.Write("Pleace enter a number in the interval [1...19]: ");
        int n = int.Parse(Console.ReadLine());
        for (int row = 1 ; row <= n; row++)
        {
            for (int column = row; column < n+row; column++)
            {
                Console.Write("{0} ", column);
            }
            Console.WriteLine();
        }
    }
}

