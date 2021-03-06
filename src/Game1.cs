﻿#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace Ratcycle
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

        private World _world;
        private GameTime _gameTime;
        public SoundHandler Music;
        public SoundHandler soundEffect;
        public SaveGameHandler saveGame;
        public UpdateHandler updateChecker;

        public World World
        {
            get
            {
                return _world;
            }
        }

        public GameTime GameTime
        {
            get
            {
                return _gameTime;
            }
        }

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "GameFiles/Content";
			graphics.IsFullScreen = false;
			graphics.PreferredBackBufferHeight = 600;
			graphics.PreferredBackBufferWidth = 800;
			ContentHandler.SetContent();
		}

		protected override void Initialize()
		{
			base.Initialize();
            saveGame = new SaveGameHandler();
            saveGame.LoadGame();
			_world = new World(this);
		}

		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			ContentHandler.LoadContent (Content);

            Music = new SoundHandler("MainTheme", Model.Settings.MusicVolume, true);
            Music.Play();
            updateChecker = new UpdateHandler();
            updateChecker.CheckUpdate();
		}
			
		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
            _gameTime = gameTime;
			_world.Update();
		}
			
		protected override void Draw(GameTime gameTime)
		{
			// Resets the image 
			graphics.GraphicsDevice.Clear(Color.White);

			// Starts the spritebatch
			spriteBatch.Begin();
			// Tells the World to draw it's state
			_world.Draw(spriteBatch);
			// Ends the spritebatch
			spriteBatch.End();
		}

        public void ChangeMusic(string name)
        {
            if (name != Music.GetName() || !Music.IsPlaying())
            {
                Music.Stop();
                Music = new SoundHandler(name, Model.Settings.MusicVolume, true);
                Music.Play();
            }
        }
	}
}

