using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolWithAClassDiagram
{
    public class Disciplines : IComment
    {
		 //Fields
		private string name;
		private int lecturesCount;
		private int exercisesCount;
		private List<string> comments;

		//Properties:
		public string Name
		{
		    get
		    {
		        return this.name;
		    }
		    set
		    {
		        this.name = value;
		    }
		}

		public int LecturesCount
		{
		    get
		    {
		        return this.lecturesCount;
		    }
		    set
		    {
		        this.lecturesCount = value;
		    }
		}

		public int ExercisesCount
		{
		    get
		    {
		        return this.exercisesCount;
		    }
		    set
		    {
		        this.exercisesCount = value;
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
		public Disciplines(string name, int lecturesCount, int exercisesCount)
		{
		    this.Name = name;
		    this.LecturesCount = lecturesCount;
		    this.ExercisesCount = exercisesCount;
		    this.comments = new List<string>();
		}

		//Methods:
		public void AddComment(string comment)
		{
		    this.comments.Add(comment);
		}
    }
}
