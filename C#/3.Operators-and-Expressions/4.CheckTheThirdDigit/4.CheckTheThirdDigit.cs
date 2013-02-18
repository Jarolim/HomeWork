using System;

class CheckTheThirdDigit
{
    static void Main()
    {
        Console.WriteLine("Pleace enter number:");
        int Num = int.Parse(Console.ReadLine());
        int Num100 = Num / 100;
        Console.WriteLine(Num100 % 10 == 7);
    }
}

