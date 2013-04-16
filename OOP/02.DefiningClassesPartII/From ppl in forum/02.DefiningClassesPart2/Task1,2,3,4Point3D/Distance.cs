using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class Distance
{

	public static double Calculate(Point3D firstPoint, Point3D secondPoint)
	{
		//Math.Sqrt returns double type
		//using the formula SqrRoot((x1-x2)^2+(y1-y2)^2+(z1-z2)^2)
		double distance = Math.Sqrt(Math.Pow((firstPoint.XCoord - secondPoint.XCoord), 2) + Math.Pow((firstPoint.YCoord - secondPoint.YCoord), 2) + Math.Pow((firstPoint.ZCoord - secondPoint.ZCoord), 2));

		return distance;
	}

}