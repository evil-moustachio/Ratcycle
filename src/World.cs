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
        public Player _player;

        public Model Model;

        public World(Game1 game)
        {
            _game = game;
            Model = new Model();
            _player = new Player();
            _viewController = new ViewController(game);
        }

        public void Update()
        {
			_player.Update();
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