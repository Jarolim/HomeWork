using System;

class ExchangeIntValues
{
    static void Main()
    {
        /*Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.*/
        int five = 5;
        int ten = 10;
        int swapper;
        swapper = five;
        five = ten;
        ten = swapper;
        Console.WriteLine(five);
        Console.WriteLine(ten);
        //This works but only for whole numbers
        //int Five = 5;
        //int Ten = 10;
        //Five = Five + Ten;
        //Ten = Five - Ten;
        //Five = Five - Ten;
    }
}

