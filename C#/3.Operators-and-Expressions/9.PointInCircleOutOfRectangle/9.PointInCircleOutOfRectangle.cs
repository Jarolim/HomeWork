using System;

class PointInCircleOutOfRectangle
{
    static void Main()
    {
        Console.WriteLine("Pleace Enter the coordinates of your point:");
        Console.Write("x=");
        double x = double.Parse(Console.ReadLine());
        Console.Write("y=");
        double y = double.Parse(Console.ReadLine());

        double xCircle = x - 1;
        double yCircle = y - 1;

        bool circle = Math.Sqrt(xCircle * xCircle + yCircle * yCircle) <=3;
        bool rectangle = (x >= -1) && (x <= 5) && (y <= 1) && (y >= -1);

        Console.Write(circle ? "Your point is within the circle and " : "Your point is outside of the circle and ");
        Console.WriteLine(rectangle ? "within the rectangle." : "outside of the rectangle.");     
    }
}
