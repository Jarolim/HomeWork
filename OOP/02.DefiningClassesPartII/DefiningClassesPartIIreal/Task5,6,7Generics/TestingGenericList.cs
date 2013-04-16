using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task 5 : Write a generic class GenericList<T> that keeps a list of elements of some parametric 
  type T. Keep the elements of the list in an array with fixed capacity which is given as parameter
  in the class constructor. Implement methods for adding element, accessing element by index, 
  removing element by index, inserting element at given position, clearing the list, finding 
  element by its value and ToString(). Check all input parameters to avoid accessing elements
  at invalid positions.*/

/*Task 6 : Implement auto-grow functionality: when the internal array is full, create a 
  new array of double size and move all elements to it.*/

/*Task 7 : Create generic methods Min<T>() and Max<T>() for finding the minimal and
  maximal element in the  GenericList<T>. You may need to add a generic constraints for the type T.*/
namespace Task5_6_7Generics
{
    class TestingGenericList
    {
        static void Main(string[] args)
        {
            /*Testing is it working!*/

            GenericList<int> testingGenerics = new GenericList<int>(1);

            // Getting elements:
            testingGenerics.AddElement(1);
            testingGenerics.AddElement(2);
            testingGenerics.AddElement(3);
            testingGenerics.AddElement(4);
            testingGenerics.AddElement(5);
            testingGenerics.AddElement(6);
            Console.WriteLine("The Array is: ");
            Console.WriteLine(testingGenerics);

            // Testing indexator:
            Console.Write("The int on index [3] is: ");
            Console.WriteLine(testingGenerics[3]);
            Console.Write("Changing it to 99: ");
            testingGenerics[3] = 99;
            Console.WriteLine(testingGenerics[3]);

            // Testing remove by index:
            Console.WriteLine();
            Console.WriteLine("Removing element [1]:");
            testingGenerics.RemoveElement(1);
            Console.Write("The new array is: ");
            Console.WriteLine(testingGenerics);

            // Testing the inserting by index:
            Console.WriteLine("Inserting a new element with index[0] = 100");
            testingGenerics.InsertElement(0, 100);
            Console.Write("The new array is: ");
            Console.WriteLine(testingGenerics);

            // Testing element counter:
            Console.WriteLine("The count of elements is: " + testingGenerics.Count);

            // Finding element:
            Console.Write("The element 3 is on index : ");
            Console.WriteLine(testingGenerics.FindElement(3));
            Console.WriteLine();

            //Testing to string
            Console.Write("To String: ");
            Console.WriteLine(testingGenerics.ToString());

            //Testing min & max element
            Console.WriteLine("Min element is: " + testingGenerics.MinElement());
            Console.WriteLine("Max element is: " + testingGenerics.MaxElement());
            Console.WriteLine();

            //clearing the list
            testingGenerics.Clear();
            Console.WriteLine("Cleared array: " + testingGenerics);
        }
    }
}
