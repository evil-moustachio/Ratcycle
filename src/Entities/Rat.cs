using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using System;

namespace Ratcycle
{
    class Rat : Entity
    {
        private Keys _up, _down, _left, _right;
        private int _health;

        /// <summary>
        /// Constructs the rat.
        /// </summary>
        /// <param name="position"></param>
		/// <param name="texture"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
        /// <param name="speed"></param>
        /// <param name="up"></param>
        /// <param name="down"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
		public Rat(Texture2D texture, Vector2 position, Game1 game, View view, Vector2 speed, Keys up, Keys down, Keys left, Keys right)
            : base(texture, position, game, view, Color.White, 1, 1, 1, false, speed)
        {
            _health = 100;
            _up = up;
            _down = down;
            _left = left;
            _right = right;
        }

        public override Rectangle HitBox
        {
            get
            {
                return new Rectangle(
                    (int)_position.X + 55,
                    (int)_position.Y + 100,
                    _sourceRectangle.Width  - 55,
                    _sourceRectangle.Height - 100);
            }
        }
        
        /// <summary>
        /// Moves the rat according to certain keyboard input and sets border boundaries for movement.
        /// </summary>
        private void Move()
        {
            Stage view = (Stage)_parentView;

            if (KeyHandler.IsKeyDown(_up) && (view.NotColliding(this, MakeFutureRectangle(_up), _minCoords, _maxCoords)))
            {
                _position.Y -= _speed.Y;
                
            }

            if (KeyHandler.IsKeyDown(_down) && view.NotColliding(this, MakeFutureRectangle(_down), _minCoords, _maxCoords))
            {
                _position.Y += _speed.Y;
            }
            if (KeyHandler.IsKeyDown(_left) && view.NotColliding(this, MakeFutureRectangle(_left), _minCoords, _maxCoords))
            {
                _position.X -= _speed.X;

            }
            if (KeyHandler.IsKeyDown(_right) && view.NotColliding(this, MakeFutureRectangle(_right), _minCoords, _maxCoords))
            {
                _position.X += _speed.X;
            }
             
        }

        private Rectangle MakeFutureRectangle (Keys key)
        {
            if (key == _up)
            { 
                return new Rectangle(HitBox.X, HitBox.Y - (int)_speed.Y, HitBox.Width, HitBox.Height);
            }
            else if (key == _down)
            {
                return new Rectangle(HitBox.X, HitBox.Y + (int)_speed.Y, HitBox.Width, HitBox.Height);

            }
            else if (key == _left)
            {
                return new Rectangle(HitBox.X - (int)_speed.X, HitBox.Y, HitBox.Width, HitBox.Height);
            }
            else if (key == _right)
            {
                return new Rectangle(HitBox.X + (int)_speed.X, HitBox.Y, HitBox.Width, HitBox.Height);
            }
            else
            {
                return new Rectangle();
            }
        }
        /// <summary>
        /// Determines what happens on hit of a certain object. 
        /// </summary>
        /// <param name="other"></param>
        public override void OnHit(Entity other)
		{
			// Write code what happens OnHit
			Console.WriteLine("I'm being hit!!! My up key is: " + _up + " " + Model.counter);
			Model.counter++;
        }

        /// <summary>
        /// Updates the rat.
        /// </summary>
        public override void Update()
        {
            base.Update();
            Move();
        }

    }
}
