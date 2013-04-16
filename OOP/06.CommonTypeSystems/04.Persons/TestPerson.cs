using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program to test this functionality.
class TestPerson
{
    static void Main()
    {
        Person samuel = new Person("Samuel L. Jackson", 23);
        Person bambi = new Person("Bambi TheSmurf");
        Console.WriteLine(samuel);
        Console.WriteLine(bambi);
    }
}

