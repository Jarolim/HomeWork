using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //eighth task
    public class UnstoppableBall : MovingObject
    {
        public new const string CollisionGroupString = "unstoppableball";

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '@' } }, speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block"
                || otherCollisionGroupString == "indestructibleblock";
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //eighth task
            if (collisionData.hitObjectsCollisionGroupStrings[collisionData.hitObjectsCollisionGroupStrings.Count - 1] ==
                "indestructibleblock" || 
                collisionData.hitObjectsCollisionGroupStrings[collisionData.hitObjectsCollisionGroupStrings.Count - 1] ==
                "racket")
            {
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                {
                    this.Speed.Row *= -1;
                }
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                {
                    this.Speed.Col *= -1;
                }
            }
        }
    }
}
