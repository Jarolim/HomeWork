using System;
/*Create a [Version] attribute that can be applied to structures, classes, interfaces, 
  enumerations and methods and holds a version in the format major.minor (e.g. 2.11). 
  Apply the version attribute to a sample class and display its version at runtime.*/
//Thanks to kristina.bankova

//Where can I use the attribute (and not allowing to have multiple attributes):
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]

public class VersionAttribute : System.Attribute
{
    //Fields and Properties:
    public int Major { get; set; }
    public int Minor { get; set; }

    //Costructor:
    public VersionAttribute(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
    }
}
[VersionAttribute(2, 11)]
//Declaring the class on which I will apply the attribute: 
class VersionDemo
{
    static void Main()
    {
        Type type = typeof(VersionDemo);
        object[] versionAttributes = type.GetCustomAttributes(false);
        foreach (VersionAttribute versionAttribute in versionAttributes)
        {
            Console.WriteLine("The version of the class VersionDemo is {0}.{1}",
                versionAttribute.Major, versionAttribute.Minor);
        }
        Console.WriteLine();
    }
}
