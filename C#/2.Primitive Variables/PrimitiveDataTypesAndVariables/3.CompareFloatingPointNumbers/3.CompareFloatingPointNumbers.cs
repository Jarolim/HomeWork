using System;

class CompareFloatingPointNumbers
{
    static void Main()
    {
        /*Write a program that safely compares floating-point numbers with precision of 0.000001. 
          Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true*/
        float a = 5.3f;
        float b = 6.01f;
        float c = 5.00000001f;
        float d = 5.00000003f;
        bool compareFirst = (a == b);
        Console.WriteLine(compareFirst);
        bool compareSecond = (c == d);
        Console.WriteLine(compareSecond);
    }
}


