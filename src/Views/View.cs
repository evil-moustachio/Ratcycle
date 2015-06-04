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

		public View (ViewController viewController, Game1 game)
		{
            _game = game;
            _viewController = viewController;
		}

		public void Update ()
		{
            // Update Entities in for loop
		}

		public void Draw (SpriteBatch spriteBatch)
		{
            // Draw entities in for loop
		}
	}
}

