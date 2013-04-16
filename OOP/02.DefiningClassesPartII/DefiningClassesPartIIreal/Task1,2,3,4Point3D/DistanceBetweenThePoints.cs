using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task 3 : Write a static class with a static method to calculate the distance 
  between two points in the 3D space.*/
namespace Task1_2_3_4Point3D
{
	class DistanceBetweenThePoints
	{
		public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
		{
			double distance = Math.Sqrt(Math.Pow((firstPoint.coordX - secondPoint.coordX), 2) + Math.Pow((firstPoint.coordY - secondPoint.coordY), 2) + Math.Pow((firstPoint.coordZ - secondPoint.coordZ), 2));

			return distance;
		}
	}
}
