using System;

class Program
{
    static void Main()
    {
        /*Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...*/
        double sum = 1;
        double temp = 0;
        sbyte k = 1;
        double absolute;
        for (double i = 2; ; i++)
        {
            sum += 1 / (i * k);
            k *= (-1);
            absolute = Math.Abs(sum - temp);
            if (absolute < 0.001)
            {
                Console.WriteLine(sum);
                Console.WriteLine("{0:F3}", sum);
                break;
            }
            temp = sum;
        }     
    }
}

