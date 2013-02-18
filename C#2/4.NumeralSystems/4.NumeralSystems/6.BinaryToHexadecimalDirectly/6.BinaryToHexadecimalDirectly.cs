using System;
using System.Text;
 
class BinaryToHexadecimalDirectly
{
	/*Write a program to convert binary numbers to hexadecimal numbers (directly).*/
	static void Main()
    {
        string binar = "110101010101";
		string convert = BinaryHexadecimalDirectly(binar);
        Console.WriteLine(convert);
    }

	static string BinaryHexadecimalDirectly(string binar)
    {
        int strLength = binar.Length;
        StringBuilder str = new StringBuilder();
 
        for (int i = 0; i < strLength; i=i+4)
        {
            switch (binar.Substring(i, 4))
            {
                case "1010": str.Append("A"); break;
                case "1011": str.Append("B"); break;
                case "1100": str.Append("C"); break;
                case "1101": str.Append("D"); break;
                case "1110": str.Append("E"); break;
                case "1111": str.Append("F"); break;
                case "0000": str.Append("0"); break;
                case "0001": str.Append("1"); break;
                case "0010": str.Append("2"); break;
                case "0011": str.Append("3"); break;
                case "0100": str.Append("4"); break;
                case "0101": str.Append("5"); break;
                case "0110": str.Append("6"); break;
                case "0111": str.Append("7"); break;
                case "1000": str.Append("8"); break;
                case "1001": str.Append("9"); break;
            }  
        }
        return str.ToString();
    }
}
