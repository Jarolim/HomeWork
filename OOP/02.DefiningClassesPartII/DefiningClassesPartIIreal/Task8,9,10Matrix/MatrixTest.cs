using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixTest;
/*Task 8 : Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). */

/*Task 9 : Implement an indexer this[row, col] to access the inner matrix cells.*/

/*Task 10 : Implement the operators + and - (addition and subtraction of matrices of the 
  same size) and * for matrix multiplication. Throw an exception when the operation cannot 
  be performed. Implement the true operator (check for non-zero elements).*/
namespace MatrixTest
{
    class TestMatrix
    {
        static void Main(string[] args)
        {
            int[,] MatrixA = 
            { 
                { 1, 2, 3, 4 }, 
                { 5, 6, 7, 8 }, 
                { 9, 10, 11, 12 }, 
                { 13, 14, 15, 16 }, 
            };

            int[,] MatrixB = 
            { 
                { 4, 3, 2, 1 }, 
                { 8, 7, 6, 5 }, 
                { 4, 4, 4, 4 }, 
                { 3, 0, 3, 3 } 
            };
            Matrix<int> Amatrix = new Matrix<int>(MatrixA);
            Matrix<int> Bmatrix = new Matrix<int>(MatrixB);

            Console.WriteLine("A[,]=");
            Console.WriteLine();
            Matrix<int>.PrintMatrix(Amatrix);
            Console.WriteLine();

            Console.WriteLine("B[,]=");
            Console.WriteLine();
            Matrix<int>.PrintMatrix(Bmatrix);
            Console.WriteLine();

            Console.WriteLine("A[,]+B[,]=");
            Console.WriteLine();
            Matrix<int> sum = Amatrix + Bmatrix;
            Matrix<int>.PrintMatrix(sum);
            Console.WriteLine();

            Console.WriteLine("A[,]-B[,]=");
            Console.WriteLine();
            Matrix<int> substraction = Amatrix - Bmatrix;
            Matrix<int>.PrintMatrix(substraction);
            Console.WriteLine();

            Console.WriteLine("A[,]*B[,]=");
            Console.WriteLine();
            Matrix<int> multiplication = Amatrix * Bmatrix;
            Matrix<int>.PrintMatrix(multiplication);
            Console.WriteLine();
            
            if (Amatrix)
            {
                Console.WriteLine("MatrixA[,] does not have a zero element");
            }
            else
            {
                Console.WriteLine("MatrixA[,] has a zero element");
            }
            Console.WriteLine();
            if (Bmatrix)
            {
                Console.WriteLine("MatrixB[,] does not have a zero element");
            }
            else
            {
                Console.WriteLine("MatrixB[,] has a zero element");
            }
            Console.WriteLine();
        }

    }

}