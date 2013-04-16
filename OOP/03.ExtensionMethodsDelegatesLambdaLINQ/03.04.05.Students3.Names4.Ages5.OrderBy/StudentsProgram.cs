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
    class StudentsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 3:");
            Console.WriteLine("-------");
            Student[] students =
            {
                new Student("Samuel", "Jackson",48), // He is infinite! but will get an exeption :/
                new Student("Luke", "Skywalker",23),
                new Student("Denis", "Belqta",9),
                new Student("Gugen", "Gugenheim",69),
                new Student("Hulio","Iglesias",42)
            };
            Student.GetStudents(students);
            Console.WriteLine();
            Console.WriteLine("=======================================");


            Console.WriteLine("Task 4:");
            Console.WriteLine("-------");
            var normalAgeStudents =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student;
            Student.printStudents(normalAgeStudents.ToArray());
            Console.WriteLine("=======================================");


            Console.WriteLine("Task 5:");
            Console.WriteLine("-------");
            Console.WriteLine("Using lambda expressions: ");
            Console.WriteLine();
            var descendingOrderStudents = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);
            Student.printStudents(descendingOrderStudents.ToArray());
            Console.WriteLine();
              
            //Rewrite the same with LINQ.
            Console.WriteLine("Using LINQ: ");
            Console.WriteLine();
            var descendingOrderStudentsByLINQ =
                from student in students
                orderby student.FirstName descending,
                student.LastName descending
                select student;
            Student.printStudents(descendingOrderStudentsByLINQ.ToArray());
            Console.WriteLine("=======================================");
        }
    }
}