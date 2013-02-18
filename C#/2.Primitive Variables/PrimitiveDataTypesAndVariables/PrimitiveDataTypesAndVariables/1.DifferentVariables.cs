using System;

class DifferentVariables
{
    static void Main()
    {
        /*Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, 
         short, ushort, int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.*/
        byte apprbyte = 97;
        sbyte apprsbyte = -115;
        short apprshort = -10000;
        ushort apprushort = 52130;
        int apprint = 4825932; // 4 825 932
        uint appruint = 4000000000; // 4 000 000 000 
        long apprlong = 9000000000000000000; // 9 000 000 000 000 000 000
        ulong apprulong = 18000000000000000000; // 18 000 000 000 000 000 000
        Console.WriteLine("the appropriate of : \n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}"
            , apprbyte, apprsbyte, apprshort, apprushort, apprint, appruint, apprlong, apprulong);
    }
}

