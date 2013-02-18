using System;
using System.Text;

class TriangleSimbol
{
    static void Main()    
    {
        /*Write a program that prints an isosceles triangle of 9 copyright symbols ©.
         Use Windows Character Map to find the Unicode code of the © symbol. Note: 
         the © symbol may be displayed incorrectly.*/
        Console.OutputEncoding = Encoding.UTF8;
        char copyWritesymbol = '\u00A9';
        Console.WriteLine("{0}{0}{0}{0}{0} \n  {0}{0}{0} \n    {0}", copyWritesymbol);
    }
}

