using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
	public class Lion : Animal, ICarnivore
	{
		public Lion(string name, Point location)
            : base(name, location, 6)
        {
        }

		public int TryEatAnimal(Animal animal)
		{
			if (animal != null)
			{
				if (animal.Size <= (this.Size*2))
				{
					if (animal is Zombie)
					{
						this.Size++;
						return animal.GetMeatFromKillQuantity();
					}
					this.Size++;
					return animal.GetMeatFromKillQuantity();
				}
			}
			else
			{
				return 0;
			}
			return 0;
		//	if (this.Size >= animal.Size*2 && animal != null)
		//	{
		//		return animal.GetMeatFromKillQuantity();
		//	}
		//	return 0;
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
