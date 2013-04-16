﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public struct Point3D
{
	//01.public fields for the coordinates
	public int XCoord { get; set; }
	public int YCoord { get; set; }
	public int ZCoord { get; set; }

	//02. setting the center of the system as a readonly static field
	private static readonly Point3D center = new Point3D(0, 0, 0);

	public static Point3D Center
	{
		get { return center; } //the center is read-only so no setter needed
	}


	//the minimum constructor for Point3D is three coordinates :)
	public Point3D(int xCoord, int yCoord, int zCoord)
		: this()
	{
		this.XCoord = xCoord;
		this.YCoord = yCoord;
		this.ZCoord = zCoord;
	}

	//01. Override the ToString() method :)
	public override string ToString()
	{
		return String.Format("[{0}, {1}, {2}]", XCoord, YCoord, ZCoord); //custom format :D
	}
}
