
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
		private View[] _views;
		private int _currentView = 0;

        public ViewController(Game1 game)
        {
            _game = game;
            _views = new View[] {

            };
			initializeView ();

        }

		public int CurrentView {
			get { return _currentView; }
			set { 
				_currentView = value;
				initializeView ();
			}
		}

        public void Update()
		{
			// Update the current view
			_views[_currentView].Update();
        }

        public void Draw(SpriteBatch spriteBatch)
		{
			// Draw the current view
            _views[_currentView].Draw(spriteBatch);
		}

		private void initializeView() 
		{
			_views [_currentView].Initialize ();
		}
    }
}