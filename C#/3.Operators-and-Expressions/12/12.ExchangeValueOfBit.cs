using System;

class ExchangeValueOfBit
{
    static void Main()
    {
        Console.Write("Please enter number n: ");
        int number = int.Parse(Console.ReadLine()); 
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.Write("Please enter bit position p: ");
        byte position = byte.Parse(Console.ReadLine());
        Console.Write("Please enter value of bit: ");
        byte value = byte.Parse(Console.ReadLine());
        int mask = 1;
        mask = mask << position;
        number = number & ~mask;
        number = number | (value << position);
        Console.WriteLine(number);
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
    }
}

