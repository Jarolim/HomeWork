using System;

class EmployeesTrack
{
    static void Main()
    {
        /*A marketing firm wants to keep record of its employees. 
          Each record would have the following characteristics – 
          first name, family name, age, gender (m or f), 
          ID number, unique employee number (27560000 to 27569999). 
          Declare the variables needed to keep the information for a
          single employee using appropriate data types and descriptive names.*/
        string FirstName = "Ivan";
        string FamilyName = "Ivanov";
        byte Age = 57;
        char Gender = 'm';
        uint IDNumber = 1955668899;
        uint UniqueEmployeeNum = 27561111;
        Console.WriteLine("Employee: {0} {1} \nAge: {2} \nGender: {3} \nID: {4} \nUnique Employee Number: {5}"
            , FirstName, FamilyName, Age, Gender, IDNumber, UniqueEmployeeNum);
    }
}
