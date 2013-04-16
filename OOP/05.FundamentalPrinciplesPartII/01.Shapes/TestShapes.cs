using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Write a program that tests the behavior of  the CalculateSurface() method
  for different shapes (Circle, Rectangle, Triangle) stored in an array.*/
namespace _01.Shapes
{
	class TestShapes
	{
		static void Main(string[] args)
		{
			//Testing the shapes : 
			Shape[] shapes = new Shape[3];
			shapes[0] = new Triangle(5, 5);
			shapes[1] = new Rectangle(10, 10);
			shapes[2] = new Circle(15);

			//Printing on the console:
			foreach (var shape in shapes)
			{
				Console.WriteLine("The surface of the {0} is {1:F2}.",shape.GetType().Name, shape.CalculateSurface());
			}
		}
	}
}
