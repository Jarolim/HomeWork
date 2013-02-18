using System;

class CompanyDetails
{
    static void Main()
    {
        /*A company has name, address, phone number, fax number, web site and manager. 
          The manager has first name, last name, age and a phone number. Write a program 
          that reads the information about a company and its manager and prints them on the console.*/
        string companyName;
        Console.Write("Enter name of the company: ");
        companyName = Console.ReadLine();
        string companyAddress;
        Console.Write("Enter the address of the company: ");
        companyAddress = Console.ReadLine();
        uint companyPhone;
        Console.Write("Enter company's phone number: ");
        companyPhone = uint.Parse(Console.ReadLine());
        uint companyFax;
        Console.Write("Enter company's fax: ");
        companyFax = uint.Parse(Console.ReadLine());
        string companyWebSite;
        Console.Write("Enter compnay's website: ");
        companyWebSite = Console.ReadLine();
        string managerFirstName;
        Console.Write("Enter manager's first name: ");
        managerFirstName = Console.ReadLine();
        string managerFamilyName;
        Console.Write("Enter manager's family name: ");
        managerFamilyName = Console.ReadLine();
        byte managerAge;
        Console.Write("Enter manager's age: ");
        managerAge = byte.Parse(Console.ReadLine());
        uint managerPhone;
        Console.Write("Enter manager's phone number: ");
        managerPhone = uint.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Name: {0}\nAddress: {1}\nPhone: {2}\nFax:{3}\nWebSite:{4}\nManager's first name: {5}\nManager's last name: {6}\nManager's Age: {7}\nManager's phone number: {8}"
            , companyName, companyAddress, companyPhone, companyFax, companyWebSite, managerFirstName, managerFamilyName, managerAge, managerPhone);
    }
}

