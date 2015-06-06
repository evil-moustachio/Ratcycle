using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class MenuStart : View
	{
		public MenuStart (Game1 game, ViewController viewController) : base(game, viewController)
		{
		}

		public override void Initialize() {
			base.Initialize();
			_game.IsMouseVisible = true;

			_gameObjects.Add (new Button (new Vector2(0,0), ContentHandler.GetTexture("StartButton"), 1, 3, 
				false, _game, this, 1));
		}
	}
}

