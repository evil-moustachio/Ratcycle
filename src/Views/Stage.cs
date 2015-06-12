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
		private StageHUD _hud;

		public Vector2 RatPosition { get { return _rat.Position; } }
		public Rectangle RatHitBox { get { return _rat.HitBox; } }

        /// <summary>
        /// Constructs the stage.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="viewController"></param>
		/// <param name="mouseVisible"></param>
		public Stage (Game1 game, ViewController viewController, Boolean mouseVisible) : base (game, viewController, mouseVisible)
        {
			_rat = new Rat (ContentHandler.GetTexture ("RatSprite"), new Vector2 (200, 200), game, this, new Vector2 (5, 5), 100, Keys.W, Keys.S, Keys.A, Keys.D);
			_gameObjects.Add (_rat);
			_rat = new Rat (ContentHandler.GetTexture ("RatSprite"), new Vector2 (400, 200), game, this, new Vector2 (5, 5), 100, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
			_gameObjects.Add (_rat);

//			_gameObjects.Add (new Monster(ContentHandler.GetTexture("SquareButton"), new Vector2(700, 100), _game, this, new Vector2(1,1), 100));
			_hud = new StageHUD (_game, _viewController, false, _rat);
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
        /// Updates the stage, also invokes CheckObjectCollision before base.Update() so collision check is done before objects are updated.
        /// </summary>
        public override void Update()
        {
            //CheckObjectCollision();
            base.Update();
			_hud.Update ();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ContentHandler.GetTexture("background_ratCycle"), new Vector2());
            base.Draw(spriteBatch);

			//And draw HUD at the last moment
			_hud.Draw(spriteBatch);
        }
    }
}
