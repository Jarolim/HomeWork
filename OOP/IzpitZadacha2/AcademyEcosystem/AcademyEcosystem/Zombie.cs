using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
	public class Zombie : Animal
	{
		public Zombie(string name, Point location)
            : base(name, location, 0)
        {
        }

		public override int GetMeatFromKillQuantity()
		{
			return 10; //this.Size
		}

		public override void Update(int timeElapsed)
		{
			if (this.State == AnimalState.Sleeping)
			{
				if (timeElapsed >= sleepRemaining)
				{
					this.Awake();
				}
				else
				{
					this.sleepRemaining -= timeElapsed;
				}
			}
			base.Update(timeElapsed);
		}
	}
}
