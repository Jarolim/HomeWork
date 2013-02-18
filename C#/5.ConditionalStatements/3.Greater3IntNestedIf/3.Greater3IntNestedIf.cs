using System;

class Greater3IntNestedIf
{
    static void Main()
    {
        //FIX NESTED IF
        /*Write a program that finds the biggest of three integers using nested if statements.*/
        Console.Write("Pleace enter first integer number: ");
        int FirstInt = int.Parse(Console.ReadLine());
        Console.Write("Pleace enter second integer number: ");
        int SecondInt = int.Parse(Console.ReadLine());
        Console.Write("Pleace enter third integer number: ");
        int ThirdInt = int.Parse(Console.ReadLine());

        if (FirstInt > SecondInt && FirstInt > ThirdInt)
        {
            Console.WriteLine("{0} is greater then the others", FirstInt);            
        }
        if (SecondInt > FirstInt && SecondInt > ThirdInt)
        {
            Console.WriteLine("{0} is greater then the others", SecondInt);
        }
        if (ThirdInt > FirstInt && ThirdInt > SecondInt)
        {
            Console.WriteLine("{0} is greater then the others", ThirdInt);
        }
    }
}

