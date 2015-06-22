using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
    public class Rat : Entity
    {
        private Garbage _inventory;
        private bool _flip = false;
        private Keys _up = Keys.W;
        private Keys _down = Keys.S;
        private Keys _left = Keys.A;
        private Keys _right = Keys.D;
        private const float _regenTime = 3;
        private float _remainingRegenTime = _regenTime;
		private long _gameOverTick;

		public bool IsAlive { get { return _alive; } }

		public enum Directions
		{
			Up,
			Right,
			Down,
			Left
		}

        public Garbage Inventory
        {
            get { return _inventory; }
        }

        public override Rectangle AttackBox
        {
            get
            {
                if (_flip)
                {
                    return new Rectangle(
                        (int)_position.X - 30,
                        (int)_position.Y + 30,
                        30,
                        _sourceRectangle.Height - 30);
                }
                else
                {
                    return new Rectangle(
                        (int)_position.X + _sourceRectangle.Width,
                        (int)_position.Y + 30,
                        30,
                        _sourceRectangle.Height - 30);
                }
            }
        }

        public Rectangle BodyBox
        {
            get
            {
                return new Rectangle(
                    (int)_position.X,
                    (int)_position.Y,
                    _sourceRectangle.Width,
                    _sourceRectangle.Height
                );
            }
        }

		public override Rectangle HitBox
		{
			get
			{
				if (_flip) 
                {
					return new Rectangle (
						(int)_position.X,
						(int)_position.Y + 50,
						_sourceRectangle.Width - 25,
						_sourceRectangle.Height - 50);
				} 
                else 
                {
					return new Rectangle (
						(int)_position.X + 25,
						(int)_position.Y + 50,
						_sourceRectangle.Width - 25,
						_sourceRectangle.Height - 50);
				}
			}
		}

        /// <summary>
        /// Constructs the rat.
        /// </summary>
        /// <param name="position"></param>
		/// <param name="texture"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
        /// <param name="speed"></param>
        /// <param name="health"></param>
        /// <param name="damage"></param>
		public Rat(Texture2D texture, Vector2 position, Game1 game, View view, Vector2 speed, float health, float damage)
            : base(texture, position, game, view, Color.White, 6, 6, 36, true, speed)
        {
			_health = (100 * (0.75f * (float) Model.Stage.Reached));
            _damage = damage;
        }
        
        /// <summary>
        /// Moves the rat according to certain keyboard input and sets border boundaries for movement.
        /// </summary>
        private void Move()
        {
            Stage view = (Stage)_parentView;


			if (KeyHandler.IsKeyDown(_up) && view.NotColliding(this, MakeFutureRectangle(Directions.Up), _minCoords, _maxCoords)) 
            {
				_position.Y -= _speed.Y;

                Console.WriteLine(_flip);
                if (_flip)
                    ChangeFrame(3);
                else
                    ChangeFrame(2);
			}
			if (KeyHandler.IsKeyDown(_down) && view.NotColliding(this, MakeFutureRectangle(Directions.Down), _minCoords, _maxCoords)) 
            {
				_position.Y += _speed.Y;

                if (_flip)
                    ChangeFrame(3);
                else
                    ChangeFrame(2);
			}
			if (KeyHandler.IsKeyDown(_left)) 
            {
				if (!_flip) 
                {
					_position.X += 25;
				}

				ChangeFrame (3);
				
				_flip = true;
                if (view.NotColliding(this, MakeFutureRectangle(Directions.Left), _minCoords, _maxCoords))
                {
                    _position.X -= _speed.X;
                }
			}
			if (KeyHandler.IsKeyDown(_right))
            {
					if (_flip) 
                    {
						_position.X -= 25;
					}

					ChangeFrame (2);
					
					_flip = false;
                    if (view.NotColliding(this, MakeFutureRectangle(Directions.Right), _minCoords, _maxCoords))
                    {
                        _position.X += _speed.X;
                    }
			}
			if (!KeyHandler.IsKeyDown (_right) && !KeyHandler.IsKeyDown (_left) && !KeyHandler.IsKeyDown(_up) && !KeyHandler.IsKeyDown(_down)) 
			{
				if (_flip)
					ChangeFrame (5);
				else
					ChangeFrame (4);
			}
		}
        
        private void Attack()
        {
            if (KeyHandler.checkNewKeyPressed(Keys.Space))
            {
                //SoundEffect
				_soundEffect = new SoundHandler("Woosj", Model.Settings.SoundEffectVolume, _game);
                _soundEffect.Play();

                //Animate
				if (_flip)
					StartSingleMovement(1);
				else
					StartSingleMovement(0);
				
                ((Stage)_parentView).AttackHandler(this, _damage, AttackBox);
            }
        }

        private void PickUp()
        {
            if (KeyHandler.checkNewKeyPressed(Keys.F))
            {
                _inventory = ((Stage)_parentView).GarbageHandler(_inventory);
            }
        }


		private Rectangle MakeFutureRectangle (Directions direction)
        {
			switch (direction) 
			{
				case Directions.Up:
					return new Rectangle (HitBox.X, HitBox.Y - (int)_speed.Y, HitBox.Width, HitBox.Height);
				case Directions.Down:
					return new Rectangle (HitBox.X, HitBox.Y + (int)_speed.Y, HitBox.Width, HitBox.Height);
				case Directions.Left:
					return new Rectangle (HitBox.X - (int)_speed.X, HitBox.Y, HitBox.Width, HitBox.Height);
				case Directions.Right:
					return new Rectangle (HitBox.X + (int)_speed.X, HitBox.Y, HitBox.Width, HitBox.Height);
				default:
					return new Rectangle();
			}
        }
        
        private void RegenerateHealth()
        {
            var timer = (float)_game.GameTime.ElapsedGameTime.TotalSeconds;
            float health = _health;
            float regen = 0.8f * (Model.Stage.CurrentPlaying);

            _remainingRegenTime -= timer;

            if (_remainingRegenTime <= 0 && _health < (100 * (0.75f * (float) Model.Stage.Reached)))
            {
                Console.WriteLine(_health);
                health += regen;

                if (health > (100 * (0.75 * (float) Model.Stage.Reached)))
                {
                    health = (100 * (0.75f * (float)Model.Stage.Reached));
                }

                _health = health;
                //((Stage)_parentView).NewPlayerFeedback("+" + Math.Round(regen), Color.Green, new Vector2(HitBox.X, HitBox.Y), 125f, 30f);
                _remainingRegenTime = _regenTime;
            }
        }

        public override void KillEntity()
        {
			if (_alive)
			{
				_game.World.Music.Stop ();
				_soundEffect = new SoundHandler ("DeathSpiral", Model.Settings.SoundEffectVolume, _game);
				_soundEffect.Play ();

				((Stage)_parentView).NewPlayerFeedback("Fatality", Color.Red, new Vector2(_position.X - 30, _position.Y), 30f, 100f);
				_alive = false;
				_gameOverTick = Model.Time.CurrentGameTick + (Model.Time.OneSecondOfTicks * 2);
			} 
        }

        /// <summary>
        /// Updates the rat.
        /// </summary>
        public override void Update()
        {
            base.Update();
			if (_alive) 
			{
                RegenerateHealth();
				Move();
				PickUp();
				Attack();
			}
			else if (!_alive)
			{
				// Makes the rat stop breathing
				if (_flip)
					ChangeFrame (5, 0);
				else
					ChangeFrame (4, 0);

				// Show GameOver Screen at right time
				if (Model.Time.CurrentGameTick >= _gameOverTick)
				{
					((Stage)_parentView).GameOver();
				}
			}


				
        }
    }
}
	
