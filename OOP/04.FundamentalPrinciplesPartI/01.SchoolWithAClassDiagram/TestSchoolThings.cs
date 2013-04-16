using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*We are given a school. In the school there are classes of students. 
  Each class has a set of teachers. Each teacher teaches a set of 
  disciplines. Students have name and unique class number. Classes 
  have unique text identifier. Teachers have name. Disciplines have
  name, number of lectures and number of exercises. Both teachers and
  students are people. Students, classes, teachers and disciplines 
  could have optional comments (free text block).

  Your task is to identify the classes (in terms of  OOP) and their
  attributes and operations, encapsulate their fields, define the class
  hierarchy and create a class diagram with Visual Studio.*/
namespace _01.SchoolWithAClassDiagram
{
    class TestSchoolThings
    {
        static void Main(string[] args)
        {
			Students student1 = new Students("Hulio", 14 );
			Students student2 = new Students("Fabio", 14);
			Students student3 = new Students("Gangnam", 14 );
			Students student4 = new Students("Oktavio", 14);
			Students student5 = new Students("Marko", 14);

			Students[] students = new Students[] { student1, student2, student3 , student4, student5 };
			
			Disciplines displine1 = new Disciplines("History",30,30);
			Disciplines displine2 = new Disciplines("Biology", 30, 30);
			Disciplines displine3= new Disciplines("Algebra", 30, 30);
			Disciplines displine4 = new Disciplines("CivilEngeneering", 30, 30);
			Disciplines displine5 = new Disciplines("Programming", 30, 30);

			Teachers teacher1 = new Teachers("Vili Vucov", new Disciplines[] { displine1, displine2,displine3,displine4,displine5 });
			Teachers teacher2 = new Teachers("Samuel Jackson", new Disciplines[] { displine1, displine2, displine3, displine4, displine5 });
			Teachers teacher3 = new Teachers("Bill Gates", new Disciplines[] { displine1, displine2, displine3, displine4, displine5 });

			Teachers[] teachers = new Teachers[] { teacher1, teacher2, teacher3 };

			ClassRoom class1 = new ClassRoom(students, teachers, "8B");

			
			Console.WriteLine("The discipline is: " + class1.Teachers[2].Disciplines[2].Name);
			Console.WriteLine("The teacher is: " + class1.Teachers[2].Name);
			//Adding a comment
			student1.AddComment("Banana");
			Console.WriteLine("Comment of a student: " + student1.Comments[0]);
        }
    }
}
