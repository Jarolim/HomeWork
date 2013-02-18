using System;

class Input2IntegerAndPrintTheGreater
{
    static void Main()
    {
      /*Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.*/
      
        // 1. Without looking at the textbook
      // Console.Write("Pleace enter your first integer 'a' number: ");
      // int a = int.Parse(Console.ReadLine());
      // Console.Write("Pleace enter yotr second integer 'b' number: ");
      // int b = int.Parse(Console.ReadLine());
      // Console.Write("Number 'a' is greater than 'b' true or false: ");
      // Console.WriteLine(a>b == true);
        
        //Best
        
       Console.Write("Pleace enter your first integer 'a' number: ");
       int a = int.Parse(Console.ReadLine());
       Console.Write("Pleace enter yotr second integer 'b' number: ");
       int b = int.Parse(Console.ReadLine());
       Console.WriteLine("The greater number is {0}", Math.Max(a,b));

        //2.
      // Console.Write("Pleace enter your first integer 'a' number: ");
      // int a = int.Parse(Console.ReadLine());
      // Console.Write("Pleace enter yotr second integer 'b' number: ");
      // int b = int.Parse(Console.ReadLine());
      // Console.WriteLine("Greater: {0}", (a + b + Math.Abs(a - b)) / 2);
      // Console.WriteLine("Smaller: {0}", (a + b - Math.Abs(a - b)) / 2);

        //3.
      // Console.Write("Pleace enter your first integer 'a' number: ");
      // int a = int.Parse(Console.ReadLine());
      // Console.Write("Pleace enter yotr second integer 'b' number: ");
      // int b = int.Parse(Console.ReadLine());
      // int max = a - ((a - b) & ((a - b) >> 31));
      // Console.WriteLine("The greater number is {0}", max);
    }
}

