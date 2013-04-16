using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Path
{
	//we will use the default methods of List<> as .Add(), .Remove(), .RemoveAt()
	private List<Point3D> pathList = new List<Point3D>();
	public List<Point3D> PathList { get; set; }
}