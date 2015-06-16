﻿using System;

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
		private Bin[] _bins = new Bin[3];

		public Vector2 RatBase { get { return new Vector2(_rat.HitBox.Center.X, _rat.HitBox.Bottom); } }
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
				new Vector2 (5, 5), 100, 45);
			_hud = new StageHUD(_game, _viewController, false, _rat, this);

            _gameObjects.Add(_rat);
            _gameObjects.Add(new ChemicalBin(new Vector2(100, 200), _game, this));
            _gameObjects.Add(new StrongChemical(new Vector2(600, 400), _game, this));
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
                for (int i = _gameObjects.Count - 1; i >= 0; i--)
                {
                    if ((_gameObjects[i] is Entity || _gameObjects[i] is Bin) && _gameObjects[i] != entity && futureHitBox.Intersects(((AtlasObject)_gameObjects[i]).HitBox))
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

            for (int i = _gameObjects.Count - 1; i >= 0; i--)
            {
                if (_gameObjects[i] is Entity && attacker != _gameObjects[i] && AttackBox.Intersects(((Entity)_gameObjects[i]).HitBox) && attacker.GetType() != _gameObjects[i].GetType())
                {
                    ((Entity)_gameObjects[i]).Health -= attackerDamage;
                    attacked = true;
                }
            }

            return attacked;
        }

        public Garbage GarbageHandler ()
        {
            Garbage garbage;

            for (int i = _gameObjects.Count - 1; i >= 0; i--)
            {
				if (_gameObjects[i] is Garbage && _rat.AttackBox.Intersects(((Garbage)_gameObjects[i]).HitBox) && _rat.Inventory == null)
                {
                    garbage = (Garbage)_gameObjects[i];
					_hud.DrawGarbage (garbage.Category, garbage.Type);
					garbage.PickUp ();
                    return garbage;
                }
                else if (_gameObjects[i] is Bin && _rat.AttackBox.Intersects(((Bin)_gameObjects[i]).HitBox) && _rat.Inventory != null)
                {
                    _hud.RemoveGarbage();
                    ((Bin)_gameObjects[i]).AddGarbage(_rat.Inventory);
                    _gameObjects.Remove(_rat.Inventory);
                    return null;
                }
            }

            return null;
        }

        public void MonsterToGarbage(Monster monster, Texture2D texture)
        {            
			Garbage garbage = new Garbage(texture, monster.Position, _game, this, new Color(Color.Black, 0.7f), monster.Category, monster.Type, 1);

            _gameObjects.Remove(monster);
			_gameObjects.Add(garbage);
        }

        /// <summary>
        /// Updates the stage, also invokes CheckObjectCollision before base.Update() so collision check is done before objects are updated.
        /// </summary>
        public override void Update()
        {
			if (!_isPaused) 
				base.Update();

			if (KeyHandler.checkNewKeyPressed (Keys.Escape)) 
				Pause();

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

		public void NextView()
		{
			_viewController.SetView (new MenuFinishStage(_game, _viewController, true, _bins));
		}
    }
}
