using System;

class FromIntGivesUaBit
{
    static void Main()
    {
        Console.Write("Pleace enter your number i: ");
        int i = int.Parse(Console.ReadLine());
        Console.Write("Pleace enter your bit position(b): ");
        int b = int.Parse(Console.ReadLine());

        int Mask = 1 << b; // 8 = 0000 0000 1000
        int NumberAndMask = i & Mask;
        int bit = NumberAndMask >> b;
        bool Check = (bit == 0);

        if (Check == true)
        {
            Console.WriteLine("b-th bit is 0");
        }
        else
        {
            Console.WriteLine("b-th bit is 1");
        }
    }
}

