using System;

class Descending3Ints
{
    static void Main()
    {
        /*Sort 3 real values in descending order using nested if statements.*/
        Console.WriteLine("Please enter 3 real values: ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        if (a > b && a > c)
        {
            if (b > c)
            {
                Console.WriteLine("In descending order:");
                Console.WriteLine(a + "\n" + b + "\n" + c);
            }
            else
            {
                Console.WriteLine("In descending order:");
                Console.WriteLine(a + "\n" + c + "\n" + b);
            }
        }
        if (b > a && b > c)
        {
            if (a > c)
            {
                Console.WriteLine("In descending order:");
                Console.WriteLine(b + "\n" + a + "\n" + c);
            }
            else
            {
                Console.WriteLine("In descending order:");
                Console.WriteLine(b + "\n" + c + "\n" + a);
            }
        }
        if (c > a && c > b)
        {
            if (a > b)
            {
                Console.WriteLine("In descending order:");
                Console.WriteLine(c + "\n" + a + "\n" + b);
            }
            else
            {
                Console.WriteLine("In descending order:");
                Console.WriteLine(c + "\n" + b + "\n" + a);
            }
        }        
    }
}

