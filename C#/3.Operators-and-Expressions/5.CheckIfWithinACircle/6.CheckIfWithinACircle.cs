using System;

class CheckIfWithinACircle
{
    static void Main()
    {
        Console.WriteLine("Pleace Enter the coordinates of your point:");
        Console.Write("x=");
        double x = double.Parse(Console.ReadLine());
        Console.Write("y=");
        double y = double.Parse(Console.ReadLine());
        double circle = Math.Sqrt(x*x+y*y);
        
        if (circle < 5)
        {
            Console.WriteLine("Your point is in the circle");
        }
        else 
        {
            Console.WriteLine("Your point is out of the circle");
        }
    }
}

