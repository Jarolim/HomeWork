using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMatrix
{
    // Task8: DefineClassMatrix
    public class Matrix<T>
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private int Row { get; set; }
        public int Col { get; set; }
        private T[,] matrix;

        // Task9: ImplementIndexer
        public T this[int row, int col]
        {
            get
            {
                return matrix[row, col];
            }
            set
            {
                matrix[row, col] = value;
            }
        }

        // Task10: ImplementOperatorsAddSubMultiple
        public Matrix(int row, int col)
        {
            if ((row < 0) || (col < 0))
            {
                throw new ArgumentOutOfRangeException("Row and col index must be POSITIVE!");
            }
            else
            {
                matrix = new T[row, col];
            }
        }
        //Row and Col fields take matrix row and col values
        public Matrix(T[,] matrix)
        {
            this.matrix = matrix;
            Row = matrix.GetLength(0);
            Col = matrix.GetLength(1);
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if ((first.Row == second.Row) && (first.Col == second.Col))
            {
                Matrix<T> theSum = new Matrix<T>(first.Row, first.Col);
                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < first.Col; j++)
                    {
                        {
                            theSum[i, j] = (dynamic)first[i, j] + (dynamic)second[i, j];
                        }
                    }
                }
                return theSum;
            }
            else
            {
                throw new ArgumentException("The matrix which wont to '+' must be with SAME SIZE!");
            }
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if ((first.Row == second.Row) && (first.Col == second.Col))
            {
                Matrix<T> theSubstraction = new Matrix<T>(first.Row, first.Col);
                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < first.Col; j++)
                    {
                        {
                            theSubstraction[i, j] = (dynamic)first[i, j] - (dynamic)second[i, j];
                        }
                    }
                }
                return theSubstraction;
            }
            else
            {
                throw new ArgumentException("The matrix which wont to '-' must be with SAME SIZE!");
            }
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Col == second.Row)
            {
                Matrix<T> multiplyResult = new Matrix<T>(first.Row, second.Col);
                for (int i = 0; i < multiplyResult.Row; i++)
                {
                    for (int j = 0; j < multiplyResult.Col; j++)
                    {
                        multiplyResult[i, j] = (dynamic)0;
                        for (int k = 0; k < first.Col; k++)
                        {
                            {
                                multiplyResult[i, j] = multiplyResult[i, j] + (dynamic)first[i, k] * (dynamic)second[k, j];
                            }
                        }
                    }
                }
                return multiplyResult;
            }
            else
            {
                throw new ArgumentException("Matrix can not be multiplied MUST FIRST(ROWS)=SECOND(COLS)!");
            }
        }
        public static Boolean operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
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
                for (int j = 0; j < matrix.Col; j++)
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
                    Console.Write("{0,-6}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
