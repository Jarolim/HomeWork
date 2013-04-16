using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //tenth task
    public class ExplodingBlock : Block
    {
        public const int FragmentLife = 1;
        private const char Symbol = '*';
        public new const string CollisionGroupString = "explodingblock";

        public ExplodingBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
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
            List<Fragment> array = new List<Fragment>();
            if (this.IsDestroyed)
            {
                array = this.CreateFragmentArray();
            }
            return array;
        }

        public List<Fragment> CreateFragmentArray()
        {
            Fragment firstFragment = 
                new Fragment(this.topLeft, new MatrixCoords(-1, 0), FragmentLife);
            Fragment secondFragment = 
                new Fragment(this.topLeft, new MatrixCoords(0, -1), FragmentLife);
            Fragment thirdFragment = 
                new Fragment(this.topLeft, new MatrixCoords(0, 1), FragmentLife);
            Fragment fourthFragment = 
                new Fragment(this.topLeft, new MatrixCoords(1, 0), FragmentLife);
            List<Fragment> array = new List<Fragment>();
            array.Add(firstFragment);
            array.Add(secondFragment);
            array.Add(thirdFragment);
            array.Add(fourthFragment);
            return array;
        }
    }
}
