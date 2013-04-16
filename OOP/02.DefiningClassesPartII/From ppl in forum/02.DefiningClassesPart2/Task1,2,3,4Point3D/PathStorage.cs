using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

static class PathStorage
{
	public static Path Load(string source)
	{
		Path loadedPath = new Path();
		//initializing the PathList
		loadedPath.PathList = new List<Point3D>();
		char[] splittingChars = { '[', ']', ' ', ',' };
		using (StreamReader sourceFile = new StreamReader(source))
		{
			//read the first line of the file to check is it null
			string line = sourceFile.ReadLine();

			while (line != null)
			{
				//splitting the data to get array of the points
				string[] splittedString = line.Split(splittingChars, StringSplitOptions.RemoveEmptyEntries);
				//creating int variables to parse the coordinates of the Point3D(int, int, int);
				int xCoord, yCoord, zCoord;
				//parsing the coordinates
				xCoord = int.Parse(splittedString[0]);
				yCoord = int.Parse(splittedString[1]);
				zCoord = int.Parse(splittedString[2]);
				//creating the current Point3D
				Point3D currentPoint = new Point3D(xCoord, yCoord, zCoord);
				//adding to the PathList
				loadedPath.PathList.Add(currentPoint);
				//reading next line
				line = sourceFile.ReadLine();
			}
		}

		return loadedPath;
	}
	public static void Write(Path currentPath, string destinaton)
	{
		using (StreamWriter destinatonFile = new StreamWriter(destinaton))
		{
			//read evety point from the PathList and write it to the file :)
			foreach (Point3D item in currentPath.PathList)
			{
				destinatonFile.WriteLine(item.ToString());
			}
		}
	}
}
