using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task 4 : Create a class Path to hold a sequence of points in the 3D space.
  Create a static class PathStorage with static methods to save and load paths 
  from a text file. Use a file format of your choice.*/
namespace Task1_2_3_4Point3D
{
    class Path
    {
        //Using the default methods of List<> as .Add(), .Remove(), .RemoveAt() - thanks to vlad0
        private List<Point3D> pathList = new List<Point3D>();
        public List<Point3D> PathList { get; set; }
    }
}
