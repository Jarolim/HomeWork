using System;

class FloatAndDouble
{
    static void Main()
    {
        /*Which of the following values can be assigned to a variable of type float and which to a 
         variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?*/
        float apprFloat1 = 12.345f;
        float apprFloat2 = 3456.091f;
        double apprDouble1 = 34.567839023f;
        double apprDouble2 = 8923.1234857;
        Console.WriteLine("Number is appropriate for float:" + apprFloat1);
        Console.WriteLine("Number is appropriate for float:" + apprFloat2);
        Console.WriteLine("Number is appropriate for double:" + apprDouble1);
        Console.WriteLine("Number is appropriate for double:" + apprDouble2);
    }
}

