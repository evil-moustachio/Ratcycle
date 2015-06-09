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

        /// <summary>
        /// GameObject constructor.
        /// </summary>
		/// <param name="position"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
		public GameObject(Vector2 position, Game1 game, View view)
		{
			_position = position;
            _game = game;
            _parentView = view;

			// Default settings.
			_color = Color.White;
		}

		public virtual void Update()
		{

		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{

		}
	}
}

