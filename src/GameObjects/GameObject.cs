using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public abstract class GameObject
	{
		protected Vector2 _position;
        protected Game1 _game;
		protected View _parentView;
		protected Color _color;

        public Vector2 Position
        {
            get
            {
               return _position;
            }
			set 
			{
				_position = value;
			}
        }

		public virtual int LowestY
		{
			get
			{
				return (int)_position.Y;
			}
		}

        /// <summary>
        /// GameObject constructor.
        /// </summary>
		/// <param name="position"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
		public GameObject(Vector2 position, Game1 game, View view, Color color)
		{
			_position = position;
            _game = game;
            _parentView = view;
			_color = color;
		}

        public GameObject(Game1 game, View view, Color color)
        {
            _game = game;
            _parentView = view;
            _color = color;
        }

        public virtual void Update() { }

        public abstract void Draw(SpriteBatch spriteBatch);
	}
}

