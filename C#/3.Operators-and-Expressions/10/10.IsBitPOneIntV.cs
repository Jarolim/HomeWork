using System;

class IsBitPOneIntV
{
    static void Main()
    {
        Console.Write("Pleace enter your number: ");
        int Number = int.Parse(Console.ReadLine());
        Console.Write("Pleace enter your bit position(p-th): ");
        int BitPosition = int.Parse(Console.ReadLine());

        int Mask = 1 << BitPosition; // 8 = 0000 0000 1000
        int NumberAndMask = Number & Mask;
        int bit = NumberAndMask >> BitPosition;
        bool Check = (bit == 0);

        if (Check == true)
        {
            Console.WriteLine("p-th bit is 0");
        }
        else
        {
            Console.WriteLine("p-th bit is 1");
        }
    }
}

