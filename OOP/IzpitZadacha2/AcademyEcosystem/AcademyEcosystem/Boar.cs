using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
	public class Boar : Animal, ICarnivore, IHerbivore
	{
		private int biteSize;

        public Boar(string name, Point location)
            : base(name, location, 4)
        {
            this.biteSize = 2;
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

        public int EatPlant(Plant p)
        {
            if (p != null)
            {               
				this.Size++;
				return p.GetEatenQuantity(this.biteSize);
            }
            return 0;
        }

		public int TryEatAnimal(Animal animal)
		{
			if (animal != null)
			{
				if (animal.Size <= this.Size)
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

	}
}
