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

		private View _currentView;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = true;		
		}
			
		protected override void Initialize ()
		{
			base.Initialize ();
				
		}

		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
		}
			
		protected override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
			_currentView.Update ();
		}
			
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.White);
			spriteBatch.Begin ();
			_currentView.Draw (spriteBatch);
			spriteBatch.End ();
		}
	}
}

