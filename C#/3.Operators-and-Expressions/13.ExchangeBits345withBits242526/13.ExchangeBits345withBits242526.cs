using System;

class ExchangeBits345withBits242526
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        int mask242526 = 7; // 0000 0111
        int mask345 = 7; // 0000 0111
        int maskNull = 7; // 0000 0111
        mask242526 = mask242526 << 24;
        mask242526 = (int)(mask242526 & number);
        mask242526 = mask242526 >> 24;
        mask345 = mask345 << 3;
        mask345 = (int)(mask345 & number);
        mask345 = mask345 >> 3;
        number = (uint)(~(maskNull << 24) & number);
        number = (uint)(~(maskNull << 3) & number);
        number = (uint)((uint)(mask345 << 24) | number);
        number = (uint)((uint)(mask242526 << 3) | number);
        Console.WriteLine(number);
    }
}

