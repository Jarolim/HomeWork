using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //twelfth task
    public class GiftBlock : Block
    {
        public const int FragmentLife = 1;
        private const char Symbol = '%';
        public new const string CollisionGroupString = "giftblock";

        public GiftBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = GiftBlock.Symbol;
        }

        public override void Update()
        {
            
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball" || otherCollisionGroupString == "unstoppableball";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            //this.ProduceObjects();
        }

        public override string GetCollisionGroupString()
        {
            return ExplodingBlock.CollisionGroupString;
        }


        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Gift> array = new List<Gift>();
            if (this.IsDestroyed)
            {
                Gift gift =
                new Gift(this.topLeft, new MatrixCoords(1, 0));
                array.Add(gift);
            }
            return array;
        }
    }
}
