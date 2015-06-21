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
		public SoundHandler Music;

        /// <summary>
        /// Constructs the world.
        /// </summary>
        /// <param name="game"></param>
        public World(Game1 game)
        {
            _game = game;
            Player = new Player();
            _viewController = new ViewController(_game);
			Music = new SoundHandler("MainTheme", Model.Settings.MusicVolume, _game, true);
            Music.Play();
        }

		public void ChangeMusic (string location)
		{
			_game.World.Music.Stop ();
			_game.World.Music = new SoundHandler (location, Model.Settings.MusicVolume, _game, true);
			_game.World.Music.Play ();
		}

        /// <summary>
        /// Updates the world
        /// </summary>
        public void Update()
        {
			Player.Update();
            Model.Update();
            _viewController.Update();
        }

        /// <summary>
        /// Draws the world
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the views
            _viewController.Draw(spriteBatch);
        }
    }
}