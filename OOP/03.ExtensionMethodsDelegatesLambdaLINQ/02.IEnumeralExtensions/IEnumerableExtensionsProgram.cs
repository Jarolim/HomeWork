using System;
using System.Collections.Generic;
using System.Linq;
/*Implement a set of extension methods for IEnumerable<T> that implement the 
  following group functions: sum, product, min, max, average.*/
class IEnumeralExtensions
{
    static void Main(string[] args)
    {
        try
        {
            //Testing the extensions
            IEnumerable<uint> listNumbers = new uint[] { 5, 10, 15, 20, 25, 30, 35, 40, 45 , 50};
            Console.WriteLine("Sum: {0}", listNumbers.Sum<uint>());
            Console.WriteLine("Product: {0}", listNumbers.Product<uint>());
            Console.WriteLine("Min: {0}", listNumbers.Min<uint>());
            Console.WriteLine("Max: {0}", listNumbers.Max<uint>());
            Console.WriteLine("Average: {0}", listNumbers.Average<uint>());
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error!" + exception.Message);
        }

    }
}