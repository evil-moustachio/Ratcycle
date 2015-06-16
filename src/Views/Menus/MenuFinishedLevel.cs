using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuFinishedLevel : Menu
	{
		private Bin[] _bins = new Bin[3];
		public MenuFinishedLevel (Game1 game, ViewController viewController, Boolean mouseVisible, Bin[] bins) : base (game, viewController, mouseVisible)
		{
			_bins = bins;

			//Background
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("background_ratCycle"), new Vector2(0,0), _game, 
				this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("GrayBackground"), new Vector2(0,0), _game, this, 
				Color.White, 1, 1, 1, false));
		}
	}
}

