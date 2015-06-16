using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuFinishStage : Menu
	{
		private Bin[] _bins = new Bin[3];
		public MenuFinishStage (Game1 game, ViewController viewController, Boolean mouseVisible, Bin[] bins) : base (game, viewController, mouseVisible)
		{
			_bins = bins;

			//Background
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("Background-02"), new Vector2(0,0), _game, 
				this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("BackgroundGray"), new Vector2(0,0), _game, this, 
				Color.White, 1, 1, 1, false));
		}
	}
}

