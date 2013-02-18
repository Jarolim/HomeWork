using System;

class Unicode72
{
    static void Main()
    {
        /*Declare a character variable and assign it with the symbol that has Unicode code 72.
          Hint: first use the Windows Calculator to find the hexadecimal representation of 72.*/
        int charVar = 72;
        Console.WriteLine("The code of '{0}' is: {1}", charVar, (char)charVar);
        char unicodeOf72 = '\u0048';
        Console.WriteLine(unicodeOf72);
    }
}

