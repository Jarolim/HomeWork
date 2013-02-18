using System;

class ShowTheSIgnOf3IntMultiplied
{
    static void Main()
    {
        /*Write a program that shows the sign of the product of 
         three real numbers without calculating it. Use a sequence of if statements.*/
        Console.Write("Pleace enter first integer number: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Pleace enter second integer number: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Pleace enter third integer number: ");
        double c = double.Parse(Console.ReadLine());

        int test = 0;

        if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine("If you multiply the 3 integers you'll get a 0");
        }
        else
        {
            if (a < 0)
            {
                test++;            
            }
            if (b < 0)
            {
                test++;
            }
            if (c < 0)
            {
                test++;
            }        
            if (test % 2 == 0)
            {
                Console.WriteLine("If you multiply the 3 integers you'll get a '+' sign");
            }
            else
            {
                Console.WriteLine("If you multiply the 3 integers you'll get a '-' sign");
            }
        }
               
    }
}
