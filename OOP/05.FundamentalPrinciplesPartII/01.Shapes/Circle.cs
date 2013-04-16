using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Define class Circle and suitable constructor so that at initialization height
  must be kept equal to width and implement the CalculateSurface() method. */
namespace _01.Shapes
{
	class Circle : Shape
	{
		//Constructors:
		public Circle(decimal radius)
		{
			if (radius <= 0)
			{
				throw new ArgumentOutOfRangeException("Parameters of shapes can not be with zero or negative values!");
			}
			else
			{
				this.Width = radius;
				this.Heigth = radius;
			}

		}

		//Methods:
		public override decimal CalculateSurface()
		{
			return this.Width * this.Width * (decimal)Math.PI;
		}
	}
}
