
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
        private View _currentView;
        private View[] _views;

        public ViewController(Game1 game)
        {
            _game = game;
            _views = new View[] {

            };

            // Set to first screen;
            ChangeView(0);
        }

        public void ChangeView(int view)
        {
            _currentView = _views[view];
        }

        public void Update()
        {
            _currentView.Update();
            // Update the current view
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _currentView.Draw(spriteBatch);
            // Draw the current view
        }
    }
}