using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestStudent
{
    static void Main()
    {
        Student stud1 = new Student("Samuel", "L.", "Jackson", 14362, "Klokotnica 17",
            "555", "a@a.bg", University.Harvard, Faculty.Engineering, Speciality.ComputerScience, 1);

        Console.WriteLine("Original student -  " + stud1);

        Student cloned = stud1.Clone();

        Console.WriteLine("Cloned student - {0}", cloned);

        Console.WriteLine("First and Cloned are the same students: {0}", stud1.Equals(cloned));

        Console.WriteLine(new string('*', 70));

        cloned.SSN = 55555;
        Console.WriteLine("Cloned  - {0} with changed SSN", cloned);
        Console.WriteLine("Original of the cloned -  {0}", stud1);

        Console.WriteLine("First and Cloned are the same students after the change of SSN of cloned: {0}", stud1.Equals(cloned));
        Console.WriteLine(new string('*', 70));

        Console.WriteLine("Other 3 students:");
        Student stud2 = new Student("Gugi", "Dudev", "Mudev", 13555, "Klokotnica 17",
            "555", "a@a.bg", University.Blumingdales, Faculty.Sciences, Speciality.Mathemathics, 2);
        Console.WriteLine(stud2);
        Student stud3 = new Student("Damqn", "Ignatiev", "Djambazov", 17555, "Klokotnica 17",
            "555", "a@a.bg", University.MIT, Faculty.Medicine, Speciality.DentalMedicine, 2);
        Console.WriteLine(stud3);
        Student stud4 = new Student("Sandra", "The", "Smurf", 18555, "Klokotnica 17",
            "555", "a@a.bg", University.Brown, Faculty.Philosophy, Speciality.Informatics, 2);
        Console.WriteLine(stud4);

        List<Student> sortedStudents = new List<Student>();
        sortedStudents.Add(stud1);
        sortedStudents.Add(stud2);
        sortedStudents.Add(cloned);
        sortedStudents.Add(stud3);
        sortedStudents.Add(stud4);

        sortedStudents.Sort();

        Console.WriteLine(new string('*', 70));
        Console.WriteLine("The sorted students are:");

        foreach (var student in sortedStudents)
        {
            Console.WriteLine(student);
        }
    }
}

