using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
	public class HTMLElements : IElement
	{
		public string Name
		{
			get { return this.Name ; }
		}

		public string TextContent
		{
			get
			{
				return this.TextContent;
			}
			set
			{
				this.TextContent = value;
			}
		}

		public IEnumerable<IElement> ChildElements
		{
			get { throw new NotImplementedException(); }
		}

		public void AddElement(IElement element)
		{
			throw new NotImplementedException();
		}

		public void Render(StringBuilder output)
		{
			StringBuilder result = new StringBuilder();
			result.Append("<");
			result.Append(this.GetType().Name);
			result.Append(">");
			result.Append("(");
			result.Append(this.GetType());
			result.Append(")");
		}
		public override string ToString()
		{
			return "rfgd";
		}
	}
}
