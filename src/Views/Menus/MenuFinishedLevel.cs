using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuFinishedLevel : Menu
	{
		public MenuFinishedLevel (Game1 game, ViewController viewController, Boolean mouseVisible) : base (game, viewController, mouseVisible)
		{
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("background_ratCycle"), new Vector2(0,0), _game, this, Color.White, 1, 1, 1, false));
		}
	}
}

