using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Write a program that prints from given array of integers all numbers that 
  are divisible by 7 and 3. Use the built-in extension methods and lambda 
  expressions. Rewrite the same with LINQ.*/
namespace _06.DivisibleBy3and7
{
    class PrintDivisibleBy7And3Numbers
    {
        //Testing the methods:
        static void Main(string[] args)
        {
            int[] givenArray = new int[500];
            for (int i = 0; i < givenArray.Length; i++)
            {
                givenArray[i] = i;
            }
            Console.WriteLine("With lambda expressions: ");
            LambadaChecking(givenArray);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("With LINQ: ");
            LinqChecking(givenArray);
        }

        //Method with lambda:
        static void LambadaChecking(int[] someArr)
        {
            var numsAfterCheck = someArr.Where(x => x % 21 == 0);
            foreach (var number in numsAfterCheck)
            {
                Console.Write("{0} ",number);
            }
        }

        //Method with LINQ:
        static void LinqChecking(int[] someArr)
        {
            var numsAfterCheck =
                from number in someArr
                where number % 21 == 0
                select number;
            foreach (var number in numsAfterCheck)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }
    }
}
