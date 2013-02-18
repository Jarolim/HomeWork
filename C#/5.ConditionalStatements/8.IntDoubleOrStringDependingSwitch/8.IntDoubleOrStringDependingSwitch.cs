using System;

class IntDoubleOrStringDependingSwitch
{
    static void Main()
    {
        /*Write a program that, depending on the user's choice inputs int, double or string variable.
         If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end.
         The program must show the value of that variable as a console output. Use switch statement.*/
        Console.Write("Pleace enter your choice '1 for int' , '2 for double' or '3 for string': ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.Write("Enter int variable: ");
                int intVariable = int.Parse(Console.ReadLine());
                Console.WriteLine(intVariable + 1);
                break;                
            case 2:
                Console.Write("Enter double variable: ");
                double doubleVariable = double.Parse(Console.ReadLine());
                Console.WriteLine(doubleVariable + 1);
                break;               
            case 3:
                Console.Write("Enter string variable: ");
                string stringVariable = Console.ReadLine();
                Console.WriteLine(stringVariable + "*");
                break;               
            default:
                Console.WriteLine("Incorrect input !");
                break;
        }
    }
}

