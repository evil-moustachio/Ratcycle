using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
    public class World
    {
        private Game1 _game;
        private ViewController _viewController;
        public Player Player;

        public World(Game1 game)
        {
            _game = game;
            Player = new Player();
            _viewController = new ViewController(_game);
        }

        public void Update()
        {
			Player.Update();
            Model.Update();
            _viewController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the views
            _viewController.Draw(spriteBatch);
        }
    }
}