using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.WriteLine("Pleace enter trapezoid short side a:");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Pleace enter trapezoid long side b:");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Pleace enter trapezoid heigth h:");
        int h = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The Area of your trapezoid is:");
        Console.WriteLine((a+b)/2*h);
    }
}

