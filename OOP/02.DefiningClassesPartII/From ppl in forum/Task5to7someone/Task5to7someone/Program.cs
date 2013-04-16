using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static void Main()
    {
        GenericList<int> array = new GenericList<int>(8);
        array.Add(5);
        array.Add(8);
        array.Add(3);
        array.InsertAt(88, 3);
        array.Add(33);
        array.InsertAt(1337, 3);
        array.InsertAt(1338, 7);
        string result = array.ToString();
    }
}