using System;

class PrintSequence
{
    static void Main()
    {
        for (int i = 2; i <= 11; i++)
        {
            Console.WriteLine((i) * Math.Pow(-1, i));
        }
    }
}
