using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        public double Radius { get; set; }
        public double Height { get; set; }

        public Cylinder(Vector3D bottom, Vector3D top, double radius)
            : base(bottom, top)
        {
            this.Radius = radius;
            //this.Height = Math.Sqrt(Vector3D.DotProduct(this.vertices[0], new Vector3D(vertices[0].X, vertices[0].Y, vertices[1].Z)));
            this.Height = (vertices[0] - vertices[1]).Magnitude;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }

        public double GetArea()
        {
            return 2*Math.PI * this.Radius * (this.Radius + this.Height); //*2 ??
        }

        public double GetVolume()
        {
            return Math.PI * this.Radius * this.Radius * this.Height;
        }
    }
