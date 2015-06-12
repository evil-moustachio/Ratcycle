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
		private Boolean _isPaused;

		public Vector2 RatPosition { get { return _rat.Position; } }
		public Rectangle RatHitBox { get { return _rat.HitBox; } }

        /// <summary>
        /// Constructs the stage.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="viewController"></param>
		/// <param name="mouseVisible"></param>
		public Stage(Game1 game, ViewController viewController, Boolean mouseVisible) 
			: base (game, viewController, mouseVisible)
        {
			_rat = new Rat(ContentHandler.GetTexture ("RatSprite"), new Vector2 (200, 200), game, this, 
				new Vector2 (5, 5), 100, 45, Keys.W, Keys.S, Keys.A, Keys.D);
			_gameObjects.Add(_rat);

			_gameObjects.Add(new Monster(ContentHandler.GetTexture("SquareButton"), new Vector2(700, 100), _game, this, 
				new Vector2(1,1), 100, 2, 20, 3.0f));
			_hud = new StageHUD(_game, _viewController, false, _rat, this);
        }

		/// <summary>
		/// Checks if Entity collides with any other entity
		/// </summary>
		/// <returns><c>true</c>, if colliding was noted, <c>false</c> otherwise.</returns>
		/// <param name="entity">Entity.</param>
		/// <param name="fhb">FutureHitBox.</param>
		/// <param name="minc">MinCoord.</param>
		/// <param name="maxc">MaxCoord.</param>
        public bool NotColliding(Entity entity, Rectangle fhb, Vector2 minc, Vector2 maxc)
        {
            Rectangle futureHitBox = fhb;

            if (futureHitBox.Y < maxc.Y && futureHitBox.X > minc.X && futureHitBox.X < maxc.X && futureHitBox.Y > minc.Y)
            {
                foreach (Entity gameObject  in _gameObjects)
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


        public bool AttackHandler (Entity attacker, float attackerDamage, Rectangle AttackBox)
        {
            bool attacked = false;

            foreach (Entity defender in _gameObjects)
            {
                if (defender is Entity && attacker != defender && AttackBox.Intersects(defender.HitBox) && attacker.GetType() != defender.GetType())
                {
                    defender.Health -= attackerDamage;
                    attacked = true;
                }
            }

            return attacked;
        }

        public void MonsterToGarbage(Monster monster, Texture2D texture)
        {            
            Garbage garbage = new Garbage(texture, monster.Position, _game, this, new Color(Color.Black, 0.7f));

            _gameObjects.Remove(monster);
            _gameObjects.Add(garbage);
        }

        /// <summary>
        /// Updates the stage, also invokes CheckObjectCollision before base.Update() so collision check is done before objects are updated.
        /// </summary>
        public override void Update()
        {
			if (!_isPaused) 
            {
                for (int i = _gameObjects.Count - 1; i >= 0; i--)
                {
                    if (_gameObjects[i] is Entity && ((Entity) _gameObjects[i]).IsDead)
                    {
                        ((Entity)_gameObjects[i]).DieEntity();
                    }
                }

				base.Update();
			}

			if (KeyHandler.checkNewKeyPressed (Keys.Escape)) 
            {
				Pause();
			}

			_hud.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ContentHandler.GetTexture("background_ratCycle"), new Vector2());
            base.Draw(spriteBatch);

			_hud.Draw(spriteBatch);
        }

		public void Pause()
		{
			if (_isPaused) 
            {
				_isPaused = false;
				_hud.UnPause ();
			} 
            else 
            {
				_isPaused = true;
				_hud.Pause ();
			}
		}

		public void ChangeToFinished()
		{
			_viewController.SetView (new MenuFinishedLevel(_game, _viewController, true));
		}
    }
}
