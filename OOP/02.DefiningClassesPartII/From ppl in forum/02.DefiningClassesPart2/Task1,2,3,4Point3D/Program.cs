﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Point3DClass
{

	static void Main(string[] args)
	{
		//01.creating a new instance of Point3D
		Point3D myPoint = new Point3D(4, 2, 1);

		//01.testing the overrite of ToString()
		Console.WriteLine(myPoint.ToString());

		//02.testing the static property Center
		Console.WriteLine(Point3D.Center.ToString());

		//03. testing the calculating of the distance
		Console.WriteLine("The distance is: {0}", Distance.Calculate(myPoint, Point3D.Center));
		Path myPath = new Path();


		//04. testing the Path class
		//intializing the PathList with new List<Point3d>()
		myPath.PathList = new List<Point3D>();
		//adding several points
		myPath.PathList.Add(myPoint);
		myPath.PathList.Add(Point3D.Center);

		Console.WriteLine("The Path Points after adding:");
		foreach (Point3D item in myPath.PathList)
		{
			Console.WriteLine(item.ToString());
		}

		//removing a point
		myPath.PathList.Remove(Point3D.Center);
		Console.WriteLine("The Path Points after removing the center:");
		foreach (Point3D item in myPath.PathList)
		{
			Console.WriteLine(item.ToString());
		}

		//04. PathStorage - LOAD
		Path loadedPath = PathStorage.Load("../../loadingpoints.txt");

		//05. PathStorage - Write
		PathStorage.Write(loadedPath, "../../savedpoints.txt");
	}
}