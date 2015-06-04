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

        // World constructor
        public World(Game1 game)
        {
            _game = game;

            _viewController = new ViewController(game);
        }

        public void Update()
        {
            _viewController.Update();
            // Update the world
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the world
            _viewController.Draw(spriteBatch);
        }
    }
}