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
    public class GenericList<T> where T : IComparable
    {
        // Fields:
        public T[] List;
        public int currentElement = 0;
        
        // Constructors: 
        public GenericList(int capacity)
        {
            List = new T[capacity];
        }

        // Adding element:
        public void AddElement(T value)
        {
            if (currentElement == List.Length)
            {
                DoubleTheCapacity();
            }

            List[currentElement] = value;
            currentElement++;
        }

        //Accessing element by index:
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= currentElement)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return List[index];
                }
            }
            set
            {
                if (index < 0 || index >= currentElement)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    List[index] = value;
                }
            }
        }

        // Removing element by index:
        public void RemoveElement(int index)
        {
            if (index < 0 || index >= currentElement)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                T[] newArray = new T[List.Length];

                for (int i = 0; i < index; i++)
                {
                    newArray[i] = List[i];
                }

                for (int i = index + 1; i < currentElement; i++)
                {
                    newArray[i - 1] = List[i];
                }

                List = newArray;
                currentElement--;
            }
        }
        // Inserting element at given position:
        public void InsertElement(int index, T value)
        {
            if (index == List.Length)
            {
                DoubleTheCapacity();
            }

            if (index < 0 || index > currentElement)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                T[] newArray = new T[List.Length];

                for (int i = 0; i < index; i++)
                {
                    newArray[i] = List[i];
                }

                newArray[index] = value;

                for (int i = index; i < currentElement; i++)
                {
                    newArray[i + 1] = List[i];
                }

                List = newArray;
                currentElement++;
            }
        }

        //Clearing the list:
        public void Clear()
        {
            List = new T[4];
            currentElement = 0;
        }
        
        //Finding element by its value and ToString():
        public int FindElement<T>(T value)
        {
            int index = -1;

            for (int i = 0; i < currentElement; i++)
            {
                if (value.Equals(List[i]))
                {
                    return i;
                }
            }

            return index;
        }

        //ToString():
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < currentElement; i++)
            {
                output.Append(List[i] + " ");
            }

            output.AppendLine();

            return output.ToString();
        }

        //showing list's lenght
        public int Count
        {
            get { return currentElement; }
        }


        //Task 6 : create a new array of double size
        private void DoubleTheCapacity()
        {
            T[] doubleArray = new T[List.Length * 2];

            for (int i = 0; i < List.Length; i++)
            {
                doubleArray[i] = List[i];
            }

            List = doubleArray;
        }

        //Task 7 :
        //Minimum element:
        public T MinElement()
        {
            T minValue = List[0];

            for (int i = 0; i < currentElement; i++)
            {
                if ((dynamic)minValue > (dynamic)List[i])
                {
                    minValue = List[i];
                }
            }

            return minValue;
        }

        //Maximum element:
        public T MaxElement()
        {
            T maxValue = List[0];

            for (int i = 0; i < currentElement; i++)
            {
                if ((dynamic)maxValue < (dynamic)List[i])
                {
                    maxValue = List[i];
                }
            }

            return maxValue;
        }
    }
}
