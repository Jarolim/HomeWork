using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolWithAClassDiagram
{
    public class Students : People , IComment
    {
       //Fields:
		private int classNumber;
		private List<string> comments;

		//Properties:
		public int ClassNumber
		{
			get 
			{
				return this.classNumber;
			}
			set 
			{
				this.classNumber = value;
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
       public Students(string name, int classNumber)
           : base(name)
       {
           this.ClassNumber = classNumber;
		   this.comments = new List<string>();
       }

		//Methods:
	   public void AddComment(string comment)
	   {
		   this.comments.Add(comment);
	   }
    }
}
