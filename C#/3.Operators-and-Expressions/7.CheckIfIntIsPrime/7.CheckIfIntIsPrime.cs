using System;

class CheckIfIntIsPrime
{
    static void Main()
    {
        Console.Write("Pleace enter the number you want to check: ");
        int n = int.Parse(Console.ReadLine());
        int i;
        bool isPrime = true;
        for (i = 2; i < n; i++)
        {
            if (n != i && n % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime == true && n != 0 && n != 1)
        {
            Console.WriteLine("The number {0} is prime", n);
        }
        else
        {
            Console.WriteLine("The number {0} is not prime", n);
        }
    }
}

