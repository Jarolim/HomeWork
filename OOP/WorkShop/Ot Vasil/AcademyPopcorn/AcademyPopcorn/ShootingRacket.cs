using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //thirdteenth task
    public class ShootingRacket : Racket
    {
        private bool isShootingRacket;

        public bool IsShootingRacket { get; protected set; }

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }

        public override string GetCollisionGroupString()
        {
            return ShootingRacket.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == ShootingRacket.CollisionGroupString || 
                otherCollisionGroupString == "ball";
        }

        public override void Update()
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Bullet> array = new List<Bullet>();
            if (this.isShootingRacket)
            {
                Bullet firstBullet =
                new Bullet(this.topLeft, new MatrixCoords(-1, 0));
                Bullet secondBullet =
                new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + this.Width - 1), new MatrixCoords(-1, 0));
                array.Add(firstBullet);
                array.Add(secondBullet);
            }
            return array;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //thirdteenthth task
            if (collisionData.hitObjectsCollisionGroupStrings[collisionData.hitObjectsCollisionGroupStrings.Count - 1] == "gift")
            {
                this.isShootingRacket = true;
            }
        }
    }
}
