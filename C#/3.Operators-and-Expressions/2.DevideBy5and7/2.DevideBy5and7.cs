using System;

class DevideBy5and7
{
    static void Main()
    {
        Console.Title = "Can it be devided by 5 and 7?";
        Console.WriteLine("Please input a whole number:");
        int WholeNumber = int.Parse(Console.ReadLine());
        bool CheckWith5 = (WholeNumber % 5 == 0);
        bool CheckWith7 = (WholeNumber % 7 == 0);
            
        if (CheckWith5 == true && CheckWith7 == true)
        {
            Console.WriteLine("Your number can be devided by 5 and 7 at the same time");
        }
        else
        {
            Console.WriteLine("Your number can't be devided by 5 and 7 at the same time");
        }
    }
}

