using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
	public class Wolf : Animal, ICarnivore
	{
		public Wolf(string name, Point location)
            : base(name, location, 4)
        {
        }

		public int TryEatAnimal(Animal animal)
		{
			if (animal != null)
			{
				if (animal.Size <= this.Size || animal.State == AnimalState.Sleeping)
				{
					if (animal is Zombie)
					{
						return animal.GetMeatFromKillQuantity();
					}
					return animal.GetMeatFromKillQuantity();
				}
			}
			else
			{
				return 0;
			}
			return 0;
		}
		//	if (this.Size >= animal.Size)
		//	{
		//		return animal.GetMeatFromKillQuantity();
		//	}
		//	if (animal.State == AnimalState.Sleeping)
		//	{
		//		return animal.GetMeatFromKillQuantity();
		//	}
		//	if (animal is Zombie)
		//	{
		//		return animal.GetMeatFromKillQuantity();
		//	}
		//	return 0;
		

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
		//public int EatPlant(Plant p)
		//{
		//	if (p != null)
		//	{
		//		return p.GetEatenQuantity(this.biteSize);
		//	}
		//
		//	return 0;
		//}
	}
}
