using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public class View
	{
        private Game1 _game;
        private ViewController _viewController;
        protected GameObject[] _gameObjects;

		public View (Game1 game, ViewController viewController)
		{
            _game = game;
            _viewController = viewController;
		}

		public virtual void Initialize()
		{
		}

		public virtual void Update ()
		{
		}

		public virtual void Draw (SpriteBatch spriteBatch)
		{
		}
	}
}

