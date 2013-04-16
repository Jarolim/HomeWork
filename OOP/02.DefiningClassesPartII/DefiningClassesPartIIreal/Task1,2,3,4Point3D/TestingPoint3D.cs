using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task 1 : Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the
  Euclidian 3D space. Implement the ToString() to enable printing a 3D point.*/

/*Task 2 : Add a private static read-only field to hold the start of the 
  coordinate system – the point O{0, 0, 0}. Add a static property to return the point O.*/

/*Task 3 : Write a static class with a static method to calculate the distance 
  between two points in the 3D space.*/

/*Task 4 : Create a class Path to hold a sequence of points in the 3D space.
  Create a static class PathStorage with static methods to save and load paths 
  from a text file. Use a file format of your choice.*/

namespace Task1_2_3_4Point3D
{
	class TestingPoint3D
	{
		static void Main(string[] args)
		{
			//Creating a new instance of Point3D
			Point3D myFirstPoint = new Point3D(1, 2, 3);
            Point3D mySecondPoint = new Point3D(4, 5, 6);
            Point3D myThirdPoint = new Point3D(7, 8, 9);

			//Testing the overrite of ToString()
            Console.WriteLine("First point:");
			Console.WriteLine(myFirstPoint.ToString());

            //Testing the calculating of the distance
			Console.WriteLine("The distance between X,Y,Z is: {0}", DistanceBetweenThePoints.CalculateDistance(myFirstPoint, Point3D.Center));

			//Testing the static property Center
            Console.WriteLine();
            Console.WriteLine("Testing the center point: ");
			Console.WriteLine(Point3D.Center.ToString());

            //Testing the Path class
            Path myPath = new Path();

            //Intializing the PathList with new List<Point3d>()
            myPath.PathList = new List<Point3D>();

            //Adding some points:
            myPath.PathList.Add(myFirstPoint);
            myPath.PathList.Add(mySecondPoint);
            myPath.PathList.Add(myThirdPoint);
            myPath.PathList.Add(Point3D.Center);
            Console.WriteLine();
            Console.WriteLine("The Path Points are:");
            foreach (Point3D item in myPath.PathList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            //Removing a point:
            myPath.PathList.Remove(Point3D.Center);
            Console.WriteLine("The Path Points after removing the center:");
            foreach (Point3D item in myPath.PathList)
            {
                Console.WriteLine(item.ToString());
            }

            //PathStorage - Loading
            Path loadedPath = PathStorage.Load("../../PathLoads.txt");

            //05. PathStorage - Saving
            PathStorage.Write(loadedPath, "../../PathSaves.txt");
		}
	}
}
