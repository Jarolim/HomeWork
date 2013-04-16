using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task 1 : Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian
   3D space. Implement the ToString() to enable printing a 3D point.*/

/*Task 2 : Add a private static read-only field to hold the start of the coordinate 
  system – the point O{0, 0, 0}. Add a static property to return the point O.*/
namespace Task1_2_3_4Point3D
{
	class Point3D
	{
		//Fields:
		public int coordX;
		public int coordY;
		public int coordZ;

		//setting the center of the coordinate system as a readonly static field
		private static readonly Point3D center = new Point3D(0, 0, 0);

		//Add a static property to return the point O.
		public static Point3D Center
		{
			get
			{
				return center;
			}
			// readonly so no setter needed
		}


		//Constructors:
		public Point3D(int coordX, int coordY, int coordZ)
		{
 			this.coordX = coordX;
			this.coordY = coordY;
			this.coordZ = coordZ;
		}
		
		//Printing the coordinates:
		public override string ToString()
		{
			StringBuilder endText = new StringBuilder();
            endText.AppendFormat("-----------");
			endText.AppendFormat("\nPoint X: {0}", this.coordX.ToString());
			endText.AppendLine();
			endText.AppendFormat("Point Y: {0}", this.coordY.ToString());
			endText.AppendLine();
			endText.AppendFormat("Point Z: {0} \n-----------", this.coordZ.ToString());
			return endText.ToString();
		}

	}
}
