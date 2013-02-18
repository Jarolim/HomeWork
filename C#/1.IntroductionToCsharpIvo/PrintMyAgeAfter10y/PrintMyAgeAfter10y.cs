using System;

class PrintMyAgeAfter10y
{
    static void Main()
    {
        Console.Write("Pleace enter your birthday year: ");
        int birthyear; 
        birthyear= int.Parse(Console.ReadLine());
        int currentyear=DateTime.Now.Year;
        Console.Write("Your age is: ");
        Console.WriteLine((currentyear) - (birthyear));
        int age = ((currentyear) - (birthyear));
        Console.Write("Your age in ten years will be: ");
        Console.WriteLine(age + 10);
    }
}
