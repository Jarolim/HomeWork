using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolWithAClassDiagram
{
	public class Teachers : People, IComment
	{
		//Fields:
		public List<Disciplines> disciplines;
		public List<string> comments;

		//Properties:
		public Disciplines[] Disciplines
		{
			get
			{
				return this.disciplines.ToArray();
			}
			private set
			{
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
		public Teachers(string name, Disciplines[] disciplines)
			: base(name)
		{
			this.disciplines = new List<Disciplines>(disciplines);
			this.comments = new List<string>();
		}

		//Methods:
		public void AddDiscipline(Disciplines discipline)
		{
			this.disciplines.Add(discipline);
		}

		public void RemoveDiscipline(Disciplines discipline)
		{
			this.disciplines.Remove(discipline);

		}

		public void AddComment(string comment)
		{
			this.comments.Add(comment);
		}
	}
}
