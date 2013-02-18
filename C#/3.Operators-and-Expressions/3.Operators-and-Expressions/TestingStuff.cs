using System;

class Program
{
    static void Main()
    {
        int a = 3;
        int b = 5;
        int result = a+++ ++b;
        Console.WriteLine("{0} {1} {2}", ++a, b++, --result);
    }
}


