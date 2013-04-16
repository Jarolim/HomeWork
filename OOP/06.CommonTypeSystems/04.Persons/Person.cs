using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Create a class Person with two fields – name and age. Age can be left 
  unspecified (may contain null value. Override ToString() to display 
  the information of a person and if age is not specified – to say so. 
  Write a program to test this functionality.*/
class Person
{
    //Two fields name and age
    public string Name { get; set; }
    public byte? Age { get; set; }

    public Person(string name)
        : this(name, null)
    {

    }

    //Constructors:
    public Person(string name, byte? age)
    {
        if (name == string.Empty || name == null)
        {
            throw new ArgumentOutOfRangeException("Invalid name. You did not enter name , please do so!");
        }
        else
        {
            this.Name = name;
        }
        if (age < 0 || age > 125)
        {
            throw new ArgumentOutOfRangeException("Invalid age. Interesting ... are you realy that old?");
        }
        else
        {
            this.Age = age;
        }

    }

    //Override ToString() to display the information of a person and if age is not specified – to say so.
    public override string ToString()
    {
        return string.Format("The name of the person is: {0} \nHis age is: {1}", this.Name, ((this.Age.ToString() != "") ? this.Age.ToString() : "Not Specified"));
    }
}

