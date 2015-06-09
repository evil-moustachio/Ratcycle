
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
		private View view;


        public ViewController(Game1 game)
        {
            _game = game;
			view = new MenuStart (game, this, false);
        }

		public void setView(View newView)
		{
			view = newView;
		}

        public void Update()
		{
			// Update the current view
			view.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
		{
			// Draw the current view
			view.Draw(spriteBatch);
		}
    }
}