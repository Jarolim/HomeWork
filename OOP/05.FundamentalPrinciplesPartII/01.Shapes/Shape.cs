using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height. */
abstract class Shape
{
	//Fields:
	private decimal width;
	private decimal heigth;

	//Properties:
	public decimal Width { get; set; }
	public decimal Heigth { get; set; }

	//Methods:
	public abstract decimal CalculateSurface();
}
