using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
    public class World
    {
        private Game _game;
        private ViewController _viewController;
		private MouseHandler _mouseHandler;
		private KeyHandler _keyHandler;

        public Model Model;

        public World(Game1 game)
        {
            _game = game;
            Model = new Model();
            _viewController = new ViewController(game);
			_mouseHandler = new MouseHandler ();
			_keyHandler = new KeyHandler ();
        }

        public void Update()
        {
			//Update the model
			Model.Update();

			// Update the world
            _viewController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the world
            _viewController.Draw(spriteBatch);
        }

		/// <summary>
		/// Gets the mouse handler.
		/// </summary>
		/// <value>The mouse handler.</value>
		public MouseHandler MouseHandler
		{
			get { return _mouseHandler; }
		}

		/// <summary>
		/// Gets the key handler.
		/// </summary>
		/// <value>The key handler.</value>
		public KeyHandler KeyHandler
		{
			get { return _keyHandler; }
		}
    }
}