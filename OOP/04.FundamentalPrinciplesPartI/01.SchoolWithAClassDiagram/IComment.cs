using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolWithAClassDiagram
{
	public interface IComment
	{
		string[] Comments { get; }
		void AddComment(string comment);
	}
}
