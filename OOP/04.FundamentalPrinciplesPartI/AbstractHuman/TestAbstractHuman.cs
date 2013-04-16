using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Define abstract class Human with first name and last name. Define new 
  class Student which is derived from Human and has new field – grade. 
  Define class Worker derived from Human with new property WeekSalary
  and WorkHoursPerDay and method MoneyPerHour() that returns money earned 
  by hour by the worker. Define the proper constructors and properties for
  this hierarchy. Initialize a list of 10 students and sort them by grade
  in ascending order (use LINQ or OrderBy() extension method). Initialize
  a list of 10 workers and sort them by money per hour in descending order. 
  Merge the lists and sort them by first name and last name.*/
namespace AbstractHuman
{
	class TestAbstractHuman
	{
		static void Main(string[] args)
		{
			//Initialize a list of 10 students ...
			Student student1 = new Student("Samuel", "Jackson", 2);
			Student student2 = new Student("Peter", "Parker", 3);
			Student student3 = new Student("John", "Malkivich", 4);
			Student student4 = new Student("Droid", "Drosos", 5);
			Student student5 = new Student("Pinko", "Thepink", 6);
			Student student6 = new Student("Falsh", "Kunev", 2);
			Student student7 = new Student("Kuncho", "Chlenav", 3);
			Student student8 = new Student("Munio", "Marashov", 4);
			Student student9 = new Student("Dragan", "Ignaatov", 5);
			Student student10 = new Student("Ignat", "Stamatov", 6);

			List<Student> students = new List<Student> { student1, student2, student3, student4, student5, student6, student7, student8, student9, student10 };
			
			//...and sort them by grade in ascending order

			//Using lambda:
			var orderByGrade = students.OrderBy(x => x.Grade).ThenBy(x => x.GetFirstName());
			foreach (var student in orderByGrade)
			{
				Console.WriteLine(student);
			}
			Console.WriteLine();

			//Initialize a list of 10 workers ... 
			Worker worker1 = new Worker("Papi", "Ganev", 155.3,5);
			Worker worker2 = new Worker("Umbro", "Gandov", 166.6, 6);
			Worker worker3 = new Worker("Banq", "Valdes", 555.55, 7);
			Worker worker4 = new Worker("Radka", "Gashtite", 666.66, 8);
			Worker worker5 = new Worker("Mara", "Stoilova", 444.44, 14);
			Worker worker6 = new Worker("Dundio", "Vulev", 169.33, 13);
			Worker worker7 = new Worker("Kuno", "Bambov", 255, 12);
			Worker worker8 = new Worker("Daril", "Marin", 123.36, 11);
			Worker worker9 = new Worker("Mara", "Kalushkata", 558.36, 10);
			Worker worker10 = new Worker("Lando", "Venkov", 555.66, 9);

			List<Worker> workers = new List<Worker>{worker1, worker2, worker3, worker4, worker5, worker6, worker7, worker8, worker9, worker10};

			//...and sort them by money per hour in descending order.
			var orderBySalaryPerHour = workers.OrderByDescending(x => x.MoneyPerHour());
			foreach (var worker in orderBySalaryPerHour)
			{
				Console.WriteLine(worker);
			}
			Console.WriteLine();

			//Merge the lists and sort them by first name and last name.
			List<dynamic> merge = new List<dynamic>(students.Concat<dynamic>(workers));

			// With lambda:
			Console.WriteLine("Sorting by FirstName and LastName: (with lambda) :");
			Console.WriteLine();
			var both =
				merge.OrderBy(x => x.GetFirstName()).ThenBy(x => x.GetLastName());

			foreach (var item in both)
			{
				Console.Write(item.GetFirstName());
				Console.WriteLine(" " + item.GetLastName());
			}
			Console.WriteLine();

			// With LINQ:
			Console.WriteLine("Sorting by FirstName and LastName: (with LINQ) :");
			Console.WriteLine();
			var both2 =
				from element in merge
				orderby element.GetFirstName(), element.GetLastName()
				select element;

			foreach (var item in both2)
			{
				Console.Write(item.GetFirstName());
				Console.WriteLine(" " + item.GetLastName());
			}
		}
	}
}
