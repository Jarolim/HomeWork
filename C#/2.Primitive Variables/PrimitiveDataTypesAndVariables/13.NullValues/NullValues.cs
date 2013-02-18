using System;

class NullValues
{
    static void Main()
    {
        /*Create a program that assigns null values to an integer and to double variables.
          Try to print them on the console, try to add some values or the null literal to them and see the result.*/
        int? someInteger = null;
        Console.WriteLine("This is the integer with Null value -> " + someInteger);
        double? someDouble = null;
        Console.WriteLine("This is the real number with Null value -> " + someDouble);
        int? someIntegerPlusValue = someInteger + 5;
        Console.WriteLine("This happens when I try to add ->" + someIntegerPlusValue);
        someInteger = 5;
        Console.WriteLine("This is the integer with value 5 -> " + someInteger);
    }
}

