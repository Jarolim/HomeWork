using System;
using System.Collections.Generic;
using System.Linq;
/*Implement a set of extension methods for IEnumerable<T> that implement the 
  following group functions: sum, product, min, max, average.*/
public static class Extensions
{
    // Implement : sum function
    public static decimal Sum<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() <= 0)
        {
            throw new ArgumentException("There must be atleast one element!");
        }
        decimal sum = 0;
        foreach (var element in enumeration)
        {
            sum += Convert.ToDecimal(element);
        }
        return sum;
    }

    //Implement : product function
        public static decimal Product<T>(this IEnumerable<T> enumeration)
        {
            if (enumeration.Count() <= 0)
            {
                throw new ArgumentException("There must be atleast one element!");
            }
            decimal product = 1;
            foreach (var element in enumeration)
            {
                product *= Convert.ToDecimal(element);
            }
            return product;
        } 

    //Implement : min function
    public static decimal Min<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() <= 0)
        {
            throw new ArgumentException("There must be atleast one element!");
        }
        decimal min = decimal.MaxValue;
        foreach (var element in enumeration)
        {
            if (Convert.ToDecimal(element) < min)
            {
                min = Convert.ToDecimal(element);
            }
        }
        return min;
    }

    //Implement : max function
    public static decimal Max<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() <= 0)
        {
            throw new ArgumentException("There must be atleast one element!");
        }
        decimal max = decimal.MinValue;
        foreach (var element in enumeration)
        {
            if (Convert.ToDecimal(element) > max)
            {
                max = Convert.ToDecimal(element);
            }
        }
        return max;
    }

    //Implement : average function
    public static decimal Average<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() <= 0)
        {
            throw new ArgumentException("There must be atleast one element!");
        }
        decimal sum = 0;
        foreach (var item in enumeration)
        {
            sum += Convert.ToDecimal(item);
        }
        return sum / enumeration.Count();
    }
}