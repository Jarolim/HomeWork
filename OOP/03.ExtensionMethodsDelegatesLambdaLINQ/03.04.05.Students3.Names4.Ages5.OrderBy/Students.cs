using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task 3 : Write a method that from a given array of students finds all students whose 
  first name is before its last name alphabetically. Use LINQ query operators.*/

/*Task 4 : Write a LINQ query that finds the first name and last name of all students
  with age between 18 and 24.*/

/*Task 5 : Using the extension methods OrderBy() and ThenBy() with lambda expressions 
  sort the students by first name and last name in descending order. Rewrite the same with LINQ.*/
namespace Students
{
    public class Student
    {
        // Fields:
        private string firstName;
        private string lastName;
        private byte? age;

        //Constructors: 
        public Student(string firstName, string lastName)
            : this(firstName, lastName, null)
        {
        }

        public Student(string firstName, string lastName, byte? age)
        {
            if (age < 0 || age > 150)
            {
                throw new ArgumentException("Realy?");
            }
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        //Properties:
        public string FirstName 
        { 
            get 
            { 
                return this.firstName; 
            }
        }

        public string LastName 
        { 
            get 
            {
                return this.lastName; 
            } 
        }

        public byte? Age
        {

            get 
            { 
                return this.age; 
            }
            set
            {
                if (age < 0 || age > 150)
                {
                    throw new ArgumentException("Realy?");
                }
                this.age = value;
            }
        }

        //Methods:

        //Printing the students on the console:
        public static void printStudents(Student[] students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        //Getting students using LINQ query operators:
        public static void GetStudents(Student[] students)
        {
            var newStudents =
               from student in students
               where student.FirstName.CompareTo(student.LastName) <= 0
               select student;
            printStudents(newStudents.ToArray());
        }

        //Overriding to string:
        public override string ToString()
        {
            return string.Format(this.FirstName + " " + this.LastName + " " + this.Age);
        }
    }
}
