using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
	public class HTMLTables : HTMLElements, ITable
	{
		
		public int Rows
		{
			get { return this.Rows; }
		}

		public int Cols
		{
			get { return this.Cols; }
		}

		public IElement this[int row, int col]
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
