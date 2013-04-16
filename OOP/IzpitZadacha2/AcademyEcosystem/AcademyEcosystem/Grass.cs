﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
	public class Grass : Plant
	{
		public Grass(Point location)
            : base(location, 2)
        {
        }
		public override void Update(int time)
		{
			if (this.IsAlive == true)
			{
				this.Size += time;
			}
		}
	}
}
