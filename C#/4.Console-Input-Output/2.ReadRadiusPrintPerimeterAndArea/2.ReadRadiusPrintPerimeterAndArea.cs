using System;

class ReadRadiusPrintPerimeterAndArea
{
    static void Main()
    {
        /*Write a program that reads the radius r of a circle and prints its perimeter and area.*/
        Console.Write("Pleace enter the radius of your circle: ");
        int R = int.Parse(Console.ReadLine());
        Console.Write("The perimeter of your circle is: ");
        Console.WriteLine(2*R*Math.PI);
        Console.Write("The area of your circle is: ");
        Console.WriteLine(R*R*Math.PI);
    }
}

