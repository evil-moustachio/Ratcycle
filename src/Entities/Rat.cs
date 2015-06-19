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
            : base(texture, position, game, view, Color.White, 2, 1, 1, false, speed)
        {
			_health = health;
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
			}
			if (KeyHandler.IsKeyDown(_down) && view.NotColliding(this, MakeFutureRectangle(Directions.Down), _minCoords, _maxCoords)) 
            {
				_position.Y += _speed.Y;
			}
			if (KeyHandler.IsKeyDown(_left) && view.NotColliding(this, MakeFutureRectangle(Directions.Left), _minCoords, _maxCoords)) 
            {
				if (!_flip) 
                {
					_position.X += 25;
				}

				ChangeFrame (1);
				_position.X -= _speed.X;
				_flip = true;
			}
			if (KeyHandler.IsKeyDown(_right) && view.NotColliding(this, MakeFutureRectangle(Directions.Right), _minCoords, _maxCoords)) 
            {
					if (_flip) 
                    {
						_position.X -= 25;
					}

					ChangeFrame (0);
					_position.X += _speed.X;
					_flip = false;
			}
		}
        
        private void Attack()
        {
            if (KeyHandler.checkNewKeyPressed(Keys.Space))
            {
                //Animate

                ((Stage)_parentView).AttackHandler(this, _damage, AttackBox);
            }
        }

        private void PickUp()
        {
            if (KeyHandler.checkNewKeyPressed(Keys.F))
            {
                _inventory = ((Stage)_parentView).GarbageHandler();
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

        public override void KillEntity()
        {
            Console.WriteLine("Im ded lel im da rat");
        }

        /// <summary>
        /// Updates the rat.
        /// </summary>
        public override void Update()
        {
            base.Update();
            Move();
            PickUp();
            Attack();
        }
    }
}
