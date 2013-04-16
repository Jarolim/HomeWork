using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
/*Using delegates write a class Timer that has can execute certain method at each t seconds.*/
namespace TimerUsingDelegates
{
    public delegate void TimerDelegate();   // declare delegate

    public class Timer
    {
        static void Main()
        {
            //The program:
            Timer.RepeatWithDuritationMethod(Print, 2, 4);
            Console.WriteLine("...DAAAAARY!");
            Console.WriteLine("Legendary!!!");
        }

        // Method to print:
        public static void Print()
        {
            Console.WriteLine("Legen...  wait for it!");
        }

        // Method to help repeat print method after some time with duration:
        public static void RepeatWithDuritationMethod(TimerDelegate method, int seconds, long durationInSeconds)
        {
            long start = 0;
            while (start <= durationInSeconds)
            {
                method();
                Thread.Sleep(seconds * 2000);
                start += seconds;
            }

        }    
    }
    
}
