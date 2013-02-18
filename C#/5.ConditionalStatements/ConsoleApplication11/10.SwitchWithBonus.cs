using System;

class SwitchWithBonus
{
    static void Main()
    {
        /*Write a program that applies bonus scores to given scores in the range [1..9]. 
         * The program reads a digit as an input. If the digit is between 1 and 3, 
         * the program multiplies it by 10; if it is between 4 and 6, multiplies it by 100;
         * if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value is not a digit,
         * the program must report an error.
		Use a switch statement and at the end print the calculated new value in the console.*/
        Console.Title = "Switch practice";
        Console.Write("Input a digit from 1 to 9: ");
        string Value = Console.ReadLine();
        int n;
        bool parse = int.TryParse(Value, out n);
        switch (Value)
        {
            case "1":
            case "2":
            case "3":
                n = n * 10;
                break;
            case "4":
            case "5":
            case "6":
                n = n * 100;
                break;
            case "7":
            case "8":
            case "9":
                n = n * 1000;
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
        Console.WriteLine("Score : {0}", n);     
    }
}

