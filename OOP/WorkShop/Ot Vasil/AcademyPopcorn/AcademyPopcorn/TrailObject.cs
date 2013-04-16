using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        //public new const string CollisionGroupString = "trail";
        //task five
        private int lifetime;

        public int Lifetime { get; protected set; }

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime)
            : base(topLeft, body)
        {
            this.lifetime = lifetime;
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
