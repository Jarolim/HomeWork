using System;

class ThirdBit0or1
{
    static void Main()
    {       
        Console.Write("Pleace enter your number: ");
        int Number = int.Parse(Console.ReadLine());
        int BitPosition = 3;        
        int Mask = 1 << BitPosition; // 8 = 0000 0000 1000
        int NumberAndMask = Number & Mask; 
        int bit = NumberAndMask >> BitPosition;
        bool Check = (bit == 0);

        if (Check == true)
        {
            Console.WriteLine("3rd bit is 0");
        }
        else
        {
            Console.WriteLine("3rd bit is 1");
        }
    }
}

