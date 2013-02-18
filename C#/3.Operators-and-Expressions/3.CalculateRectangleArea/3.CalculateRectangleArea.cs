using System;

class CalculateRectangleArea
{
    static void Main()
    {
        Console.WriteLine("Pleace enter rectangles width:");
        decimal Width = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Pleace enter rectangles height:");
        decimal Height = decimal.Parse(Console.ReadLine());
        decimal Area = Width * Height;
        Console.WriteLine("The Area of your rectangle is:{0}", Area);
    }
}

