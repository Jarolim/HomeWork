using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task 8 : Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). */

/*Task 9 : Implement an indexer this[row, col] to access the inner matrix cells.*/

/*Task 10 : Implement the operators + and - (addition and subtraction of matrices of the 
  same size) and * for matrix multiplication. Throw an exception when the operation cannot 
  be performed. Implement the true operator (check for non-zero elements).*/
namespace MatrixTest
{
    public class Matrix<T> where T : struct, IComparable<T>, IFormattable, IConvertible, IEquatable<T>
    {
        // Fields for the matrix:
        public int Row { get; set; }
        public int Column { get; set; }
        private T[,] matrix;

        //Properties:
        public T this[int rows, int columns]
        {
            get
            {
                return matrix[rows , columns];
            }
            set 
            {
                matrix[rows, columns] = value;
            }
        }

        // Constructors:
        public Matrix(int rows, int columns)
        {
            if (rows < 0 || columns < 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive number!");
            }
            else
            {
                matrix = new T[rows, columns];
            }          
        }

        public Matrix(T[,] matrix)
        {
            this.matrix = matrix;
            Row = matrix.GetLength(0);
            Column = matrix.GetLength(1);
        }

        // (+)addition
        public static Matrix<T> operator +(Matrix<T> MatrixA, Matrix<T> MatrixB)
        {
            if ((MatrixA.Row == MatrixB.Row) && (MatrixA.Column == MatrixB.Column))
	        {
                Matrix<T> theSum = new Matrix<T>(MatrixA.Row, MatrixA.Column);
                for (int i = 0; i < MatrixA.Row; i++)
			    {
			        for (int j = 0; j < MatrixA.Column; j++)
                    {
                        {
                            theSum[i, j] = (dynamic)MatrixA[i, j] + (dynamic)MatrixB[i, j];
                        }
                    }
			    }
                return theSum;
	        }
            else
            {
                throw new ArgumentException("The two matrixes must be the same size in order to summerise them!");
            }
        }

        // (-)substraction
        public static Matrix<T> operator -(Matrix<T> MatrixA, Matrix<T> MatrixB)
        {
            if ((MatrixA.Row == MatrixB.Row) && (MatrixA.Column == MatrixB.Column))
            {
                Matrix<T> theSubstraction = new Matrix<T>(MatrixA.Row, MatrixA.Column);
                for (int i = 0; i < MatrixA.Row; i++)
                {
                    for (int j = 0; j < MatrixA.Column; j++)
                    {
                        {
                            theSubstraction[i, j] = (dynamic)MatrixA[i, j] - (dynamic)MatrixB[i, j];
                        }
                    }
                }
                return theSubstraction;
            }
            else
            {
                throw new ArgumentException("The two matrixes must be the same size in order to substract them!");
            }
        }

        // (*)multiplication
        public static Matrix<T> operator *(Matrix<T> MatrixA, Matrix<T> MatrixB)
        {
            if (MatrixA.Column == MatrixB.Row)
            {
                Matrix<T> multiplyResult = new Matrix<T>(MatrixA.Row, MatrixB.Column);
                for (int i = 0; i < multiplyResult.Row; i++)
                {
                    for (int j = 0; j < multiplyResult.Column; j++)
                    {
                        multiplyResult[i, j] = (dynamic)0;
                        for (int k = 0; k < MatrixA.Column; k++)
                        {
                            {
                                multiplyResult[i, j] = multiplyResult[i, j] + (dynamic)MatrixA[i, k] * (dynamic)MatrixB[k, j];
                            }
                        }
                    }
                }
                return multiplyResult;
            }
            else
            {
                throw new ArgumentException("Matrixes can not be multiplied unless first(Rows)=second(Columns)!");
            }
        }


        public static Boolean operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Column; j++)
                {
                    if ((dynamic)matrix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public static Boolean operator false(Matrix<T> matrix)
        {
            int zeroChecker = 0;
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Column; j++)
                {
                    if ((dynamic)matrix[i, j] == zeroChecker)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void PrintMatrix(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.matrix.GetLength(1); j++)
                {
                    Console.Write("{0, -4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
