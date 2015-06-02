#region Using Statements
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

		public World World;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "GameFiles/Content";	            
			graphics.IsFullScreen = false;
			graphics.PreferredBackBufferHeight = 600;
			graphics.PreferredBackBufferWidth = 800;
		}
			
		protected override void Initialize ()
		{
			base.Initialize ();
			World = new World (this);
		}

		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
		}
			
		protected override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
			World.Update ();
		}
			
		protected override void Draw (GameTime gameTime)
		{
			// Resets the image 
			graphics.GraphicsDevice.Clear (Color.White);

			// Starts the spritebatch
			spriteBatch.Begin ();
			// Tells the World to draw it's state
			World.Draw (spriteBatch);
			// Ends the spritebatch
			spriteBatch.End ();
		}
	}
}

