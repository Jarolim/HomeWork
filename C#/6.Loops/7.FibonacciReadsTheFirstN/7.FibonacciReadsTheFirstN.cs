using System;

class FibonacciReadsTheFirstN
{
    static void Main()
    {
        /*Write a program that reads a number N and calculates the sum of the first N members of 
         the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
         Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.*/

        //I am using the Golden Ratio to do the work :)
        Console.Write("Pleace enter a number: ");
        int n = int.Parse(Console.ReadLine());
        double nerf1 = 1.61803398874989484820;
        double nerf2 = 0.61803398874989484820;
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine((long)(((Math.Pow(nerf1, i)) - (Math.Pow(-nerf2, i))) / Math.Sqrt(5)));  
            double fib = (((Math.Pow(nerf1, i)) - (Math.Pow(-nerf2, i))) / Math.Sqrt(5));
            sum += (long)fib;
        } 
        Console.WriteLine("The sum is {0}",sum);
    }
}

