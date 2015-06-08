using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
    public class Stage : View
    {
        /// <summary>
        /// Constructs the stage.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="viewController"></param>
		public Stage (Game1 game, ViewController viewController, Boolean mouseVisible) : base (game, viewController, mouseVisible)
        {
            Texture2D texture = CreateRectangle(game, 50, 50, Color.Red);
        }

        /// <summary>
        /// Initializes all variables in a view again, so variables aren't kept.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
			_game.IsMouseVisible = false;

//			_gameObjects.Add(new Rat(new Vector2(400, 200), _game, this, CreateRectangle(_game, 50, 50, Color.Yellow), 1, 1, false, new Vector2(5,5), Keys.W, Keys.S, Keys.A, Keys.D));
//			_gameObjects.Add(new Rat(new Vector2(600, 200), _game, this, CreateRectangle(_game, 50, 50, Color.Blue), 1, 1, false, new Vector2(5, 5), Keys.Up, Keys.Down, Keys.Left, Keys.Right));
			_gameObjects.Add(
				new Rat(
					new Vector2(400, 200),
					_game,
					this,
					CreateRectangle(_game, 50, 50, Color.Yellow),
					1,
					1,
					5,
					new Vector2(5,5),
					Keys.W,
					Keys.S,
					Keys.A,
					Keys.D
				)
			);
        }

        /// <summary>
        /// Loops through a list of GameObjects, filters out only the Entity extensions and checks if they loop 
        /// any other Entity object. Both the colliding objects will eventually have OnHit() invoked upon them, 
        /// so they both have their own reaction
        /// </summary>
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

        /// <summary>
        /// Updates the stage, also invokes CheckObjectCollision before base.Update() so collision check is done before objects are updated.
        /// </summary>
        public override void Update()
        {
            CheckObjectCollision();
            base.Update();
        }
    }
}
