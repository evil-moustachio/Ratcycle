
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
    public class ViewController
    {
		private Game1 _game;
		private View _view;

        /// <summary>
        /// Constructs the ViewController
        /// </summary>
        /// <param name="game"></param>
        public ViewController(Game1 game)
        {
            _game = game;
			_game.IsMouseVisible = true;

			_view = new MenuStart (_game, this, true);
        }

        /// <summary>
        /// Sets the view to a new view.
        /// </summary>
        /// <param name="newView"></param>
		public void SetView(View newView)
		{
			_view = newView;
			_game.IsMouseVisible = newView.MouseVisible;
		}

        /// <summary>
        /// Updates the current view.
        /// </summary>
        public void Update()
		{
			// Update the current view
			_view.Update();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
		{
			// Draw the current view
			_view.Draw(spriteBatch);
		}
    }
}