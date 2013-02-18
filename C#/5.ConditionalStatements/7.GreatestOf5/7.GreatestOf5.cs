using System;

class GreatestOf5
{
    static void Main()
    {
        /*Write a program that finds the greatest of given 5 variables.*/
        Console.Write("Pleace enter first integer number: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Pleace enter second integer number: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Pleace enter third integer number: ");
        int c = int.Parse(Console.ReadLine());
        Console.Write("Pleace enter fourth integer number: ");
        int d = int.Parse(Console.ReadLine());
        Console.Write("Pleace enter fifth integer number: ");
        int e = int.Parse(Console.ReadLine());
        
        int greatestOfFive = a;
        if (b > greatestOfFive)
        {
            greatestOfFive = b;
        }
        if (c > greatestOfFive)
        {
            greatestOfFive = c;
        }
        if (d > greatestOfFive)
        {
            greatestOfFive = d;
        }
        if (e > greatestOfFive)
        {
            greatestOfFive = e;
        }
        Console.WriteLine("The Greatest is: {0}", greatestOfFive);
    }
}

