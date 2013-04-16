using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestBitArray
{
    static void Main(string[] args)
    {
        //Print a number as binary
        BitArray64 number = new BitArray64(3556);

        foreach (var bit in number)
        {
            Console.Write(bit);
        }
        Console.WriteLine();


        //fill some part of the array with 1 and print again(test [] and setter part + ChangeNumber method)
        for (int i = 63; i >= 50; i--)
        {
            number[i] = 1;
        }
        foreach (var bit in number)
        {
            Console.Write(bit);
        }
        Console.WriteLine();



        //Test maxValue... of course minValue will not work !!
        BitArray64 number2 = new BitArray64(ulong.MaxValue);

        foreach (var bit in number2)
        {
            Console.Write(bit);
        }
        Console.WriteLine();
    }
}
