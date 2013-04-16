using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolWithAClassDiagram
{
	public class ClassRoom : IComment
	{
		//Fields:
		private List<Students> students;
		private List<Teachers> teachers;
		private string identifier;
		private List<string> comments;

		//Properties
		public Students[] Students
		{
		    get
		    {
		        return this.students.ToArray();
		    }
		    private set 
		    {
		    }
		}

		public Teachers[] Teachers
		{
		    get
		    {
		        return this.teachers.ToArray();
		    }
		    private set 
		    { 
		    }
		}

		public string Identifier
		{
		    get
		    {
		        return this.identifier;
		    }
		    set
		    {
		        this.identifier = value;
		    }
		}

		public string[] Comments
		{
		    get
		    {
		        return this.comments.ToArray();
		    }
		}

		//Constructors:
		public ClassRoom(Students[] students, Teachers[] teachers, string id)
		{
		    this.students = new List<Students>(students);
		    this.teachers = new List<Teachers>(teachers);
			this.Identifier = identifier;
		    this.comments = new List<string>();
		}

		//Methods:
		public void AddStudent(Students student) 
		{
		    this.students.Add(student);
		}

		public void RemoveStudent(Students student)
		{
		    this.students.Remove(student);
		}

		public void AddTeacher(Teachers teacher)
		{
		    this.teachers.Add(teacher);
		}

		public void RemoveTeacher(Teachers teacher)
		{
		    this.teachers.Remove(teacher);
		}

		public void AddComment(string comment)
		{
		    this.comments.Add(comment);
		}
	}
}
