using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Define two new classes Triangle and Rectangle that implement the virtual 
  method and return the surface of the figure (height*width for rectangle 
  and height*width/2 for triangle). */
namespace _01.Shapes
{
	class Rectangle : Shape
	{
		//Constructors:
		public Rectangle(decimal width, decimal heigth)
		{
			if (width <= 0 || heigth <= 0)
			{
				throw new ArgumentOutOfRangeException("Parameters of shapes can not be with zero or negative values!");
			}
			else
			{
				this.Width = width;
				this.Heigth = heigth;
			}
		}

		//Methods:
		public override decimal CalculateSurface()
		{
			return this.Width * this.Heigth;
		}
	}
}
