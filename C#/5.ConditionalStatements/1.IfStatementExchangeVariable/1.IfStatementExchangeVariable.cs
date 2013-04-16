using System;

class IfStatementExchangeVariable
{
    static void Main()
    {
        /*Write an if statement that examines two integer variables and 
         exchanges their values if the first one is greater than the second one.*/
        Console.Write("Pleace enter first integer number: ");
        int FirstInt = int.Parse(Console.ReadLine());
        Console.Write("Pleace enter second integer number: ");
        int SecondInt = int.Parse(Console.ReadLine());

        int BiggerNumber = FirstInt;
        if (SecondInt > FirstInt)
        {
            BiggerNumber = SecondInt;
        }
		Console.WriteLine("The greater number is {0}", BiggerNumber);
    }
}

