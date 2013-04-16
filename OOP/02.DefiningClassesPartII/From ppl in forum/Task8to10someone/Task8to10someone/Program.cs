using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMatrix;

namespace TestMatrix
{
    class TestMatrix
    {
        static void Main(string[] args)
        {
            int[,] firstOne = 
            { 
                { 1, 1, 1, 1 }, 
                { 7, 2, 1, 4 }, 
                { 1, 2, 3, 4 }, 
                { 1, 8, 3, 9 }, 
            };
            
            int[,] secondOne = 
            { 
                { 1, 2, 78, 7 }, 
                { 7, 2, 7, 4 }, 
                { 8, 3, 3, 5 }, 
                { 1, 0, 8, 4 } 
            };
            Matrix<int> first = new Matrix<int>(firstOne);
            Matrix<int> second = new Matrix<int>(secondOne);

            if (first)
            {
                Console.WriteLine("There are no zeros in first[,]");
            }
            else
            {
                Console.WriteLine("There are some zeros in first[,]");
            }

            if (second)
            {
                Console.WriteLine("There are no zeros in second[,]");
            }
            else
            {
                Console.WriteLine("There are some zeros in second[,]");
            }

            Console.WriteLine();
            Console.WriteLine("first[,]");
            Matrix<int>.PrintMatrix(first);
            Console.WriteLine();

            Console.WriteLine("second[,]");
            Matrix<int>.PrintMatrix(second);
            Console.WriteLine();

            Console.WriteLine("first[,]+second[,]=");
            Matrix<int> sum = first + second;
            Matrix<int>.PrintMatrix(sum);
            Console.WriteLine();

            Console.WriteLine("first[,]-second[,]=");
            Matrix<int> substraction = first - second;
            Matrix<int>.PrintMatrix(substraction);
            Console.WriteLine();

            Console.WriteLine("first[,]*second[,]=");
            Matrix<int> multiplication = first * second;
            Matrix<int>.PrintMatrix(multiplication);
        }

    }

}
