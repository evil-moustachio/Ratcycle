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
        /// <param name="animates"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
        /// <param name="speed"></param>
        /// <param name="up"></param>
        /// <param name="down"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public Rat(Vector2 position, Texture2D texture, bool animates,
            Game1 game, View view, Vector2 speed, Keys up, Keys down, Keys left, Keys right)
            : base(position, texture, animates, game, view, speed)
        {

            _health = 100;
            _up = up;
            _down = down;
            _left = left;
            _right = right;
        }
        
        /// <summary>
        /// Moves the rat according to certain keyboard input and sets border boundaries for movement.
        /// </summary>
        private void Move()
        {
			if (KeyHandler.IsKeyDown(_up) && _position.Y > _minCoords.Y)
            {
                _position.Y -= _speed.Y;
            }
			if (KeyHandler.IsKeyDown(_down) && _position.Y < _maxCoords.Y)
            {
                _position.Y += _speed.Y;
            }
			if (KeyHandler.IsKeyDown(_left) && _position.X > _minCoords.X)
            {
                _position.X -= _speed.X;
            }
			if (KeyHandler.IsKeyDown(_right) && _position.X < _maxCoords.X)
            {
                _position.X += _speed.X;
            }
        }

        /// <summary>
        /// Determines what happens on hit of a certain object. 
        /// </summary>
        /// <param name="other"></param>
        public override void OnHit(Entity other)
        {
            Console.WriteLine("I'm being hit!!! My up key is: " + _up);
            // Write code what happens OnHit
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
