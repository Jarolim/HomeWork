using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolWithAClassDiagram
{
    public class People
    {
        //Fields:
		public string name;
		
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
        //Constructors:
        public People(string name)
        {
            this.Name = name;
        }       
    }
}
