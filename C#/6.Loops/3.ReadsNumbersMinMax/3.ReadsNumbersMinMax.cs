using System;

class ReadsNumbersMinMax
{
    static void Main()
    {
        /*Write a program that reads from the console a sequence of N integer numbers
         * and returns the minimal and maximal of them.*/
        Console.Write("Pleace enter how many numbers will you enter: ");
        int n = int.Parse(Console.ReadLine());
        int number;
        int max = int.MinValue;
        int min = int.MaxValue;    
        for (int i = 0; i < n; i++)
        {          
            Console.WriteLine("Pleace enter {0} number: ",i + 1);
            number = int.Parse(Console.ReadLine());            
            if (max < number)
            {
                max = number;
            }
            if (min > number)
            {
                min = number;
            }
        }
        Console.WriteLine("Min is {0}", min);
        Console.WriteLine("Max is {0}", max);
    }
}

