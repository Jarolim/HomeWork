using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Circle : Figure, IAreaMeasurable, IFlat
{
    public double Radius { get; set; }

    public Circle(Vector3D center, double radius)
        : base(center)
    {
        this.Radius = radius;
    }

    public override double GetPrimaryMeasure()
    {
        return this.GetArea();
    }

    public double GetArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }

    public Vector3D GetNormal()
    {
        Vector3D A = vertices[0];
        Vector3D B = A + new Vector3D(0, this.Radius, 0);
        Vector3D C = A + new Vector3D(this.Radius, 0, 0);
        Vector3D normal = Vector3D.CrossProduct(A-B, C-A);
        normal.Normalize();
        return normal;
    }
}
