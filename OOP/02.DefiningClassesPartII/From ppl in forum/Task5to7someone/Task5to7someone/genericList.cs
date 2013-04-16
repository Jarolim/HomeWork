using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GenericList<T> where T : IComparable
{
    private T[] container;
    private int size; //the max size of the container
    private int count = 0; //the current count of elements in the container, cant be higher than size
    private int lastSeqIndex = -1; //the last index of element added in the container IN A SEQUENCE
    private bool[] notEmptyIndicator; //used when inserting at position to indicate wheter we need
    //or dont need to move elements - indicates is there an element at the position we want to insert
    //also when deleting an element we will just mark it as empty here. When showing elements we will show only those
    //that are not empty

    //constructor
    public GenericList(int size)
    {
        this.container = new T[size];
        this.notEmptyIndicator = new bool[size];
        this.size = size;
    }

    //override indexer
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentException("Index out f range");
            }
            return container[index];
        }
    }

    //check if the container is full and thus needs to be resuzed
    private bool IsFull()
    {
        if (this.count >= this.size)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //doubles the size of the container while retains the already stored values
    //it also resizes the empty indicator and retains its values
    private void Resize()
    {
        T[] tempHolder = new T[this.size];
        bool[] tempEmpty = new bool[this.size];
        for (int i = 0; i < this.size; i++)
        {
            tempHolder[i] = this.container[i];
            tempEmpty[i] = this.notEmptyIndicator[i];
        }

        this.size = this.size * 2;
        this.container = new T[this.size];
        this.notEmptyIndicator = new bool[this.size];
        for (int i = 0; i < tempHolder.Length; i++)
        {
            this.container[i] = tempHolder[i];
            this.notEmptyIndicator[i] = tempEmpty[i];
        }
    }

    //checks if there is a sequence of elements preceeding the passed index
    //this is needed when removing an element from the cointainer
    //we need to know if we are destroying a sequence and modify the
    //the index of the last sequential element
    private bool SequenceBefore(int beforeIndex)
    {
        for (int i = beforeIndex - 1; i >= 0; i--)
        {
            if (this.notEmptyIndicator[i] == false)
            {
                return false; //no sequence up to the passed index
            }
        }

        return true; //there is a sequence before the passed index 
    }

    //returns the index of the first empty place in the container
    //if it does not find such place => the container is full after the passed index
    //and the method will return -1
    //this is needed when inserting element to decide if we need to resize the container
    private int FullAfter(int index)
    {
        for (int i = index + 1; i < this.size; i++)
        {
            if (notEmptyIndicator[i] == false)
            {
                return i;
            }
        }

        return -1;
    }

    //used to move elements from the index we want to the first empty index
    private void Move(int insertionIndex, int firstEmptyIndex)
    {
        for (int i = firstEmptyIndex; i > insertionIndex; i--)
        {
            this.container[i] = this.container[i - 1];
            this.notEmptyIndicator[i] = this.notEmptyIndicator[i - 1];
        }
    }

    //add an element to the container
    public void Add(T value)
    {
        if (IsFull() == false)
        {
            //the idea is to keep the index of the last added element in a sequence in 
            //container and increase this index, each time a new value is added
            int index = lastSeqIndex + 1;// this should be the first empty place
            //in case it is not (because of element insertion) we find the first empty space
            while (index < size && notEmptyIndicator[index] == true)
            {
                index++;
            }

            if (index < size)
            {
                container[index] = value;
                notEmptyIndicator[index] = true; //mark the element at this index as not empty
                this.lastSeqIndex = index; //update the last seq index;
                this.count++;
            }
            else
            {
                Resize();
                Add(value);
            }

        }
        else
        {
            Resize();
            Add(value);
        }
    }

    //"removes" an element from the list
    public void RemoveAt(int index)
    {
        //check if the index is in range
        if (index < 0 || index >= size)
        {
            throw new ArgumentException("Index out of range");
        }

        this.notEmptyIndicator[index] = false; //mark that there is no element at this position

        //if the position we are inserting to is preceeded by a sequence we
        //modify the index of the last sequential element
        if (SequenceBefore(index) == true)
        {
            this.lastSeqIndex = index - 1;
        }

        this.count--;
    }


    public void InsertAt(T value, int index)
    {
        //check if the index is in range
        if (index < 0 || index >= this.size)
        {
            throw new ArgumentException("Index out of range");
        }

        if (this.notEmptyIndicator[index] == false) //there is no element at the position we want to insert to
        {
            //inserting
            this.container[index] = value;
            this.notEmptyIndicator[index] = true;//set the element to full
            this.count++;
        }
        else
        {
            //if the containerr is entirelly full or if its full from the insertion point onwards
            //we need to resuze it and then insert
            if (IsFull() == true || FullAfter(index) == -1)
            {
                Resize();
            }

            //inserting
            int feia = FullAfter(index); //first empty index after the index we want to insert at
            Move(index, feia);
            this.container[index] = value;
            this.notEmptyIndicator[index] = true;//set the element to full
            count++;
        }
    }

    //clears the container
    //the full indicator
    //and resets the last sequential index
    public void Clear()
    {
        this.container = new T[this.size];
        this.notEmptyIndicator = new bool[this.size];
        this.lastSeqIndex = -1;
        this.count = 0;
    }

    //the n00b way, better implement "in place" search algorithm thingy later
    public int Find(T value)
    {
        int indexOfValue = -1;
        for (int i = 0; i < this.size; i++)
        {
            if (this.container[i].CompareTo(value) == 0)
            {
                return i;
            }
        }

        return indexOfValue; //element not found
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder(size * 2);
        for (int i = 0; i < size; i++)
        {
            if (this.notEmptyIndicator[i] == true)
            {
                result.Append(container[i].ToString());
                result.Append(" ");
            }
        }
        return result.ToString();
    }

    //finds the maxiumal element
    public T Max()
    {
        T max = this.container[0];
        for (int i = 1; i < size; i++)
        {
            if (this.container[i].CompareTo(max) > 0)
            {
                max = this.container[i];
            }
        }

        return max;
    }

    //finds the minimal element
    public T Min()
    {
        T min = this.container[0];
        for (int i = 1; i < size; i++)
        {
            if (this.container[i].CompareTo(min) < 0)
            {
                min = this.container[i];
            }
        }

        return min;
    }
}
