using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
	//Task 6:
	public class MeteoriteBall : Ball
	{
		public const int TrailLife = 4;

		public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
			: base(topLeft, speed)
		{
		}

		protected override void UpdatePosition()
		{
			this.TopLeft += this.Speed;
		}

		public TrailObject CreateTrail()
		{
			TrailObject trail = new TrailObject(this.topLeft, new char[,] { { '.' } }, TrailLife);
			return trail;
		}
	}
}
