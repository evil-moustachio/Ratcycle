using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
    public class Stage : View
    {
		private Rat _rat;

		public Vector2 RatPosition
		{
			get
			{
				return _rat.Position;
			}
		}

		public Rectangle RatHitBox
		{
			get
			{
				return _rat.HitBox;
			}
		}

        /// <summary>
        /// Constructs the stage.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="viewController"></param>
		/// <param name="mouseVisible"></param>
		public Stage (Game1 game, ViewController viewController, Boolean mouseVisible) : base (game, viewController, mouseVisible)
        {
			_gameObjects.Add(
				new Rat(ContentHandler.GetTexture("rat_ratCycle.png"), new Vector2(200, 200), game, this, new Vector2(5,5), Keys.W, Keys.S, Keys.A, Keys.D)
			);

			
		    _rat = (Rat)_gameObjects[_gameObjects.Count - 1];
        }

		/// <summary>
		/// Checks if Entity collides with any other entity
		/// </summary>
		/// <returns><c>true</c>, if colliding was noted, <c>false</c> otherwise.</returns>
		/// <param name="entity">Entity.</param>
		/// <param name="fhb">FutureHitBox.</param>
		/// <param name="minc">MinCoord.</param>
		/// <param name="maxc">MaxCoord.</param>
        public bool NotColliding (Entity entity, Rectangle fhb, Vector2 minc, Vector2 maxc)
        {
            Rectangle futureHitBox = fhb;

            if (futureHitBox.Y < maxc.Y && futureHitBox.X > minc.X && futureHitBox.X < maxc.X && futureHitBox.Y > minc.Y)
            {
                foreach (Entity gameObject in _gameObjects)
                {
                    if (gameObject is Entity && entity != gameObject && futureHitBox.Intersects(gameObject.HitBox))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Loops through a list of GameObjects, filters out only the Entity extensions and checks if they loop 
        /// any other Entity object. Both the colliding objects will eventually have OnHit() invoked upon them, 
        /// so they both have their own reaction
        /// </summary>
        /*
        private void CheckObjectCollision ()
        {
			foreach (TexturedGameObject object1 in _gameObjects)
            {
                if (object1 is Entity)
                {
					foreach (TexturedGameObject object2 in _gameObjects)
                    {
                        if (object2 is Entity)
                        {
                            if (object1.HitBox.Intersects(object2.HitBox) && object1 != object2)
                            {
                                ((Entity) object1).OnHit((Entity) object2);
                            }
                        }
                    }
                }
            }
        }
        */
        /// <summary>
        /// Updates the stage, also invokes CheckObjectCollision before base.Update() so collision check is done before objects are updated.
        /// </summary>
        public override void Update()
        {
            //CheckObjectCollision();
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ContentHandler.GetTexture("background_ratCycle"), new Vector2());
            base.Draw(spriteBatch);
        }
    }
}
