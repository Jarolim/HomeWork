using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*Task 4 : Create a class Path to hold a sequence of points in the 3D space.
  Create a static class PathStorage with static methods to save and load paths 
  from a text file. Use a file format of your choice.*/
namespace Task1_2_3_4Point3D
{
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
                    int coordX, coordY, coordZ;
                    //parsing the coordinates
                    coordX = int.Parse(splittedString[0]);
                    coordY = int.Parse(splittedString[1]);
                    coordZ = int.Parse(splittedString[2]);
                    //creating the current Point3D
                    Point3D currentPoint = new Point3D(coordX, coordY, coordZ);
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
}
