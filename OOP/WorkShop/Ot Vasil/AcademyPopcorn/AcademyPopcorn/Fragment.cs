using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //tenth task
    public class Fragment : MovingObject
    {
        private int lifetime;

        public int Lifetime { get; protected set; }

        public new const string CollisionGroupString = "fragment";

        public Fragment(MatrixCoords topLeft, MatrixCoords speed, int lifetime)
            : base(topLeft, new char[,] { { '"' } }, speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == "explodingblock";
        }

        public override string GetCollisionGroupString()
        {
            return Fragment.CollisionGroupString;
        }

        protected virtual void UpdateLifeTime()
        {
            this.lifetime--;
        }

        public override void Update()
        {
            this.UpdateLifeTime();
            if (this.lifetime <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
