using System;

class FactorielDevidedByK
{   
    static void Main()
    {
        /*Write a program that calculates N!/K! for given N and K (1<N<K).*/
        Console.Write("Pleace enter N!: ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Pleace enter K!: ");
        int K = int.Parse(Console.ReadLine());
        decimal result = 1;
        for (int i = N; i > K; i--)
        {
            result = result * i;
        }
        Console.WriteLine("N!/K! = {0}", result);
    }
}

