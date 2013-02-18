using System;

class PrintFirst100membersOfFibonacci
{
    static void Main()
    {
        /*Write a program to print the first 100 members of the sequence of Fibonacci:
          0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …*/
        ulong firstFib = 0;
        ulong secondFib = 1;
        
        ulong temp;
        ulong fibonacci = firstFib + secondFib;
        Console.WriteLine(firstFib);
        Console.WriteLine(secondFib);
        Console.WriteLine(fibonacci);
        for (int i = 1; i <= 100; i++)
        {
            temp = firstFib;
            firstFib = secondFib;
            secondFib = secondFib + temp;
            fibonacci = firstFib + secondFib;
            Console.WriteLine(fibonacci);
        }

      // Using the golden ratio
      // double nerf1 = 1.61803398874989484820;
      // double nerf2 = 0.61803398874989484820;
      // 
      // for (int n=0 ; n < 100; n++)
      // {
      //     Console.WriteLine(((Math.Pow(nerf1,n))-(Math.Pow(-nerf2,n)))/Math.Sqrt(5));  // Using the Golden Ratio   
      // }         
    }
}

