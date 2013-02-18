using System;

class GetsNthenNPrintsSum
{
    static void Main()
    {
        /*Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum.*/
        Console.Write("Pleace enter the number of the integers 'n': ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Now enter '{0}' numbers", n);
        int othersN;
        int sumOfAll = 0;
        for (int i = 0; i < n; i++)
        {
            othersN = int.Parse(Console.ReadLine());
            sumOfAll = sumOfAll + othersN;
        }
        Console.WriteLine("The sum of the entered integers is {0}", sumOfAll);
    }
}

