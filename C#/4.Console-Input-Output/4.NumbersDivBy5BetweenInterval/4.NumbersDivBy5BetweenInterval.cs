using System;

class NumbersDivBy5BetweenInterval
{
    static void Main()
    {
        /*Write a program that reads two positive integer numbers and prints how many numbers p exist between them such 
         that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.*/
        Console.WriteLine("Enter an interval");
        int numberOne;
        numberOne = int.Parse(Console.ReadLine());
        int numberTwo;
        numberTwo = int.Parse(Console.ReadLine());
        Console.WriteLine("Your interval is ({0},{1})", numberOne, numberTwo);
        int divByFive = 0;
        for (int i = numberOne; i < numberTwo; i++)
        {
            if (i % 5 == 0)
            {
                divByFive++;
            }          
        }
        Console.WriteLine("This is how many numbers p exist between them such that the reminder of the division by 5 is 0 : {0}", divByFive);
    }
}

