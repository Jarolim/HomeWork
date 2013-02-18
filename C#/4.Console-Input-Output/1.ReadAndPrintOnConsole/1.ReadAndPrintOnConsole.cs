using System;

class ReadAndPrintOnConsole
{
    static void Main()
    {
        /*Write a program that reads 3 integer numbers from the console and prints their sum.*/
        Console.WriteLine("Pleace input integer numbers a,b and c:");
        Console.Write("a=");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b=");
        int b = int.Parse(Console.ReadLine());
        Console.Write("c=");
        int c = int.Parse(Console.ReadLine());
        Console.Write("a+b+c=");
        Console.WriteLine(a + b + c);
    }
}

