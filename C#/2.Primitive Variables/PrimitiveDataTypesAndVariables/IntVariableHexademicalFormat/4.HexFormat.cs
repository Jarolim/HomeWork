using System;

class HexFormat
{
    static void Main()
    {
        /*Declare an integer variable and assign it with the value
         254 in hexadecimal format. Use Windows Calculator to find its hexadecimal representation.*/
        int variableDec = 254;
        int variableHex = 0xFE;
        Console.WriteLine(variableDec);
        Console.WriteLine(variableHex);
        Console.WriteLine(variableHex == variableDec);
    }
}

