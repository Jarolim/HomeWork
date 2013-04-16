using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Define a class BitArray64 to hold 64 bit values inside an 
  ulong value. Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.*/
class BitArray64 : IEnumerable<uint>
{
    //Fields:
    private ulong number;
    private readonly byte[] bitArray = new byte[64];

    //Properties:
    public ulong Number
    {
        get
        {
            return number;
        }
        private set
        {
            number = value;
        }
    }

    //Constructors:
    public BitArray64(ulong number = 0)
    {
        this.Number = ConverToBitArray(number);
    }

    //Methods:
    private ulong ConverToBitArray(ulong number)
    {
        for (byte i = 0; i < 64; i++)
        {
            this.bitArray[i] = (byte)(number % 2);
            number /= 2;
        }
        return number;
    }

    public byte this[int key]
    {
        get
        {
            return this.bitArray[key];
        }
        set
        {
            if (value == 0 || value == 1)
            {
                this.bitArray[key] = value;
                ChangeNumber();
            }
            else
            {
                throw new ArgumentException("Bits contain only 0 and 1.");
            }
        }
    }

    private void ChangeNumber()
    {
        for (byte i = 0; i < 64; i++)
        {
            this.number += (ulong)(this.bitArray[i] << i);
        }
    }

    //Implement Equals(…)
    public override bool Equals(object obj)
    {
        BitArray64 bitArray = obj as BitArray64;

        if ((object)bitArray == null)
        {
            return false;
        }

        if (!Object.Equals(this.number, bitArray.number))
        {
            return false;
        }

        return true;
    }

    //Implement operator == 
    public static bool operator ==(BitArray64 firstNumber, BitArray64 secondNumber)
    {
        return BitArray64.Equals(firstNumber, secondNumber);
    }

    //Implement operator !=
    public static bool operator !=(BitArray64 firstNumber, BitArray64 secondNumber)
    {
        return !(BitArray64.Equals(firstNumber, secondNumber));
    }

    //Implement GetHashCode()
    public override int GetHashCode()
    {
        return this.number.GetHashCode() ^ this.bitArray.GetHashCode();
    }

    //Implement IEnumerable<int> 
    public IEnumerator<uint> GetEnumerator()
    {
        for (int i = this.bitArray.Length - 1; i >= 0; i--)
        {
            yield return this.bitArray[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
