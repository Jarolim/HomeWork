using System;

class GreatestCommonDivider
{
    static void Main()
    {
        /*Write a program that calculates the greatest common divisor (GCD) 
         of given two numbers. Use the Euclidean algorithm (find it in Internet).*/
        int firstNumber;
        int secondNumber;
		while (true)
        {
            Console.Write("Enter first number = ");
            string Value = Console.ReadLine();
            bool ResultN = int.TryParse(Value, out firstNumber);
            Console.Write("Enter second number = ");
            Value = Console.ReadLine();
            bool ResultK = int.TryParse(Value, out secondNumber);
            if ((ResultN == true) && (ResultK == true))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid numbers. Try again:");
            }
        }
        if (firstNumber < secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }
        int Remainder;
        while (secondNumber != 0)
        {
            Remainder = firstNumber % secondNumber;
            firstNumber = secondNumber;
            secondNumber = Remainder;
        }
        Console.WriteLine("The GCD is: {0}", firstNumber);
    }
}

