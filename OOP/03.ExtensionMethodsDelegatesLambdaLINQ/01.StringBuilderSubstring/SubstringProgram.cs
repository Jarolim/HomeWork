using System;
using System.Text;
/*Implement an extension method Substring(int index, int length) for the class 
  StringBuilder that returns new StringBuilder and has the same functionality 
  as Substring in the class String.*/
namespace StringBuilderSubstring
{
    class StringBuilderSubstringTest
    {
        static void Main()
        {
            // Testing the substring class in StringBuilder: 
            StringBuilder testing = new StringBuilder();
            testing.Append("GugenheimAgugu");
            Console.WriteLine(testing.Substring(9, 5).ToString());
        }
    }
}
