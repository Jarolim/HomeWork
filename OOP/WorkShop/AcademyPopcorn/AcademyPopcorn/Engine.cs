using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        Racket playerRacket;

        public Engine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
        }

		//Task 2:
		int sleep = 400;
		public Engine(IRenderer renderer, IUserInterface userInterface, int sleep)
			: this(renderer, userInterface)
		{
			this.sleep = sleep;
		}
		//End of task 2. 

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Racket)
                {
                    AddRacket(obj);

                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        private void AddRacket(GameObject obj)
        {
            //TODO: we should remove the previous racket from this.allObjects
			//Task 3:
			for (int i = 0; i < this.allObjects.Count; i++)
			{
				if (this.allObjects[i] is Racket)
				{
					this.allObjects.Remove(allObjects[i]);
					break;
				}
			}
			//End of task 3.
            this.playerRacket = obj as Racket;
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerRacketLeft()
        {
            this.playerRacket.MoveLeft();
        }

        public virtual void MovePlayerRacketRight()
        {
            this.playerRacket.MoveRight();
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(sleep); // Task 2: Changed the 500 to sleep

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

				//Task 6:
				for (int i = 0; i < this.allObjects.Count; i++)
				{
					if (allObjects[i] is MeteoriteBall)
					{
						MeteoriteBall ball = (MeteoriteBall)allObjects[i];
						TrailObject trail = ball.CreateTrail();
						this.allObjects.Add(trail);
					}
					allObjects[i].Update();
					this.renderer.EnqueueForRendering(allObjects[i]);
				}
				//End of task 6.
                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
            }
        }
    }
}
