using System;

class QuotationDifficulties
{
    static void Main()
    {
        /*Declare two string variables and assign them with following value:
         The "use" of quotations causes difficulties.
	     Do the above in two different ways: with and without using quoted strings.*/
        string firstWay = "The \"use\" of quotations causes difficulties.";
        string secondWay = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(firstWay + "\n" + secondWay);
    }
}

